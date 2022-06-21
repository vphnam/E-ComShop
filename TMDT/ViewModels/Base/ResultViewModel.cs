using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDT.ViewModels.Base
{
    public enum StatusCode
    {
        OK = 200,
        Error = 500
    }
    public class ResultViewModel<T>
    {
        public StatusCode Status { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
        public ResultViewModel(StatusCode status, string message, T data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
        public ResultViewModel(StatusCode status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
