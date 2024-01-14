using Batheer.Application.Common.Security;
using Batheer.Application.Reports.Queries.GetSummaryForAssociationsAffiliatedId;
using Batheer.Application.Reports.Queries.SearchInFamilies;
using Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests;
using Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "AdminRole")]

    public class ReportsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        #region #SearchInFamilies
        public IActionResult SearchInFamilies()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchInFamilies(SearchInFamiliesQuery query)
        {
            var model = await Mediator.Send(query);

            ViewBag.QueryResult = model;
            return View();
        }

        [HttpPost]
        public async Task<FileResult> SearchInFamiliesExport(SearchInFamiliesExportQuery query)
        {
            var vm = await Mediator.Send(query);

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        #endregion

        #region #SearchInFamilyRegistrationRequests
        public IActionResult SearchInFamilyRegistrationRequests()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchInFamilyRegistrationRequests(SearchInFamilyRegistrationRequestsQuery query)
        {
            var model = await Mediator.Send(query);

            ViewBag.QueryResult = model;
            return View();
        }

        [HttpPost]
        public async Task<FileResult> SearchInFamilyRegistrationRequestsExport(SearchInFamilyRegistrationRequestsExportQuery query)
        {
            var vm = await Mediator.Send(query);

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        #endregion


        #region #SearchInSupportingFamilyRequests
        public IActionResult SearchInSupportingFamilyRequests()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchInSupportingFamilyRequests(SearchInSupportingFamilyRequestsQuery query)
        {
            var model = await Mediator.Send(query);

            ViewBag.QueryResult = model;
            return View();
        }

        [HttpPost]
        public async Task<FileResult> SearchInSupportingFamilyRequestsExport(SearchInSupportingFamilyRequestsExportQuery query)
        {
            var vm = await Mediator.Send(query);

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
        #endregion

        #region GetSummaryForAssociationsAffiliatedIdQuery

        public IActionResult SummaryForAssociationsAffiliated()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SummaryForAssociationsAffiliated(GetSummaryForAssociationsAffiliatedIdQuery query)
        {
            var model = await Mediator.Send(query);

            ViewBag.QueryResult = model;
            return View();
        }
        #endregion
    }
}
