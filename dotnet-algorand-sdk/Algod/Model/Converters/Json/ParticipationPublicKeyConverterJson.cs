using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorand.Algod.Model.Converters.Json
{
    public class ParticipationPublicKeyConverterJson : JsonConverter<ParticipationPublicKey>
    {
        public override ParticipationPublicKey ReadJson(JsonReader reader, Type objectType, ParticipationPublicKey existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var base64 = (string)reader.Value;
            var bytes = Convert.FromBase64String(base64);
            return new ParticipationPublicKey(bytes);
        }

        public override void WriteJson(JsonWriter writer, ParticipationPublicKey value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToBase64String(value.Bytes));
        }
    }
}
