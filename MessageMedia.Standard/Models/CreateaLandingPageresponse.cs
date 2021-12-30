// <copyright file="CreateaLandingPageresponse.cs" company="APIMatic">
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
    /// CreateaLandingPageresponse.
    /// </summary>
    public class CreateaLandingPageresponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateaLandingPageresponse"/> class.
        /// </summary>
        public CreateaLandingPageresponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateaLandingPageresponse"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="templateId">template_id.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="fields">fields.</param>
        /// <param name="createdTimestamp">created_timestamp.</param>
        /// <param name="modifiedTimestamp">modified_timestamp.</param>
        public CreateaLandingPageresponse(
            string id,
            string name,
            string templateId,
            Models.Parameters parameters,
            Models.Fields fields,
            string createdTimestamp,
            string modifiedTimestamp)
        {
            this.Id = id;
            this.Name = name;
            this.TemplateId = templateId;
            this.Parameters = parameters;
            this.Fields = fields;
            this.CreatedTimestamp = createdTimestamp;
            this.ModifiedTimestamp = modifiedTimestamp;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

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
        /// Gets or sets Fields.
        /// </summary>
        [JsonProperty("fields")]
        public Models.Fields Fields { get; set; }

        /// <summary>
        /// Gets or sets CreatedTimestamp.
        /// </summary>
        [JsonProperty("created_timestamp")]
        public string CreatedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets ModifiedTimestamp.
        /// </summary>
        [JsonProperty("modified_timestamp")]
        public string ModifiedTimestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateaLandingPageresponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateaLandingPageresponse other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.TemplateId == null && other.TemplateId == null) || (this.TemplateId?.Equals(other.TemplateId) == true)) &&
                ((this.Parameters == null && other.Parameters == null) || (this.Parameters?.Equals(other.Parameters) == true)) &&
                ((this.Fields == null && other.Fields == null) || (this.Fields?.Equals(other.Fields) == true)) &&
                ((this.CreatedTimestamp == null && other.CreatedTimestamp == null) || (this.CreatedTimestamp?.Equals(other.CreatedTimestamp) == true)) &&
                ((this.ModifiedTimestamp == null && other.ModifiedTimestamp == null) || (this.ModifiedTimestamp?.Equals(other.ModifiedTimestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.TemplateId = {(this.TemplateId == null ? "null" : this.TemplateId == string.Empty ? "" : this.TemplateId)}");
            toStringOutput.Add($"this.Parameters = {(this.Parameters == null ? "null" : this.Parameters.ToString())}");
            toStringOutput.Add($"this.Fields = {(this.Fields == null ? "null" : this.Fields.ToString())}");
            toStringOutput.Add($"this.CreatedTimestamp = {(this.CreatedTimestamp == null ? "null" : this.CreatedTimestamp == string.Empty ? "" : this.CreatedTimestamp)}");
            toStringOutput.Add($"this.ModifiedTimestamp = {(this.ModifiedTimestamp == null ? "null" : this.ModifiedTimestamp == string.Empty ? "" : this.ModifiedTimestamp)}");
        }
    }
}