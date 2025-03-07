using AVM.ClientGenerator.Optimisers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Optimisers
{
    public interface IOptimiser
    {
        void LineAdded(IEnumerable<CompiledLine> codeBlockLines, ICompilerMemento compiler);

        void ChildScopeEntered();

        void ChildScopeExited();

    }
}
