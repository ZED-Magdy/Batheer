using Batheer.Application.Common.Mappings;
using Batheer.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Common.ModelBinders
{
    //https://abdus.dev/posts/aspnetcore-model-binding-json-query-params/
    public class GoogleMapValuesDtoModelBinder : IModelBinder
    {
        //https://schwabencode.com/blog/2019/12/06/AspNetCore-Custom-Model-Binder
        //https://stackoverflow.com/questions/40116160/custom-model-binding-in-asp-net-core


        /// <summary>
        /// Expression to map IFormFile object type to CommonFile
        /// </summary>
        private readonly Func<string, GoogleMapValuesDto> _expression;

        public GoogleMapValuesDtoModelBinder()
        {
            _expression = jsonString =>
            {
                var rr = JsonConvert.DeserializeObject<GoogleMapValuesDto>(jsonString);

                return rr;
            };
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            GoogleMapValuesDto model;
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);


            model = JsonConvert.DeserializeObject<GoogleMapValuesDto>(valueProviderResult.FirstValue);


            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;

        }
    }

    public class GoogleMapValuesDtoModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(GoogleMapValuesDto))
            {
                return new BinderTypeModelBinder(typeof(GoogleMapValuesDtoModelBinder));
            }

            return null;
        }
    }
}
