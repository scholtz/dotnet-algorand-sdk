using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Core.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)]
    public class InnerTransactionCallAttribute : System.Attribute
    {
      

        public InnerTransactionCallAttribute()
        {
       
        }
    }
}
