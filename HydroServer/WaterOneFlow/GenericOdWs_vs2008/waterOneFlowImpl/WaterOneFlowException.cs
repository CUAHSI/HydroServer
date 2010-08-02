using System;
using System.Collections.Generic;
using System.Text;

namespace WaterOneFlowImpl
{
    [global::System.Serializable]
    public class WaterOneFlowException : global::System.Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public WaterOneFlowException() { }
        public WaterOneFlowException(string message) : base(message) { }
        public WaterOneFlowException(string message, global::System.Exception inner) : base(message, inner) { }
        protected WaterOneFlowException(
          global::System.Runtime.Serialization.SerializationInfo info,
          global::System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
