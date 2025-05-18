using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVM.ClientGenerator.ABI.ARC4.Types
{
    public class String : VariableArray<Byte>, IEquatable<String>
    {
        public String() : base()
        {
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as String);
        }

        public bool Equals(String other)
        {
            return !(other is null) &&
                   IsDynamic == other.IsDynamic &&
                   EqualityComparer<List<Byte>>.Default.Equals(Value, other.Value) &&
                   IsDynamic == other.IsDynamic;
        }

        public override int GetHashCode()
        {
            int hashCode = 1616527590;
            hashCode = hashCode * -1521134295 + IsDynamic.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Byte>>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + IsDynamic.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(Value.Select(v => (byte)v.ToValue()).ToArray());
        }

        public static bool operator ==(String left, String right)
        {
            return EqualityComparer<String>.Default.Equals(left, right);
        }

        public static bool operator !=(String left, String right)
        {
            return !(left == right);
        }
    }
}
