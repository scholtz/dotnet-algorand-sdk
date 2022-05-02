

namespace Algorand.V2.Algod.Model
{
    public enum OnCompletion
    {
        [System.Runtime.Serialization.EnumMember(Value = @"noop")]
        Noop = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"optin")]
        Optin = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"closeout")]
        Closeout = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"clear")]
        Clear = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"update")]
        Update = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"delete")]
        Delete = 5,

    }
}
