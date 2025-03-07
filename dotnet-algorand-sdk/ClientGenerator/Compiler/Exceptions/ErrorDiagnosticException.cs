using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Compiler.Exceptions
{
    internal class ErrorDiagnosticException : DiagnosticException
    {
        internal ErrorDiagnosticException(string diagnostic) : base(diagnostic) { }
        
    }
}
