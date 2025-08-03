using Algorand.Algod.Model.Transactions;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Algorand.Algod.Model.Converters.MsgPack
{

    /// <summary>
    /// Implements a MessagePack formatter that leaves out object properties that have their default
    /// value, as well as properties marked as ignored.
    /// </summary>
    /// <remarks>
    /// Workaround for https://github.com/MessagePack-CSharp/MessagePack-CSharp/issues/678
    /// 
    /// https://github.com/Rafaeruo/pkl-csharp/blob/9cd4d725fa7e254b73fe322630edd1df04f79f89/Pkl/InternalMsgApi/NoDefaultsFormatter.cs
    /// </remarks>
    /// <typeparam name="T">The type to format.</typeparam>
    public class NoDefaultsFormatter<T> : IMessagePackFormatter<T>
    {
        /// <summary>
        /// Serializes the object.
        /// </summary>
        public void Serialize(ref MessagePackWriter writer, T value, MessagePackSerializerOptions options)
        {
            var dict = new Dictionary<string, object?>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.GetCustomAttribute<IgnoreMemberAttribute>() != null)
                {
                    continue;
                }

                var propValue = property.GetValue(value);
                // TODO: maybe add an attribute such as "OmitEmpty" or "OmitDefault" 
                // to flag which properties should be ommited when with default values
                if (property.PropertyType != typeof(bool) && object.Equals(propValue, GetDefault(property.PropertyType)))
                {
                    continue;
                }

                var name = property.Name;

                var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                if (keyAttribute != null && keyAttribute.StringKey != null)
                {
                    name = keyAttribute.StringKey;
                }
                if (propValue is ulong ulongValue)
                {
                    if (ulongValue < byte.MaxValue)
                    {
                        dict[name] = Convert.ToByte(ulongValue);
                    }
                    if (ulongValue < UInt16.MaxValue)
                    {
                        dict[name] = Convert.ToUInt16(ulongValue);
                    }
                    else if (ulongValue < UInt32.MaxValue)
                    {
                        dict[name] = Convert.ToUInt32(ulongValue);
                    }
                    else
                    {
                        dict[name] = ulongValue;
                    }
                }
                else
                {
                    if (propValue is Algorand.Signature objSgn)
                    {
                        dict[name] = objSgn.Bytes;
                    }
                    else if (propValue is Algorand.Address objAddress)
                    {
                        dict[name] = objAddress.Bytes;
                    }
                    else if (propValue is Algorand.Digest objDigest)
                    {
                        dict[name] = objDigest.Bytes;
                    }
                    else if (propValue is Algorand.ParticipationPublicKey objParticipationPublicKey)
                    {
                        dict[name] = objParticipationPublicKey.Bytes;
                    }
                    else if (propValue is Algorand.TEALProgram objTEALProgram)
                    {
                        dict[name] = objTEALProgram.Bytes;
                    }
                    else if (propValue is Algorand.VRFPublicKey objVRFPublicKey)
                    {
                        dict[name] = objVRFPublicKey.Bytes;
                    }
                    else
                    {
                        dict[name] = propValue;
                    }
                }
            }

            // sort dict
            dict = dict
                .OrderBy(kvp => kvp.Key, StringComparer.Ordinal)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            options.Resolver.GetFormatterWithVerify<Dictionary<string, object?>>().Serialize(ref writer, dict, options);
        }

        /// <summary>
        /// Deserializes the object.
        /// </summary>
        public T Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return default!;
            }
            var dict = options.Resolver.GetFormatterWithVerify<Dictionary<object, object?>>().Deserialize(ref reader, options);
            var instance = dict.Deserialize<T>();
            return instance;
        }

        private static object? GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
    public static class Deserializer
    {
        public static T Deserialize<T>(this Dictionary<object, object?> dict)
        {
            var instance = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanWrite) continue;
                if (property.GetCustomAttribute<IgnoreMemberAttribute>() != null)
                {
                    continue;
                }
                var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                var name = keyAttribute?.StringKey ?? property.Name;
                if (dict.TryGetValue(name, out var value))
                {
                    switch (property.PropertyType.FullName)
                    {
                        case "Algorand.Algod.Model.Transactions.Transaction":
                            var txDict = value as Dictionary<object, object?>;
                            switch (txDict["type"])
                            {
                                case "acfg":
                                    property.SetValue(instance, txDict.Deserialize<AssetConfigurationTransaction>());
                                    break;
                                case "afrz":
                                    property.SetValue(instance, txDict.Deserialize<AssetFreezeTransaction>());
                                    break;
                                case "appl":
                                    property.SetValue(instance, txDict.Deserialize<ApplicationCallTransaction>());
                                    break;
                                case "axfer":
                                    property.SetValue(instance, txDict.Deserialize<AssetTransferTransaction>());
                                    break;
                                case "hb":
                                    property.SetValue(instance, txDict.Deserialize<HeartBeatTransaction>());
                                    break;
                                case "keyreg":
                                    property.SetValue(instance, txDict.Deserialize<KeyRegistrationTransaction>());
                                    break;
                                case "pay":
                                    property.SetValue(instance, txDict.Deserialize<PaymentTransaction>());
                                    break;
                                case "stpf":
                                    property.SetValue(instance, txDict.Deserialize<StateProofTransaction>());
                                    break;
                            }
                            break;
                        case "Algorand.Signature":
                            property.SetValue(instance, new Algorand.Signature(value as byte[]));
                            break;
                        case "Algorand.Address":
                            property.SetValue(instance, new Algorand.Address(value as byte[]));
                            break;
                        case "Algorand.Digest":
                            property.SetValue(instance, new Algorand.Digest(value as byte[]));
                            break;
                        case "Algorand.ParticipationPublicKey":
                            property.SetValue(instance, new Algorand.ParticipationPublicKey(value as byte[]));
                            break;
                        case "Algorand.TEALProgram":
                            property.SetValue(instance, new Algorand.TEALProgram(value as byte[]));
                            break;
                        case "Algorand.VRFPublicKey":
                            property.SetValue(instance, new Algorand.VRFPublicKey(value as byte[]));
                            break;
                        default:
                            property.SetValue(instance, value);
                            break;
                    }
                }
            }
            return instance;
        }
    }
}
