// <copyright file="Addoneormorenumberstoyourbacklistresponse.cs" company="APIMatic">
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
    /// Addoneormorenumberstoyourbacklistresponse.
    /// </summary>
    public class Addoneormorenumberstoyourbacklistresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Addoneormorenumberstoyourbacklistresponse"/> class.
        /// </summary>
        public Addoneormorenumberstoyourbacklistresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Addoneormorenumberstoyourbacklistresponse"/> class.
        /// </summary>
        /// <param name="uri">uri.</param>
        /// <param name="numbers">numbers.</param>
        public Addoneormorenumberstoyourbacklistresponse(
            string uri,
            List<string> numbers)
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
        public List<string> Numbers { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Addoneormorenumberstoyourbacklistresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is Addoneormorenumberstoyourbacklistresponse other &&
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
            toStringOutput.Add($"this.Numbers = {(this.Numbers == null ? "null" : $"[{string.Join(", ", this.Numbers)} ]")}");
        }
    }
}