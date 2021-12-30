// <copyright file="Fields.cs" company="APIMatic">
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
    /// Fields.
    /// </summary>
    public class Fields
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fields"/> class.
        /// </summary>
        public Fields()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fields"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="bodyText">bodyText.</param>
        /// <param name="ctaUrl">ctaUrl.</param>
        public Fields(
            Models.Title title,
            Models.BodyText bodyText,
            Models.CtaUrl ctaUrl)
        {
            this.Title = title;
            this.BodyText = bodyText;
            this.CtaUrl = ctaUrl;
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public Models.Title Title { get; set; }

        /// <summary>
        /// Gets or sets BodyText.
        /// </summary>
        [JsonProperty("bodyText")]
        public Models.BodyText BodyText { get; set; }

        /// <summary>
        /// Gets or sets CtaUrl.
        /// </summary>
        [JsonProperty("ctaUrl")]
        public Models.CtaUrl CtaUrl { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Fields : ({string.Join(", ", toStringOutput)})";
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

            return obj is Fields other &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.BodyText == null && other.BodyText == null) || (this.BodyText?.Equals(other.BodyText) == true)) &&
                ((this.CtaUrl == null && other.CtaUrl == null) || (this.CtaUrl?.Equals(other.CtaUrl) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title.ToString())}");
            toStringOutput.Add($"this.BodyText = {(this.BodyText == null ? "null" : this.BodyText.ToString())}");
            toStringOutput.Add($"this.CtaUrl = {(this.CtaUrl == null ? "null" : this.CtaUrl.ToString())}");
        }
    }
}