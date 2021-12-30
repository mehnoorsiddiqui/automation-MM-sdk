// <copyright file="Getsignaturekeydetailresponse.cs" company="APIMatic">
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
    /// Getsignaturekeydetailresponse.
    /// </summary>
    public class Getsignaturekeydetailresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Getsignaturekeydetailresponse"/> class.
        /// </summary>
        public Getsignaturekeydetailresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Getsignaturekeydetailresponse"/> class.
        /// </summary>
        /// <param name="keyId">key_id.</param>
        /// <param name="cipher">cipher.</param>
        /// <param name="digest">digest.</param>
        /// <param name="created">created.</param>
        /// <param name="enabled">enabled.</param>
        public Getsignaturekeydetailresponse(
            string keyId = null,
            string cipher = null,
            string digest = null,
            string created = null,
            bool? enabled = null)
        {
            this.KeyId = keyId;
            this.Cipher = cipher;
            this.Digest = digest;
            this.Created = created;
            this.Enabled = enabled;
        }

        /// <summary>
        /// Gets or sets KeyId.
        /// </summary>
        [JsonProperty("key_id", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets Cipher.
        /// </summary>
        [JsonProperty("cipher", NullValueHandling = NullValueHandling.Ignore)]
        public string Cipher { get; set; }

        /// <summary>
        /// Gets or sets Digest.
        /// </summary>
        [JsonProperty("digest", NullValueHandling = NullValueHandling.Ignore)]
        public string Digest { get; set; }

        /// <summary>
        /// Gets or sets Created.
        /// </summary>
        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets Enabled.
        /// </summary>
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Getsignaturekeydetailresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Getsignaturekeydetailresponse other &&
                ((this.KeyId == null && other.KeyId == null) || (this.KeyId?.Equals(other.KeyId) == true)) &&
                ((this.Cipher == null && other.Cipher == null) || (this.Cipher?.Equals(other.Cipher) == true)) &&
                ((this.Digest == null && other.Digest == null) || (this.Digest?.Equals(other.Digest) == true)) &&
                ((this.Created == null && other.Created == null) || (this.Created?.Equals(other.Created) == true)) &&
                ((this.Enabled == null && other.Enabled == null) || (this.Enabled?.Equals(other.Enabled) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.KeyId = {(this.KeyId == null ? "null" : this.KeyId == string.Empty ? "" : this.KeyId)}");
            toStringOutput.Add($"this.Cipher = {(this.Cipher == null ? "null" : this.Cipher == string.Empty ? "" : this.Cipher)}");
            toStringOutput.Add($"this.Digest = {(this.Digest == null ? "null" : this.Digest == string.Empty ? "" : this.Digest)}");
            toStringOutput.Add($"this.Created = {(this.Created == null ? "null" : this.Created == string.Empty ? "" : this.Created)}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
        }
    }
}