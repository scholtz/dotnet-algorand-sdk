using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Crypto.Parameters;
using System.IO;
using Newtonsoft.Msgpack;
using Algorand.V2.Algod.Model;

namespace Algorand.Utils
{
    /// <summary>
    /// Convenience class for serializing and deserializing arbitrary objects to json or msgpack.
    /// </summary>
    public static class Encoder
    {        
        /// <summary>
        /// Convenience method for serializing arbitrary objects.
        /// </summary>
        /// <param name="o">the object to serializing</param>
        /// <returns>serialized object</returns>
        public static byte[] EncodeToMsgPack(object o)
        {
            MemoryStream memoryStream = new MemoryStream();
            JsonSerializer serializer = new JsonSerializer()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = AlgorandContractResolver.Instance,
                Formatting = Formatting.None
            };

            MessagePackWriter writer = new MessagePackWriter(memoryStream);            
            serializer.Serialize(writer, o);
            var bytes = memoryStream.ToArray();
            return bytes;
        }

        /// <summary>
        /// Convenience method for deserializing arbitrary objects encoded with canonical msg-pack
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="input">input byte array representing canonical msg-pack encoding</param>
        /// <returns>deserialized object</returns>
        public static T DecodeFromMsgPack<T>(byte[] input)
        {
            MemoryStream st = new MemoryStream(input);
            //memoryStream.Write(input, 0, input.Length);
            //memoryStream.Seek(0, SeekOrigin.Begin);
            JsonSerializer serializer = new JsonSerializer()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.None
            };
            MessagePackReader reader = new MessagePackReader(st);
            return serializer.Deserialize<T>(reader);
            //return DecodeFromJson<T>(MessagePackSerializer.ConvertToJson(input));
        }
        
        /// <summary>
        /// Encode an object as json.
        /// </summary>
        /// <param name="o">object to encode</param>
        /// <returns>json string</returns>
        public static string EncodeToJson(object o)
        {
            var settings = new JsonSerializerSettings()
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.None
            };
            var ostr = JsonConvert.SerializeObject(o, settings);
            return ostr;
        }
        /// <summary>
        /// Decode a json string to an object.
        /// </summary>
        /// <typeparam name="T">object type</typeparam>
        /// <param name="json">json string</param>
        /// <returns>object</returns>
        public static T DecodeFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Convenience method for writing bytes as hex.
        /// </summary>
        /// <param name="bytes">bytes input to encodeToMsgPack as hex string</param>
        /// <returns>encoded hex string</returns>
        public static string EncodeToHexStr(byte[] bytes)
        {
            return BitConverter.ToString(bytes, 0).Replace("-", string.Empty).ToLower();
        }        

        /// <summary>
        /// Convenience method to get a value as a big-endian byte array
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] ToBigEndianBytes(this ulong val)
        {
            var bytes = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian) //depends on hardware
                Array.Reverse(bytes);
            
            return bytes;
        }
    }

  
}
