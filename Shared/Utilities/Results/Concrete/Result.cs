﻿using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus =resultStatus;
        }
        public Result(ResultStatus resultStatus,string message)
        {
            ResultStatus = resultStatus;
            Message = message;
        }
        public Result(ResultStatus resultStatus, string message,Exception exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
