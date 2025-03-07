using System;
using System.Collections.Generic;
using System.Text;

namespace AVM.ClientGenerator.Compiler
{

   
    internal enum PredefinedSubroutines
    {
        ConvertDecimalMantissaToUBigInteger,
        ConvertScaleSignAndResultToDecimal,
        RescaleDecimal,
        CastLongAndSignByteToDecimal,
        CastUnsignedLongToDecimal,
        ConvertDecimalToInteger,
    }
}
