using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Core.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)]
    public class SmartSignatureMethodAttribute : System.Attribute
    {
        internal OnCompleteType callType;
        internal string identifier;

        public SmartSignatureMethodAttribute(string identifier="")
        {
            this.identifier = identifier;
            
        }
    }
}
