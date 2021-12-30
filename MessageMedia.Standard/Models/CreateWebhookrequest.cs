// <copyright file="CreateWebhookrequest.cs" company="APIMatic">
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
    /// CreateWebhookrequest.
    /// </summary>
    public class CreateWebhookrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWebhookrequest"/> class.
        /// </summary>
        public CreateWebhookrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWebhookrequest"/> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="method">method.</param>
        /// <param name="encoding">encoding.</param>
        /// <param name="headers">headers.</param>
        /// <param name="events">events.</param>
        /// <param name="template">template.</param>
        public CreateWebhookrequest(
            string url,
            string method,
            string encoding,
            Models.Headers headers,
            List<string> events,
            string template)
        {
            this.Url = url;
            this.Method = method;
            this.Encoding = encoding;
            this.Headers = headers;
            this.Events = events;
            this.Template = template;
        }

        /// <summary>
        /// The configured URL which will trigger the webhook when a selected event occurs.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The methods to map CRUD (create, retrieve, update, delete) operations to HTTP requests.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Webhooks can be delivered using different content types. You can choose from ```JSON```, ```FORM_ENCODED``` or ```XML```. This will automatically add the Content-Type header for you so you don't have to add it again in the `headers` property.
        /// </summary>
        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        /// <summary>
        /// Gets or sets Headers.
        /// </summary>
        [JsonProperty("headers")]
        public Models.Headers Headers { get; set; }

        /// <summary>
        /// Event or events that will trigger the webhook. Atleast one event should be present.
        /// </summary>
        [JsonProperty("events")]
        public List<string> Events { get; set; }

        /// <summary>
        /// The structure of the payload that will be returned. You can format this in JSON or XML.
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateWebhookrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateWebhookrequest other &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Method == null && other.Method == null) || (this.Method?.Equals(other.Method) == true)) &&
                ((this.Encoding == null && other.Encoding == null) || (this.Encoding?.Equals(other.Encoding) == true)) &&
                ((this.Headers == null && other.Headers == null) || (this.Headers?.Equals(other.Headers) == true)) &&
                ((this.Events == null && other.Events == null) || (this.Events?.Equals(other.Events) == true)) &&
                ((this.Template == null && other.Template == null) || (this.Template?.Equals(other.Template) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Url = {(this.Url == null ? "null" : this.Url == string.Empty ? "" : this.Url)}");
            toStringOutput.Add($"this.Method = {(this.Method == null ? "null" : this.Method == string.Empty ? "" : this.Method)}");
            toStringOutput.Add($"this.Encoding = {(this.Encoding == null ? "null" : this.Encoding == string.Empty ? "" : this.Encoding)}");
            toStringOutput.Add($"this.Headers = {(this.Headers == null ? "null" : this.Headers.ToString())}");
            toStringOutput.Add($"this.Events = {(this.Events == null ? "null" : $"[{string.Join(", ", this.Events)} ]")}");
            toStringOutput.Add($"this.Template = {(this.Template == null ? "null" : this.Template == string.Empty ? "" : this.Template)}");
        }
    }
}