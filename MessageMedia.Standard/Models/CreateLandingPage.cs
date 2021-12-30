// <copyright file="CreateLandingPage.cs" company="APIMatic">
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
    /// CreateLandingPage.
    /// </summary>
    public class CreateLandingPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLandingPage"/> class.
        /// </summary>
        public CreateLandingPage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLandingPage"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="templateId">template_id.</param>
        /// <param name="parameters">parameters.</param>
        /// <param name="fields">fields.</param>
        public CreateLandingPage(
            string name,
            string templateId,
            object parameters = null,
            object fields = null)
        {
            this.Name = name;
            this.TemplateId = templateId;
            this.Parameters = parameters;
            this.Fields = fields;
        }

        /// <summary>
        /// Landing Page name. Maximum 100 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Template to use for the landing page.
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// Parameters to use for the landing page and the message content.
        /// </summary>
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public object Parameters { get; set; }

        /// <summary>
        /// Define the fields that have been used to the paramters.
        /// </summary>
        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public object Fields { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLandingPage : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateLandingPage other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.TemplateId == null && other.TemplateId == null) || (this.TemplateId?.Equals(other.TemplateId) == true)) &&
                ((this.Parameters == null && other.Parameters == null) || (this.Parameters?.Equals(other.Parameters) == true)) &&
                ((this.Fields == null && other.Fields == null) || (this.Fields?.Equals(other.Fields) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.TemplateId = {(this.TemplateId == null ? "null" : this.TemplateId == string.Empty ? "" : this.TemplateId)}");
            toStringOutput.Add($"Parameters = {(this.Parameters == null ? "null" : this.Parameters.ToString())}");
            toStringOutput.Add($"Fields = {(this.Fields == null ? "null" : this.Fields.ToString())}");
        }
    }
}