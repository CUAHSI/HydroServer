using System;
using System.Collections.Generic;
using System.Text;

namespace WaterOneFlowImpl
{
    public class WaterOneFlowServerException : global::System.Exception
    {
               public WaterOneFlowServerException() { }
        public WaterOneFlowServerException(string message) : base(message) { }
        public WaterOneFlowServerException(string message, global::System.Exception inner) : base(message, inner) { }
        protected WaterOneFlowServerException(
          global::System.Runtime.Serialization.SerializationInfo info,
          global::System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
