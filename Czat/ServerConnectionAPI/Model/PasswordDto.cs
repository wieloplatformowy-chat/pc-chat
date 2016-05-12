using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Czat.ServerConnectionAPI.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PasswordDto : IEquatable<PasswordDto>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordDto" /> class.
        /// Initializes a new instance of the <see cref="PasswordDto" />class.
        /// </summary>
        /// <param name="Password">Password (required).</param>

        public PasswordDto(string Password = null)
        {
            // to ensure "Password" is required (not null)
            if (Password == null)
            {
                throw new InvalidDataException("Password is a required property for PasswordDto and cannot be null");
            }
            else
            {
                this.Password = Password;
            }

        }


        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PasswordDto {\n");
            sb.Append("  Password: ").Append(Password).Append("\n");

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
            return this.Equals(obj as PasswordDto);
        }

        /// <summary>
        /// Returns true if PasswordDto instances are equal
        /// </summary>
        /// <param name="other">Instance of PasswordDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PasswordDto other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return
                (
                    this.Password == other.Password ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
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

                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();

                return hash;
            }
        }

    }
}
