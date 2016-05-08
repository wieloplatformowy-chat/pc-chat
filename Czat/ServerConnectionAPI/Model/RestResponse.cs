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
    public partial class RestResponse :  IEquatable<RestResponse>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RestResponse" /> class.
        /// Initializes a new instance of the <see cref="RestResponse" />class.
        /// </summary>
        /// <param name="Response">Response (required).</param>

        public RestResponse(string Response = null)
        {
            // to ensure "Response" is required (not null)
            if (Response == null)
            {
                throw new InvalidDataException("Response is a required property for RestResponse and cannot be null");
            }
            else
            {
                this.Response = Response;
            }
            
        }
        
    
        /// <summary>
        /// Gets or Sets Response
        /// </summary>
        [DataMember(Name="response", EmitDefaultValue=false)]
        public string Response { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RestResponse {\n");
            sb.Append("  Response: ").Append(Response).Append("\n");
            
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
            return this.Equals(obj as RestResponse);
        }

        /// <summary>
        /// Returns true if RestResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RestResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RestResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Response == other.Response ||
                    this.Response != null &&
                    this.Response.Equals(other.Response)
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
                
                if (this.Response != null)
                    hash = hash * 59 + this.Response.GetHashCode();
                
                return hash;
            }
        }

    }
}
