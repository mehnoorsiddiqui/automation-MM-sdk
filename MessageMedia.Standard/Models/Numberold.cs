// <copyright file="Numberold.cs" company="APIMatic">
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
    /// Numberold.
    /// </summary>
    public class Numberold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Numberold"/> class.
        /// </summary>
        public Numberold()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Numberold"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="authorised">authorised.</param>
        public Numberold(
            string number,
            bool authorised)
        {
            this.Number = number;
            this.Authorised = authorised;
        }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets Authorised.
        /// </summary>
        [JsonProperty("authorised")]
        public bool Authorised { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Numberold : ({string.Join(", ", toStringOutput)})";
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

            return obj is Numberold other &&
                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                this.Authorised.Equals(other.Authorised);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number == string.Empty ? "" : this.Number)}");
            toStringOutput.Add($"this.Authorised = {this.Authorised}");
        }
    }
}