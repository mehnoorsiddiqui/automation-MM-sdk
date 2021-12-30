// <copyright file="GetTemplatesresponse.cs" company="APIMatic">
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
    /// GetTemplatesresponse.
    /// </summary>
    public class GetTemplatesresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTemplatesresponse"/> class.
        /// </summary>
        public GetTemplatesresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTemplatesresponse"/> class.
        /// </summary>
        /// <param name="templates">templates.</param>
        /// <param name="pagination">pagination.</param>
        public GetTemplatesresponse(
            List<Models.Template> templates,
            Models.Pagination2 pagination)
        {
            this.Templates = templates;
            this.Pagination = pagination;
        }

        /// <summary>
        /// Gets or sets Templates.
        /// </summary>
        [JsonProperty("templates")]
        public List<Models.Template> Templates { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination")]
        public Models.Pagination2 Pagination { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetTemplatesresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is GetTemplatesresponse other &&
                ((this.Templates == null && other.Templates == null) || (this.Templates?.Equals(other.Templates) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Templates = {(this.Templates == null ? "null" : $"[{string.Join(", ", this.Templates)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}