using MessagePack;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Algorand.Algod.Model.Transactions
{
    [MessagePackObject(AllowPrivate = true)]
    public partial class KeyRegisterOfflineTransaction : KeyRegistrationTransaction
    {
    
    }
}
