using System;
using System.Collections.Generic;
using System.Text;

namespace WaterOneFlowImpl
{
   /// <summary>
    /// WaterOneFlowSourceException occurs when a data source is not available.
   /// </summary>
 [global::System.Serializable]
    public class WaterOneFlowSourceException : global::System.Net.WebException
    {
          public WaterOneFlowSourceException() { }
        public WaterOneFlowSourceException(string message) : base(message) { }
        public WaterOneFlowSourceException(string message, global::System.Exception inner) : base(message, inner) { }
        protected WaterOneFlowSourceException(
          global::System.Runtime.Serialization.SerializationInfo info,
          global::System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
