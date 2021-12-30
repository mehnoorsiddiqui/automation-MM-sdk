// <copyright file="Createsignaturekeyresponse.cs" company="APIMatic">
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
    /// Createsignaturekeyresponse.
    /// </summary>
    public class Createsignaturekeyresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Createsignaturekeyresponse"/> class.
        /// </summary>
        public Createsignaturekeyresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Createsignaturekeyresponse"/> class.
        /// </summary>
        /// <param name="keyId">key_id.</param>
        /// <param name="publicKey">public_key.</param>
        /// <param name="cipher">cipher.</param>
        /// <param name="digest">digest.</param>
        /// <param name="created">created.</param>
        /// <param name="enabled">enabled.</param>
        public Createsignaturekeyresponse(
            string keyId,
            string publicKey,
            string cipher,
            string digest,
            string created,
            bool enabled)
        {
            this.KeyId = keyId;
            this.PublicKey = publicKey;
            this.Cipher = cipher;
            this.Digest = digest;
            this.Created = created;
            this.Enabled = enabled;
        }

        /// <summary>
        /// Gets or sets KeyId.
        /// </summary>
        [JsonProperty("key_id")]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets PublicKey.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Gets or sets Cipher.
        /// </summary>
        [JsonProperty("cipher")]
        public string Cipher { get; set; }

        /// <summary>
        /// Gets or sets Digest.
        /// </summary>
        [JsonProperty("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// Gets or sets Created.
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets Enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Createsignaturekeyresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Createsignaturekeyresponse other &&
                ((this.KeyId == null && other.KeyId == null) || (this.KeyId?.Equals(other.KeyId) == true)) &&
                ((this.PublicKey == null && other.PublicKey == null) || (this.PublicKey?.Equals(other.PublicKey) == true)) &&
                ((this.Cipher == null && other.Cipher == null) || (this.Cipher?.Equals(other.Cipher) == true)) &&
                ((this.Digest == null && other.Digest == null) || (this.Digest?.Equals(other.Digest) == true)) &&
                ((this.Created == null && other.Created == null) || (this.Created?.Equals(other.Created) == true)) &&
                this.Enabled.Equals(other.Enabled);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.KeyId = {(this.KeyId == null ? "null" : this.KeyId == string.Empty ? "" : this.KeyId)}");
            toStringOutput.Add($"this.PublicKey = {(this.PublicKey == null ? "null" : this.PublicKey == string.Empty ? "" : this.PublicKey)}");
            toStringOutput.Add($"this.Cipher = {(this.Cipher == null ? "null" : this.Cipher == string.Empty ? "" : this.Cipher)}");
            toStringOutput.Add($"this.Digest = {(this.Digest == null ? "null" : this.Digest == string.Empty ? "" : this.Digest)}");
            toStringOutput.Add($"this.Created = {(this.Created == null ? "null" : this.Created == string.Empty ? "" : this.Created)}");
            toStringOutput.Add($"this.Enabled = {this.Enabled}");
        }
    }
}