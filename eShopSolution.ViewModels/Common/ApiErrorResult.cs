using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }
        public  ApiErrorResult( string messgae)
        {
            IsSuccessed = false;
            Message = messgae;
        }
        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
        public ApiErrorResult()
        { }
    }
}
