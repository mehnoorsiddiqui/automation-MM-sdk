// <copyright file="CreateNewCampaignresponse.cs" company="APIMatic">
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
    /// CreateNewCampaignresponse.
    /// </summary>
    public class CreateNewCampaignresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewCampaignresponse"/> class.
        /// </summary>
        public CreateNewCampaignresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateNewCampaignresponse"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="templateId">template_id.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="message">message.</param>
        public CreateNewCampaignresponse(
            string id,
            string templateId,
            Models.Parameters parameters,
            Models.Message message)
        {
            this.Id = id;
            this.TemplateId = templateId;
            this.Parameters = parameters;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets TemplateId.
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or sets Parameters.
        /// </summary>
        [JsonProperty("parameters")]
        public Models.Parameters Parameters { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        [JsonProperty("message")]
        public Models.Message Message { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateNewCampaignresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateNewCampaignresponse other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
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
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.TemplateId = {(this.TemplateId == null ? "null" : this.TemplateId == string.Empty ? "" : this.TemplateId)}");
            toStringOutput.Add($"this.Parameters = {(this.Parameters == null ? "null" : this.Parameters.ToString())}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message.ToString())}");
        }
    }
}