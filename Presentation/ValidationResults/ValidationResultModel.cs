using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Presentation.ValidationResults
{
    public class ValidationResultModel
    {
        public string Message { get; set; }
        
        public Dictionary<string, string[]> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = EntidadeNaoProcessavelException.DefaultMessage;
            Errors = modelState.Keys.ToDictionary(key => key.ToString(),
                key => modelState[key].Errors.Select(e => e.ErrorMessage.ToString()).ToArray());
        }   
    }
}