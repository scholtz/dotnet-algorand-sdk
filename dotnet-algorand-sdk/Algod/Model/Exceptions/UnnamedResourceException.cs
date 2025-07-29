using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Exceptions
{
    public class UnnamedResourceException : System.Exception
    {
        public SimulateUnnamedResourcesAccessed SimulateUnnamedResourcesAccessed { get; private set; }
        public UnnamedResourceException(SimulateUnnamedResourcesAccessed simulateUnnamedResourcesAccessed) : base("Unnamed resource exception occurred")
        {
            SimulateUnnamedResourcesAccessed = simulateUnnamedResourcesAccessed;
        }
    }
}
