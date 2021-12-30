// <copyright file="RetrieveWebhookResponse.cs" company="APIMatic">
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
    /// RetrieveWebhookResponse.
    /// </summary>
    public class RetrieveWebhookResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveWebhookResponse"/> class.
        /// </summary>
        public RetrieveWebhookResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveWebhookResponse"/> class.
        /// </summary>
        /// <param name="page">page.</param>
        /// <param name="pageSize">pageSize.</param>
        /// <param name="pageData">pageData.</param>
        public RetrieveWebhookResponse(
            int page,
            int pageSize,
            List<Models.PageDatum> pageData)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.PageData = pageData;
        }

        /// <summary>
        /// Gets or sets Page.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets PageSize.
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets PageData.
        /// </summary>
        [JsonProperty("pageData")]
        public List<Models.PageDatum> PageData { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveWebhookResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveWebhookResponse other &&
                this.Page.Equals(other.Page) &&
                this.PageSize.Equals(other.PageSize) &&
                ((this.PageData == null && other.PageData == null) || (this.PageData?.Equals(other.PageData) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Page = {this.Page}");
            toStringOutput.Add($"this.PageSize = {this.PageSize}");
            toStringOutput.Add($"this.PageData = {(this.PageData == null ? "null" : $"[{string.Join(", ", this.PageData)} ]")}");
        }
    }
}