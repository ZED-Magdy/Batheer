//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Batheer.Domain.AssociationAffiliatedProjects;
//using Batheer.Infrastructure.Persistence;

//namespace Batheer.WebUI.Areas.AssociationsAffiliated.Controllers
//{
//    [Area("AssociationsAffiliated")]
//    public class EnsuringOrphanRequestsController : Controller
//    {
//        private readonly ApplicationDBContext _context;

//        public EnsuringOrphanRequestsController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: AssociationsAffiliated/EnsuringOrphanRequests
//        public async Task<IActionResult> Index()
//        {
//            var applicationDBContext = _context.EnsuringOrphanRequests
//                //.Include(e => e.AssociationAffiliatedProject)
//                .Include(e => e.PersonalDataForm)
//                .Include(e => e.AccommodationData)
//                .Include(e => e.BankDefaultData)
//                .Include(e => e.ContactInformation)
//                .Include(e => e.EducationalData)
//                .Include(e => e.FinanceData)
//                .Include(e => e.HealthStatusData)
//                .Include(e => e.LoanData)
//                .Include(e => e.MaritalStatusData)
//                .Include(e => e.MonthlyIncomeData)
//                .Include(e => e.OccupationData)
//                .Include(e => e.ProjectData)
//                .Include(e => e.RequestStatus)
//                .Include(e => e.ResidencyAddressData)
//                .Include(e => e.SocialSecurityData)
//                .Include(e => e.WorkOnAProjectData);

//            try
//            {
//                await applicationDBContext.ToListAsync();
//            }
//            catch (Exception EX)
//            {

//                throw;
//            }

//            var rr = await applicationDBContext.ToListAsync();
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "محمد",
//                    FatherName = "علي",
//                    GrandFatherName = "سعيد",
//                    FamilyName = "حمد",
//                    Gender = 1,
//                    IdentityNo = "2332434",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "مقبول" }

//            });
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "سعيد",
//                    FatherName = "محمد",
//                    GrandFatherName = "عمر",
//                    FamilyName = "ناصر",
//                    Gender = 1,
//                    IdentityNo = "dsf",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "علي",
//                    FatherName = "عمر",
//                    GrandFatherName = "عمار",
//                    FamilyName = "فهد",
//                    Gender = 1,
//                    IdentityNo = "wre",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "سعيد",
//                    FatherName = "سعد",
//                    GrandFatherName = "سالم",
//                    FamilyName = "سراج",
//                    Gender = 1,
//                    IdentityNo = "sdf",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "صالح",
//                    FatherName = "صديق",
//                    GrandFatherName = "سالم",
//                    FamilyName = "سالم",
//                    Gender = 1,
//                    IdentityNo = "xv",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "فهد",
//                    FatherName = "علي",
//                    GrandFatherName = "عمر",
//                    FamilyName = "علي",
//                    Gender = 1,
//                    IdentityNo = "er",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "عامر",
//                    FatherName = "عمار",
//                    GrandFatherName = "عمر",
//                    FamilyName = "عامر",
//                    Gender = 1,
//                    IdentityNo = "asdf",

//                },
//                RequestStatusId = 1
//                                ,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "سالم",
//                    FatherName = "سليم",
//                    GrandFatherName = "سالم",
//                    FamilyName = "سلامة",
//                    Gender = 1,
//                    IdentityNo = "adfs",

//                },
//                RequestStatusId = 1
//                ,
//                RequestStatus = new RequestStatus() { Name = "جديد" }

//            }); ;


          
//            rr.Add(new EnsuringOrphanRequest()
//            {
//                PersonalDataForm = new Domain.AssociationAffiliatedProjects.Entities.PersonalDataForm()
//                {

//                    FirstName = "سند",
//                    FatherName = "سعيد",
//                    GrandFatherName = "سالم",
//                    FamilyName = "سعد",
//                    Gender = 1,
//                    IdentityNo = "xcv",

