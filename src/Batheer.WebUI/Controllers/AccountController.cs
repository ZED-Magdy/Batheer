using Batheer.Application.Common.Interfaces;
using Batheer.Application.Modules.UserAccess.Login;
using Batheer.Application.Modules.UserAccess.Logout;
using Batheer.Infrastructure.Persistence;
using Batheer.WebUI.Areas;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Batheer.WebUI.Controllers
{
    public class AccountController : BaseController
    {


        public ActionResult Login()
        {
            return View(new LoginRequest());
        }
        public ActionResult AccessDenied()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest command)
        {

            if (ModelState.IsValid)
            {
                var response = await Mediator.Send(command);
                return RedirectToAction("", "", new { area = response.ReturnUrl });
            }

            return View(command);
        }


        public async Task<ActionResult> Logout(string returnUrl = null)
        {
            var command = new LogoutRequest();

            await Mediator.Send(command);

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("", "");
            }
        }

    }
}