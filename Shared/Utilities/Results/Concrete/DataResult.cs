using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
         public DataResult(ResultStatus resultStatus,T data)
        {
            resultStatus = ResultStatus;
            Data = data;
        }
        public T Data { get; }

        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
        }

        public DataResult(T data, ResultStatus resultStatus, string message)
        {
            Data = data;
            ResultStatus = resultStatus;
            Message = message;
        }

       

      
    }
}