//                },
//                RequestStatusId = 1,
//                RequestStatus = new RequestStatus() { Name = "مقبول" }

//            }); ;
       


//            //return View(await applicationDBContext.ToListAsync());
//            return View(rr);
//        }



//        public async Task<IActionResult> Search()
//        {
//            return View();

//        }
//        // GET: AssociationsAffiliated/EnsuringOrphanRequests/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ensuringOrphanRequest = await _context.EnsuringOrphanRequests
//               // .Include(e => e.AssociationAffiliatedProject)
//                .Include(e => e.PersonalDataForm)
//                .Include(e => e.AccommodationData)
//                .Include(e => e.BankDefaultData)
//                .Include(e => e.ContactInformation)
//                .Include(e => e.EducationalData)
//                .Include(e => e.FinanceData)
//                .Include(e => e.HealthStatusData)
//                .Include(e => e.LoanData)
//                .Include(e => e.MaritalStatusData)
//                .Include(e => e.MonthlyIncomeData)
//                .Include(e => e.OccupationData)
//                .Include(e => e.ProjectData)
//                .Include(e => e.RequestStatus)
//                .Include(e => e.ResidencyAddressData)
//                .Include(e => e.SocialSecurityData)
//                .Include(e => e.WorkOnAProjectData)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (ensuringOrphanRequest == null)
//            {
//                return NotFound();
//            }

//            return View(ensuringOrphanRequest);
//        }

//        // GET: AssociationsAffiliated/EnsuringOrphanRequests/Create
//        public IActionResult Create()
//        {
//            ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id");
//            ViewData["PersonalDataFormId"] = new SelectList(_context.PersonalDataForm, "Id", "Id");
//            ViewData["AccommodationDataId"] = new SelectList(_context.AccommodationData, "Id", "Id");
//            ViewData["BankDefaultDataId"] = new SelectList(_context.BankDefaultData, "Id", "Id");
//            ViewData["ContactInformationId"] = new SelectList(_context.ContactInformationData, "Id", "Id");
//            ViewData["EducationalDataId"] = new SelectList(_context.EducationalData, "Id", "Id");
//            ViewData["FinanceDataId"] = new SelectList(_context.FinanceData, "Id", "Id");
//            ViewData["HealthStatusDataId"] = new SelectList(_context.HealthStatusData, "Id", "Id");
//            ViewData["LoanDataId"] = new SelectList(_context.LoanData, "Id", "Id");
//            ViewData["MaritalStatusDataId"] = new SelectList(_context.MaritalStatusData, "Id", "Id");
//            ViewData["MonthlyIncomeDataId"] = new SelectList(_context.MonthlyIncomeData, "Id", "Id");
//            ViewData["OccupationDataId"] = new SelectList(_context.OccupationData, "Id", "Id");
//            ViewData["ProjectDataId"] = new SelectList(_context.ProjectData, "Id", "Id");
//            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "Id");
//            ViewData["ResidencyAddressDataId"] = new SelectList(_context.ResidencyAddressData, "Id", "Id");
//            ViewData["SocialSecurityDataId"] = new SelectList(_context.SocialSecurityData, "Id", "Id");
//            ViewData["WorkOnAProjectDataId"] = new SelectList(_context.WorkOnAProjectData, "Id", "Id");
//            return View();
//        }

