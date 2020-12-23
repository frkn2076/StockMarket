using System;

namespace StockMarket.Helper {
    public class DefinedException : Exception {
        public string errorCode { get; set; }
        public DefinedException(string errorCode, string message, Exception innerException = null) : base(message, innerException) {
            this.errorCode = errorCode;
        }
    }

    public class ExpectedTypeNotFound : DefinedException {
        public ExpectedTypeNotFound(string message, Exception innerException = null) : base("Err-0001", message, innerException) {
        }
    }
    public class ExternalServiceError : DefinedException {
        public ExternalServiceError(string message, Exception innerException = null) : base("Err-0002", message, innerException) {
        }
    }
    public class DataExtractionError : DefinedException {
        public DataExtractionError(string message, Exception innerException = null) : base("Err-0003", message, innerException) {
        }
    }
}
