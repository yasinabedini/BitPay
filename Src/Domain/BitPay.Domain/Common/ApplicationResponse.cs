using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPay.Domain.Common
{
    public class ApplicationResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string Message { get; set; }
        public string? Warning { get; set; }
        public T Result { get; set; }
    }

    public class ApplicationResponse
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string Message { get; set; }
        public string? Warning { get; set; }
    }
}