//        // POST: AssociationsAffiliated/EnsuringOrphanRequests/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Create([Bind("ContactInformationId,ResidencyAddressDataId,EducationalDataId,HealthStatusDataId,MaritalStatusDataId,OccupationDataId,AccommodationDataId,BankDefaultDataId,FinanceDataId,LoanDataId,MonthlyIncomeDataId,ProjectDataId,SocialSecurityDataId,WorkOnAProjectDataId,RequestStatusId,Id,AssociationAffiliatedProjectId,PersonalDataFormId")] EnsuringOrphanRequest ensuringOrphanRequest)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        _context.Add(ensuringOrphanRequest);
//        //        await _context.SaveChangesAsync();
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    //ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", ensuringOrphanRequest.AssociationAffiliatedProjectId);
//        //    ViewData["PersonalDataFormId"] = new SelectList(_context.PersonalDataForm, "Id", "Id", ensuringOrphanRequest.PersonalDataFormId);
//        //    ViewData["AccommodationDataId"] = new SelectList(_context.AccommodationData, "Id", "Id", ensuringOrphanRequest.AccommodationDataId);
//        //    ViewData["BankDefaultDataId"] = new SelectList(_context.BankDefaultData, "Id", "Id", ensuringOrphanRequest.BankDefaultDataId);
//        //    ViewData["ContactInformationId"] = new SelectList(_context.ContactInformationData, "Id", "Id", ensuringOrphanRequest.ContactInformationId);
//        //    ViewData["EducationalDataId"] = new SelectList(_context.EducationalData, "Id", "Id", ensuringOrphanRequest.EducationalDataId);
//        //    ViewData["FinanceDataId"] = new SelectList(_context.FinanceData, "Id", "Id", ensuringOrphanRequest.FinanceDataId);
//        //    ViewData["HealthStatusDataId"] = new SelectList(_context.HealthStatusData, "Id", "Id", ensuringOrphanRequest.HealthStatusDataId);
//        //    ViewData["LoanDataId"] = new SelectList(_context.LoanData, "Id", "Id", ensuringOrphanRequest.LoanDataId);
//        //    ViewData["MaritalStatusDataId"] = new SelectList(_context.MaritalStatusData, "Id", "Id", ensuringOrphanRequest.MaritalStatusDataId);
//        //    ViewData["MonthlyIncomeDataId"] = new SelectList(_context.MonthlyIncomeData, "Id", "Id", ensuringOrphanRequest.MonthlyIncomeDataId);
//        //    ViewData["OccupationDataId"] = new SelectList(_context.OccupationData, "Id", "Id", ensuringOrphanRequest.OccupationDataId);
//        //    ViewData["ProjectDataId"] = new SelectList(_context.ProjectData, "Id", "Id", ensuringOrphanRequest.ProjectDataId);
//        //    ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "Id", ensuringOrphanRequest.RequestStatusId);
//        //    ViewData["ResidencyAddressDataId"] = new SelectList(_context.ResidencyAddressData, "Id", "Id", ensuringOrphanRequest.ResidencyAddressDataId);
//        //    ViewData["SocialSecurityDataId"] = new SelectList(_context.SocialSecurityData, "Id", "Id", ensuringOrphanRequest.SocialSecurityDataId);
//        //    ViewData["WorkOnAProjectDataId"] = new SelectList(_context.WorkOnAProjectData, "Id", "Id", ensuringOrphanRequest.WorkOnAProjectDataId);
//        //    return View(ensuringOrphanRequest);
//        //}

