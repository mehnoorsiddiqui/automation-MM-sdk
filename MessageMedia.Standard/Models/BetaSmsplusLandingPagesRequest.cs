// <copyright file="BetaSmsplusLandingPagesRequest.cs" company="APIMatic">
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
    /// BetaSmsplusLandingPagesRequest.
    /// </summary>
    public class BetaSmsplusLandingPagesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BetaSmsplusLandingPagesRequest"/> class.
        /// </summary>
        public BetaSmsplusLandingPagesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BetaSmsplusLandingPagesRequest"/> class.
        /// </summary>
        /// <param name="body">body.</param>
        public BetaSmsplusLandingPagesRequest(
            Models.CreateLandingPage body)
        {
            this.Body = body;
        }

        /// <summary>
        /// Gets or sets Body.
        /// </summary>
        [JsonProperty("body")]
        public Models.CreateLandingPage Body { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BetaSmsplusLandingPagesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BetaSmsplusLandingPagesRequest other &&
                ((this.Body == null && other.Body == null) || (this.Body?.Equals(other.Body) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Body = {(this.Body == null ? "null" : this.Body.ToString())}");
        }
    }
}