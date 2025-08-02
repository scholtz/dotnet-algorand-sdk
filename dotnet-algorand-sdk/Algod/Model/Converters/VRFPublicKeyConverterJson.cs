using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters
{
    public class VRFPublicKeyConverterJson : JsonConverter<VRFPublicKey>
    {
        public override VRFPublicKey ReadJson(JsonReader reader, Type objectType, VRFPublicKey existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;
            var bytes = Convert.FromBase64String(base64);
            return new VRFPublicKey(bytes);
        }

        public override void WriteJson(JsonWriter writer, VRFPublicKey value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToBase64String(value.Bytes));
        }
    }
}
