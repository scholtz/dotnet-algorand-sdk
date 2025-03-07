using AVM.ClientGenerator.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Compiler.Predefineds
{
    internal interface IArrayTypePredefined : ITypePredefined
    {
        void GetAtIndex();
        void SetAtIndex();
    }
}
