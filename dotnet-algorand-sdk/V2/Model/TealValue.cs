/* 
 * Algod REST API.
 *
 * API endpoint for algod operations.
 *
 * OpenAPI spec version: 0.0.1
 * Contact: contact@algorand.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Algorand.Client.SwaggerDateConverter;

namespace Algorand.V2.Model
{
    /// <summary>
    /// Represents a TEAL value.
    /// </summary>
    [DataContract]
    public partial class TealValue :  IEquatable<TealValue>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TealValue" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TealValue() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TealValue" /> class.
        /// </summary>
        /// <param name="type">\\[tt\\] value type. (required).</param>
        /// <param name="bytes">\\[tb\\] bytes value. (required).</param>
        /// <param name="_uint">\\[ui\\] uint value. (required).</param>
        public TealValue(long? type = default, string bytes = default(string), ulong? _uint = default(ulong?))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for TealValue and cannot be null");
            }
            else
            {
                this.Type = type;
            }
            // to ensure "bytes" is required (not null)
            if (bytes == null)
            {
                throw new InvalidDataException("bytes is a required property for TealValue and cannot be null");
            }
            else
            {
                this.Bytes = bytes;
            }
            // to ensure "_uint" is required (not null)
            if (_uint == null)
            {
                throw new InvalidDataException("_uint is a required property for TealValue and cannot be null");
            }
            else
            {
                this.Uint = _uint;
            }
        }
        
        /// <summary>
        /// \\[tt\\] value type.
        /// </summary>
        /// <value>\\[tt\\] value type.</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public long? Type { get; set; }

        /// <summary>
        /// \\[tb\\] bytes value.
        /// </summary>
        /// <value>\\[tb\\] bytes value.</value>
        [DataMember(Name="bytes", EmitDefaultValue=false)]
        public string Bytes { get; set; }

        /// <summary>
        /// \\[ui\\] uint value.
        /// </summary>
        /// <value>\\[ui\\] uint value.</value>
        [DataMember(Name="uint", EmitDefaultValue=false)]
        public ulong? Uint { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TealValue {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Bytes: ").Append(Bytes).Append("\n");
            sb.Append("  Uint: ").Append(Uint).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as TealValue);
        }

        /// <summary>
        /// Returns true if TealValue instances are equal
        /// </summary>
        /// <param name="input">Instance of TealValue to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TealValue input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Bytes == input.Bytes ||
                    (this.Bytes != null &&
                    this.Bytes.Equals(input.Bytes))
                ) && 
                (
                    this.Uint == input.Uint ||
                    (this.Uint != null &&
                    this.Uint.Equals(input.Uint))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Bytes != null)
                    hashCode = hashCode * 59 + this.Bytes.GetHashCode();
                if (this.Uint != null)
                    hashCode = hashCode * 59 + this.Uint.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}