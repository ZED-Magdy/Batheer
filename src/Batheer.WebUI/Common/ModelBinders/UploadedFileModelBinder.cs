using Batheer.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Common.ModelBinders
{
    public class UploadedFileModelBinder : IModelBinder
    {
        //https://schwabencode.com/blog/2019/12/06/AspNetCore-Custom-Model-Binder
        //https://stackoverflow.com/questions/40116160/custom-model-binding-in-asp-net-core


        /// <summary>
        /// Expression to map IFormFile object type to CommonFile
        /// </summary>
        private readonly Func<IFormFile, UploadedFile> _expression;

        public UploadedFileModelBinder()
        {
            _expression = formFile =>
            {
                byte[] bytes = null;

                using (BinaryReader br = new BinaryReader(formFile.OpenReadStream()))
                {
                    bytes = br.ReadBytes((int)formFile.OpenReadStream().Length);
                }

                return new UploadedFile()
                {
                    FileName = formFile.FileName,
                    ContentType = formFile.ContentType,
                    Content = bytes
                };
            };
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            UploadedFile model;
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var formFiles = bindingContext.ActionContext.HttpContext.Request.Form.Files;
            if (!formFiles.Any()) return Task.CompletedTask;

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            //if (valueProviderResult == ValueProviderResult.None)
            //{
            //    return Task.CompletedTask;
            //}
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);


            model = formFiles
                .Where(w=> w.Name == modelName)
                .AsParallel()
                .Select(_expression)
                .FirstOrDefault();


            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;

        }
    }

    public class FormFileModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(UploadedFile))
            {
                return new BinderTypeModelBinder(typeof(UploadedFileModelBinder));
            }

            return null;
        }
    }
}
