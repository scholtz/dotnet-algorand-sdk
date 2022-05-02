using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Algorand.V2.Algod.Model.Transactions
{
    internal class CommittedApplicationCloseOutTransaction : CommittedApplicationCallTransaction

    {

        public CommittedApplicationCloseOutTransaction() : base(new ApplicationCloseOutTransaction()) { }

      


        

    }
}
