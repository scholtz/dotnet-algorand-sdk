using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorand.ARC4.ABI.Types
{
    public class Address
    {
        private string Value { get; set; }
        /// <summary>
        /// AVM encoded address
        /// </summary>
        /// <param name="address"></param>
        public Address(string address)
        {
            Value = address;
        }
    }
}
