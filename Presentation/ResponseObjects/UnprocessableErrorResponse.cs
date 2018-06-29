using System.Collections.Generic;
using System.Net;

namespace Presentation.ResponseObjects
{
    public class UnprocessableErrorResponse : DefaultResponse
    {   
        public Dictionary<string, string[]> Errors { get; set; }
    }
}