//        // GET: AssociationsAffiliated/EnsuringOrphanRequests/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ensuringOrphanRequest = await _context.EnsuringOrphanRequests.FindAsync(id);
//            if (ensuringOrphanRequest == null)
//            {
//                return NotFound();
//            }
//            //ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", ensuringOrphanRequest.AssociationAffiliatedProjectId);
//            ViewData["PersonalDataFormId"] = new SelectList(_context.PersonalDataForm, "Id", "Id", ensuringOrphanRequest.PersonalDataFormId);
//            ViewData["AccommodationDataId"] = new SelectList(_context.AccommodationData, "Id", "Id", ensuringOrphanRequest.AccommodationDataId);
//            ViewData["BankDefaultDataId"] = new SelectList(_context.BankDefaultData, "Id", "Id", ensuringOrphanRequest.BankDefaultDataId);
//            ViewData["ContactInformationId"] = new SelectList(_context.ContactInformationData, "Id", "Id", ensuringOrphanRequest.ContactInformationId);
//            ViewData["EducationalDataId"] = new SelectList(_context.EducationalData, "Id", "Id", ensuringOrphanRequest.EducationalDataId);
//            ViewData["FinanceDataId"] = new SelectList(_context.FinanceData, "Id", "Id", ensuringOrphanRequest.FinanceDataId);
//            ViewData["HealthStatusDataId"] = new SelectList(_context.HealthStatusData, "Id", "Id", ensuringOrphanRequest.HealthStatusDataId);
//            ViewData["LoanDataId"] = new SelectList(_context.LoanData, "Id", "Id", ensuringOrphanRequest.LoanDataId);
//            ViewData["MaritalStatusDataId"] = new SelectList(_context.MaritalStatusData, "Id", "Id", ensuringOrphanRequest.MaritalStatusDataId);
//            ViewData["MonthlyIncomeDataId"] = new SelectList(_context.MonthlyIncomeData, "Id", "Id", ensuringOrphanRequest.MonthlyIncomeDataId);
//            ViewData["OccupationDataId"] = new SelectList(_context.OccupationData, "Id", "Id", ensuringOrphanRequest.OccupationDataId);
//            ViewData["ProjectDataId"] = new SelectList(_context.ProjectData, "Id", "Id", ensuringOrphanRequest.ProjectDataId);
//            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "Id", ensuringOrphanRequest.RequestStatusId);
//            ViewData["ResidencyAddressDataId"] = new SelectList(_context.ResidencyAddressData, "Id", "Id", ensuringOrphanRequest.ResidencyAddressDataId);
//            ViewData["SocialSecurityDataId"] = new SelectList(_context.SocialSecurityData, "Id", "Id", ensuringOrphanRequest.SocialSecurityDataId);
//            ViewData["WorkOnAProjectDataId"] = new SelectList(_context.WorkOnAProjectData, "Id", "Id", ensuringOrphanRequest.WorkOnAProjectDataId);
//            return View(ensuringOrphanRequest);
//        }

//        // POST: AssociationsAffiliated/EnsuringOrphanRequests/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public async Task<IActionResult> Edit(int id, [Bind("ContactInformationId,ResidencyAddressDataId,EducationalDataId,HealthStatusDataId,MaritalStatusDataId,OccupationDataId,AccommodationDataId,BankDefaultDataId,FinanceDataId,LoanDataId,MonthlyIncomeDataId,ProjectDataId,SocialSecurityDataId,WorkOnAProjectDataId,RequestStatusId,Id,AssociationAffiliatedProjectId,PersonalDataFormId")] EnsuringOrphanRequest ensuringOrphanRequest)
//        //{
//        //    if (id != ensuringOrphanRequest.Id)
//        //    {
//        //        return NotFound();
//        //    }

