// <copyright file="Campaign.cs" company="APIMatic">
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
    /// Campaign.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Campaign"/> class.
        /// </summary>
        public Campaign()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Campaign"/> class.
        /// </summary>
        /// <param name="templateId">template_id.</param>
        /// <param name="message">message.</param>
        /// <param name="parameters">parameters.</param>
        public Campaign(
            string templateId,
            Models.MessageTemplate message,
            object parameters = null)
        {
            this.TemplateId = templateId;
            this.Parameters = parameters;
            this.Message = message;
        }

        /// <summary>
        /// Template to use for the landing page
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Parameters to use for the landing page and the message content
        /// </summary>
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public object Parameters { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonProperty("message")]
        public Models.MessageTemplate Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Campaign : ({string.Join(", ", toStringOutput)})";
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

            return obj is Campaign other &&
                ((this.TemplateId == null && other.TemplateId == null) || (this.TemplateId?.Equals(other.TemplateId) == true)) &&
                ((this.Parameters == null && other.Parameters == null) || (this.Parameters?.Equals(other.Parameters) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TemplateId = {(this.TemplateId == null ? "null" : this.TemplateId == string.Empty ? "" : this.TemplateId)}");
            toStringOutput.Add($"Parameters = {(this.Parameters == null ? "null" : this.Parameters.ToString())}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message.ToString())}");
        }
    }
}