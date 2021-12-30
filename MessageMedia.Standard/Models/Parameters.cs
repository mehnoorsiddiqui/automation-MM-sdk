// <copyright file="Parameters.cs" company="APIMatic">
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
    /// Parameters.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        public Parameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        /// <param name="title">title.</param>
        /// <param name="bodyText">bodyText.</param>
        /// <param name="callToAction">callToAction.</param>
        public Parameters(
            string title,
            string bodyText,
            string callToAction)
        {
            this.Title = title;
            this.BodyText = bodyText;
            this.CallToAction = callToAction;
        }

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets BodyText.
        /// </summary>
        [JsonProperty("bodyText")]
        public string BodyText { get; set; }

        /// <summary>
        /// Gets or sets CallToAction.
        /// </summary>
        [JsonProperty("callToAction")]
        public string CallToAction { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Parameters : ({string.Join(", ", toStringOutput)})";
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

            return obj is Parameters other &&
                ((this.Title == null && other.Title == null) || (this.Title?.Equals(other.Title) == true)) &&
                ((this.BodyText == null && other.BodyText == null) || (this.BodyText?.Equals(other.BodyText) == true)) &&
                ((this.CallToAction == null && other.CallToAction == null) || (this.CallToAction?.Equals(other.CallToAction) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Title = {(this.Title == null ? "null" : this.Title == string.Empty ? "" : this.Title)}");
            toStringOutput.Add($"this.BodyText = {(this.BodyText == null ? "null" : this.BodyText == string.Empty ? "" : this.BodyText)}");
            toStringOutput.Add($"this.CallToAction = {(this.CallToAction == null ? "null" : this.CallToAction == string.Empty ? "" : this.CallToAction)}");
        }
    }
}