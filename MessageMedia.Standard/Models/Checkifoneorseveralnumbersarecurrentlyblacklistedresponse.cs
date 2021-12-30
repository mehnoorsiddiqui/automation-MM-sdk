// <copyright file="Checkifoneorseveralnumbersarecurrentlyblacklistedresponse.cs" company="APIMatic">
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
    /// Checkifoneorseveralnumbersarecurrentlyblacklistedresponse.
    /// </summary>
    public class Checkifoneorseveralnumbersarecurrentlyblacklistedresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkifoneorseveralnumbersarecurrentlyblacklistedresponse"/> class.
        /// </summary>
        public Checkifoneorseveralnumbersarecurrentlyblacklistedresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkifoneorseveralnumbersarecurrentlyblacklistedresponse"/> class.
        /// </summary>
        /// <param name="uri">uri.</param>
        /// <param name="numbers">numbers.</param>
        public Checkifoneorseveralnumbersarecurrentlyblacklistedresponse(
            string uri,
            object numbers)
        {
            this.Uri = uri;
            this.Numbers = numbers;
        }

        /// <summary>
        /// Gets or sets Uri.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets Numbers.
        /// </summary>
        [JsonProperty("numbers")]
        public object Numbers { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Checkifoneorseveralnumbersarecurrentlyblacklistedresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Checkifoneorseveralnumbersarecurrentlyblacklistedresponse other &&
                ((this.Uri == null && other.Uri == null) || (this.Uri?.Equals(other.Uri) == true)) &&
                ((this.Numbers == null && other.Numbers == null) || (this.Numbers?.Equals(other.Numbers) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uri = {(this.Uri == null ? "null" : this.Uri == string.Empty ? "" : this.Uri)}");
            toStringOutput.Add($"Numbers = {(this.Numbers == null ? "null" : this.Numbers.ToString())}");
        }
    }
}