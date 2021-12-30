// <copyright file="Createsignaturekeyrequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace MessageMedia.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MessageMedia.Standard;
    using MessageMedia.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Createsignaturekeyrequest.
    /// </summary>
    public class Createsignaturekeyrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Createsignaturekeyrequest"/> class.
        /// </summary>
        public Createsignaturekeyrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Createsignaturekeyrequest"/> class.
        /// </summary>
        /// <param name="digest">digest.</param>
        /// <param name="cipher">cipher.</param>
        public Createsignaturekeyrequest(
            string digest,
            string cipher)
        {
            this.Digest = digest;
            this.Cipher = cipher;
        }

        /// <summary>
        /// To hash the message. The valid values for digest type are: ```SHA224```, ```SHA256```, ```SHA512```
        /// </summary>
        [JsonProperty("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// To encrypt the hashed message. The valid value for cipher type is: ```RSA```
        /// </summary>
        [JsonProperty("cipher")]
        public string Cipher { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Createsignaturekeyrequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is Createsignaturekeyrequest other &&
                ((this.Digest == null && other.Digest == null) || (this.Digest?.Equals(other.Digest) == true)) &&
                ((this.Cipher == null && other.Cipher == null) || (this.Cipher?.Equals(other.Cipher) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Digest = {(this.Digest == null ? "null" : this.Digest == string.Empty ? "" : this.Digest)}");
            toStringOutput.Add($"this.Cipher = {(this.Cipher == null ? "null" : this.Cipher == string.Empty ? "" : this.Cipher)}");
        }
    }
}