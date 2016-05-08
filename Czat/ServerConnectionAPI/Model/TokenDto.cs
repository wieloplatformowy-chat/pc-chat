using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Czat.ServerConnectionAPI.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class TokenDto :  IEquatable<TokenDto>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenDto" /> class.
        /// Initializes a new instance of the <see cref="TokenDto" />class.
        /// </summary>
        /// <param name="Token">Token (required).</param>

        public TokenDto(string Token = null)
        {
            // to ensure "Token" is required (not null)
            if (Token == null)
            {
                throw new InvalidDataException("Token is a required property for TokenDto and cannot be null");
            }
            else
            {
                this.Token = Token;
            }
            
        }
        
    
        /// <summary>
        /// Gets or Sets Token
        /// </summary>
        [DataMember(Name="token", EmitDefaultValue=false)]
        public string Token { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TokenDto {\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as TokenDto);
        }

        /// <summary>
        /// Returns true if TokenDto instances are equal
        /// </summary>
        /// <param name="other">Instance of TokenDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenDto other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Token == other.Token ||
                    this.Token != null &&
                    this.Token.Equals(other.Token)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.Token != null)
                    hash = hash * 59 + this.Token.GetHashCode();
                
                return hash;
            }
        }

    }
}
