using Batheer.Application.Common.Interfaces;
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

namespace Batheer.WebUI.Areas.Researcher.Controllers
{
    [Area("Researcher")]
    [Authorize(Roles = "Researcher")]

    public class HomeController : BaseController
    {
        private readonly IApplicationDbContext _context;
        private readonly IQueryExecuter _queryExecuter;

        public HomeController(IApplicationDbContext context, IQueryExecuter queryExecuter)
        {
            _context = context;
            _queryExecuter = queryExecuter;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SearchByIdentityNo(string IdentityNo)
        {
            ViewBag.IdentityNo = IdentityNo;
            return View();
        }
    }
}
