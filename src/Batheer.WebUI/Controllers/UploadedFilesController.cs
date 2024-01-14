using Batheer.Application.UploadedFiles.Queries.GetByObjectKey;
using Batheer.WebUI.Areas;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer,Cookies"
        /*$"{JwtBearerDefaults.AuthenticationScheme}, {CookieAuthenticationDefaults.AuthenticationScheme}"*/
        )]

    public class UploadedFilesController : BaseController
    {
        public async Task<ActionResult> GetByObjectKey(Guid objectKey)
        {
            //https://www.c-sharpcorner.com/article/implementing-cqrs-pattern-with-vue-js-asp-net-core-mvc/
            try
            {
                var imageResponse = await Mediator.Send(new GetByObjectKeyQuery(objectKey));



                string imgBase64Data = Convert.ToBase64String(imageResponse.Content);
                string imgDataURL = string.Format("data:{0};base64,{1}",
                    imageResponse.ContentType, imgBase64Data);

                return Json(new { status = "OK", imgData = imgDataURL });
            }
            catch (Exception ex)
            {
                return Json(new { status = "Error", message = ex.Message });
            }
        }

        //[ResponseCache(Duration = 300, Location = ResponseCacheLocation.None, NoStore = true, VaryByQueryKeys = new string[] { "objectKey" })]
        //[ResponseCache(Duration = 360, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult> ShowByObjectKey(Guid objectKey)
        {
            //https://www.c-sharpcorner.com/article/implementing-cqrs-pattern-with-vue-js-asp-net-core-mvc/
            try
            {
                if (objectKey == Guid.Empty)
                {
                    var myfile = System.IO.File.ReadAllBytes("wwwroot/UploadedFile_not_available.jpg");
                    return File(myfile, "image/jpeg");
                }

                var imageResponse = await Mediator.Send(new GetByObjectKeyQuery(objectKey));
                if (imageResponse.DefaultFilePath is not null)
                {
                    var myfile = System.IO.File.ReadAllBytes(imageResponse.DefaultFilePath);
                    return File(myfile, imageResponse.ContentType);
                }

                return File(imageResponse.Content, imageResponse.ContentType);


            }
            catch (Exception ex)
            {
                return Json(new { status = "Error", message = ex.Message });
            }
        }
    }
}