//        //    if (ModelState.IsValid)
//        //    {
//        //        try
//        //        {
//        //            _context.Update(ensuringOrphanRequest);
//        //            await _context.SaveChangesAsync();
//        //        }
//        //        catch (DbUpdateConcurrencyException)
//        //        {
//        //            if (!EnsuringOrphanRequestExists(ensuringOrphanRequest.Id))
//        //            {
//        //                return NotFound();
//        //            }
//        //            else
//        //            {
//        //                throw;
//        //            }
//        //        }
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    //ViewData["AssociationAffiliatedProjectId"] = new SelectList(_context.AssociationAffiliatedProjects, "Id", "Id", ensuringOrphanRequest.AssociationAffiliatedProjectId);
//        //    ViewData["PersonalDataFormId"] = new SelectList(_context.PersonalDataForm, "Id", "Id", ensuringOrphanRequest.PersonalDataFormId);
//        //    ViewData["AccommodationDataId"] = new SelectList(_context.AccommodationData, "Id", "Id", ensuringOrphanRequest.AccommodationDataId);
//        //    ViewData["BankDefaultDataId"] = new SelectList(_context.BankDefaultData, "Id", "Id", ensuringOrphanRequest.BankDefaultDataId);
//        //    ViewData["ContactInformationId"] = new SelectList(_context.ContactInformationData, "Id", "Id", ensuringOrphanRequest.ContactInformationId);
//        //    ViewData["EducationalDataId"] = new SelectList(_context.EducationalData, "Id", "Id", ensuringOrphanRequest.EducationalDataId);
//        //    ViewData["FinanceDataId"] = new SelectList(_context.FinanceData, "Id", "Id", ensuringOrphanRequest.FinanceDataId);
//        //    ViewData["HealthStatusDataId"] = new SelectList(_context.HealthStatusData, "Id", "Id", ensuringOrphanRequest.HealthStatusDataId);
//        //    ViewData["LoanDataId"] = new SelectList(_context.LoanData, "Id", "Id", ensuringOrphanRequest.LoanDataId);
//        //    ViewData["MaritalStatusDataId"] = new SelectList(_context.MaritalStatusData, "Id", "Id", ensuringOrphanRequest.MaritalStatusDataId);
//        //    ViewData["MonthlyIncomeDataId"] = new SelectList(_context.MonthlyIncomeData, "Id", "Id", ensuringOrphanRequest.MonthlyIncomeDataId);
//        //    ViewData["OccupationDataId"] = new SelectList(_context.OccupationData, "Id", "Id", ensuringOrphanRequest.OccupationDataId);
//        //    ViewData["ProjectDataId"] = new SelectList(_context.ProjectData, "Id", "Id", ensuringOrphanRequest.ProjectDataId);
//        //    ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "Id", ensuringOrphanRequest.RequestStatusId);
//        //    ViewData["ResidencyAddressDataId"] = new SelectList(_context.ResidencyAddressData, "Id", "Id", ensuringOrphanRequest.ResidencyAddressDataId);
//        //    ViewData["SocialSecurityDataId"] = new SelectList(_context.SocialSecurityData, "Id", "Id", ensuringOrphanRequest.SocialSecurityDataId);
//        //    ViewData["WorkOnAProjectDataId"] = new SelectList(_context.WorkOnAProjectData, "Id", "Id", ensuringOrphanRequest.WorkOnAProjectDataId);
//        //    return View(ensuringOrphanRequest);
//        //}

//        // GET: AssociationsAffiliated/EnsuringOrphanRequests/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var ensuringOrphanRequest = await _context.EnsuringOrphanRequests
//               // .Include(e => e.AssociationAffiliatedProject)
//                .Include(e => e.PersonalDataForm)
//                .Include(e => e.AccommodationData)
//                .Include(e => e.BankDefaultData)
//                .Include(e => e.ContactInformation)
//                .Include(e => e.EducationalData)
//                .Include(e => e.FinanceData)
//                .Include(e => e.HealthStatusData)
//                .Include(e => e.LoanData)
//                .Include(e => e.MaritalStatusData)
//                .Include(e => e.MonthlyIncomeData)
//                .Include(e => e.OccupationData)
//                .Include(e => e.ProjectData)
//                .Include(e => e.RequestStatus)
//                .Include(e => e.ResidencyAddressData)
//                .Include(e => e.SocialSecurityData)
//                .Include(e => e.WorkOnAProjectData)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (ensuringOrphanRequest == null)
//            {
//                return NotFound();
//            }

//            return View(ensuringOrphanRequest);
//        }

//        // POST: AssociationsAffiliated/EnsuringOrphanRequests/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var ensuringOrphanRequest = await _context.EnsuringOrphanRequests.FindAsync(id);
//            _context.EnsuringOrphanRequests.Remove(ensuringOrphanRequest);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool EnsuringOrphanRequestExists(int id)
//        {
//            return _context.EnsuringOrphanRequests.Any(e => e.Id == id);
//        }
//    }
//}
