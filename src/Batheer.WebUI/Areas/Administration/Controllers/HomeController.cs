using Batheer.Application.Common.Interfaces;
using Batheer.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class HomeController : BaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly IQueryExecuter _queryExecuter;
        private readonly SMSService _sMSService;


        public HomeController(IApplicationDbContext context, IQueryExecuter queryExecuter, SMSService sMSService)
        {
            _context = context;
            _queryExecuter = queryExecuter;
            _sMSService = sMSService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string SendSms(string mobile, string message)
        {
            (string messageId, string jsonString, bool isSucess) = _sMSService.Send(message, mobile).Result;

            return $"messageId:{messageId}, jsonString:{jsonString}, isSucess:{isSucess}";
        }

        public async Task<IActionResult> DataMigration_Do_Work()
        {
            var commands = DataMigration.Program.Do_Work_For_Mig2();

            Dictionary<string, string> result = new Dictionary<string, string>();

            commands.ForEach(command =>
            {
                try
                {
                    command.PersonalDataForm.IdentityNo = command.PersonalDataForm.IdentityNo.Trim();
                    if (command.PersonalDataForm.IdentityNo.Length == 10)
                    {
                        var query_result = _queryExecuter.Query<int>(@"SELECT Id FROM [ngostsa_db].[dbo].[PersonalDataForm] where IdentityNo = @IdentityNo", new { IdentityNo = command.PersonalDataForm.IdentityNo });

                        //                        if (_context.PersonalDataForm
                        //.Any(a => a.IdentityNo == command.PersonalDataForm.IdentityNo))

                        if (query_result.Count() >= 1)
                        { }
                        else
                        {

                            var model = Mediator.Send(command).Result;

                            result.Add(command.PersonalDataForm.IdentityNo, model.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {

                    result.Add(command.PersonalDataForm.IdentityNo, ex.Message);

                }

            });

            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(result);


            return Ok("done");
        }

        public async Task<ActionResult<string>> DataMigration_Do_Work_2()
        {
            CancellationToken cancellationToken = new CancellationToken();
            var dt = Batheer.DataMigration.Program.Do_Work_Step02();


            foreach (var f in dt.ToList())
            {

                var councilId = Convert.ToInt32(f["CouncilId"]);
                var identityNo = Convert.ToString(f["PersonalDataForm_IdentityNo"]);
                var familyNeedId = Convert.ToInt32(f["FamilyNeedId"]);
                var family = _context.Families
                .Include(i => i.FamilyRegistrationRequest.FamilyNeedData)
                .Where(i => i.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == councilId)
                .Where(i => i.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == identityNo)
                .FirstOrDefault();

                if (family != null)
                {
                    if (false == family.FamilyRegistrationRequest.FamilyNeedData.Any(w => w.FamilyNeedId == familyNeedId))
                    {
                        family.FamilyRegistrationRequest.FamilyNeedData.Add(new Domain.AssociationAffiliatedProjects.Entities.FamilyNeedData()
                        {
                            Created = DateTime.UtcNow,
                            FamilyNeedId = familyNeedId,
                            CreatedBy = "admin"
                        });

                        await _context.SaveChangesAsync(cancellationToken);
                    }
                }

            }

            return Ok();
        }

    }
}
