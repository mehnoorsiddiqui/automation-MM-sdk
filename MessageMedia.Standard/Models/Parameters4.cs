// <copyright file="Parameters4.cs" company="APIMatic">
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
    /// Parameters4.
    /// </summary>
    public class Parameters4
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters4"/> class.
        /// </summary>
        public Parameters4()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters4"/> class.
        /// </summary>
        /// <param name="pageTitle">pageTitle.</param>
        /// <param name="pageText">pageText.</param>
        /// <param name="callToAction">callToAction.</param>
        public Parameters4(
            string pageTitle,
            string pageText,
            string callToAction)
        {
            this.PageTitle = pageTitle;
            this.PageText = pageText;
            this.CallToAction = callToAction;
        }

        /// <summary>
        /// Gets or sets PageTitle.
        /// </summary>
        [JsonProperty("pageTitle")]
        public string PageTitle { get; set; }

        /// <summary>
        /// Gets or sets PageText.
        /// </summary>
        [JsonProperty("pageText")]
        public string PageText { get; set; }

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

            return $"Parameters4 : ({string.Join(", ", toStringOutput)})";
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

            return obj is Parameters4 other &&
                ((this.PageTitle == null && other.PageTitle == null) || (this.PageTitle?.Equals(other.PageTitle) == true)) &&
                ((this.PageText == null && other.PageText == null) || (this.PageText?.Equals(other.PageText) == true)) &&
                ((this.CallToAction == null && other.CallToAction == null) || (this.CallToAction?.Equals(other.CallToAction) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PageTitle = {(this.PageTitle == null ? "null" : this.PageTitle == string.Empty ? "" : this.PageTitle)}");
            toStringOutput.Add($"this.PageText = {(this.PageText == null ? "null" : this.PageText == string.Empty ? "" : this.PageText)}");
            toStringOutput.Add($"this.CallToAction = {(this.CallToAction == null ? "null" : this.CallToAction == string.Empty ? "" : this.CallToAction)}");
        }
    }
}