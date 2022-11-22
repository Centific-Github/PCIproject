using System;
using System.Runtime.Serialization;

namespace PCIapi.Controllers
{
    [Serializable]
    internal class NotImplemetedException : Exception
    {
        public NotImplemetedException()
        {
        }

        public NotImplemetedException(string message) : base(message)
        {
        }

        public NotImplemetedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotImplemetedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}