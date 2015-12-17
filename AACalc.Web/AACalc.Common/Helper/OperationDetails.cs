using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACalc.Common.Helper
{
    public class OperationDetails
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public int InsertedRowId { get; set; }
        public string CssClass { get; set; }

        public OperationDetails() { }

        public OperationDetails(bool success, string message, Exception exception)
            : this(success, message, exception, 0)
        {
        }

        public OperationDetails(bool success, string message, Exception exception, int insertedRowId)
        {
            Success = success;
            Message = message;
            Exception = exception;
            InsertedRowId = insertedRowId;
        }

    }
}
