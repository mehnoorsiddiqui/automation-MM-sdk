// <copyright file="GetTemplatesFieldsDefinationresponse.cs" company="APIMatic">
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
    /// GetTemplatesFieldsDefinationresponse.
    /// </summary>
    public class GetTemplatesFieldsDefinationresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTemplatesFieldsDefinationresponse"/> class.
        /// </summary>
        public GetTemplatesFieldsDefinationresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTemplatesFieldsDefinationresponse"/> class.
        /// </summary>
        /// <param name="fields">fields.</param>
        public GetTemplatesFieldsDefinationresponse(
            Models.Fields2 fields)
        {
            this.Fields = fields;
        }

        /// <summary>
        /// Gets or sets Fields.
        /// </summary>
        [JsonProperty("fields")]
        public Models.Fields2 Fields { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetTemplatesFieldsDefinationresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is GetTemplatesFieldsDefinationresponse other &&
                ((this.Fields == null && other.Fields == null) || (this.Fields?.Equals(other.Fields) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Fields = {(this.Fields == null ? "null" : this.Fields.ToString())}");
        }
    }
}