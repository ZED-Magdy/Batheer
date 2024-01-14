using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models;
using Batheer.Application.Common.Models.Settings;
using Batheer.Application.ContactUs.SendEmail.Commands;
using Batheer.WebUI.Areas;
using Batheer.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, IApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }


        public string FixUploadFiles(int take = 1000)
        {
            downloadFilesToServer(take);
            return "done.";
        }


        private void downloadFilesToServer(int take)
        {
            var items = _dbContext.UploadedFiles
                .Where(w => w.DefaultFilePath == null)
                .Where(w => w.Content != null)
                .Take(take)
                .ToList();

            items.ForEach(f =>
            {
                var filenameWithExt = f.ObjectKey.ToString() + System.IO.Path.GetExtension(f.FileName);
                var filenameWithExt_path = "_UploadedFiles/" + filenameWithExt;
                System.IO.File.WriteAllBytes(filenameWithExt_path, f.Content);

                f.DefaultFilePath = filenameWithExt_path;
                f.Content = null;
                _dbContext.SaveChangesAsync(System.Threading.CancellationToken.None).Wait();
            });
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsModel contactUsModel)
        {
            _logger.LogInformation("ContactUs", contactUsModel);


            var command = new SendEmailCommand()
            {
                Email = contactUsModel.Email,
                Message = contactUsModel.Message,
                Name = contactUsModel.Name,
                Subject = contactUsModel.Subject
            };

            var model = await Mediator.Send(command);

            ViewBag.Sent = true;

            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult AssociationAffiliateds()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { BaseRequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult StartSite()
        {
            return View();
        }
    }
}
