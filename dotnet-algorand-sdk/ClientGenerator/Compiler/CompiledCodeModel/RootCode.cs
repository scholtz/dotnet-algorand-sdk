﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Compiler.CompiledCodeModel
{
    internal abstract class RootCode : CodeBuilder
    {
        protected RootCode(Scope associatedScope)
        {
            AssociatedScope = associatedScope;
        }

        internal Scope AssociatedScope { get; set; }
    }
}
