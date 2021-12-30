// <copyright file="Enablesignaturekeyrequest.cs" company="APIMatic">
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
    /// Enablesignaturekeyrequest.
    /// </summary>
    public class Enablesignaturekeyrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enablesignaturekeyrequest"/> class.
        /// </summary>
        public Enablesignaturekeyrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enablesignaturekeyrequest"/> class.
        /// </summary>
        /// <param name="keyId">key_id.</param>
        public Enablesignaturekeyrequest(
            string keyId)
        {
            this.KeyId = keyId;
        }

        /// <summary>
        /// Gets or sets KeyId.
        /// </summary>
        [JsonProperty("key_id")]
        public string KeyId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Enablesignaturekeyrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Enablesignaturekeyrequest other &&
                ((this.KeyId == null && other.KeyId == null) || (this.KeyId?.Equals(other.KeyId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.KeyId = {(this.KeyId == null ? "null" : this.KeyId == string.Empty ? "" : this.KeyId)}");
        }
    }
}