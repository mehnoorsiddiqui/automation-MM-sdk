// <copyright file="UpdateWebhookrequest.cs" company="APIMatic">
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
    /// UpdateWebhookrequest.
    /// </summary>
    public class UpdateWebhookrequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebhookrequest"/> class.
        /// </summary>
        public UpdateWebhookrequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebhookrequest"/> class.
        /// </summary>
        /// <param name="url">url.</param>
        /// <param name="method">method.</param>
        /// <param name="encoding">encoding.</param>
        /// <param name="events">events.</param>
        /// <param name="template">template.</param>
        public UpdateWebhookrequest(
            string url,
            string method,
            string encoding,
            List<string> events,
            string template)
        {
            this.Url = url;
            this.Method = method;
            this.Encoding = encoding;
            this.Events = events;
            this.Template = template;
        }

        /// <summary>
        /// Gets or sets Url.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets Method.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets Encoding.
        /// </summary>
        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        /// <summary>
        /// Gets or sets Events.
        /// </summary>
        [JsonProperty("events")]
        public List<string> Events { get; set; }

        /// <summary>
        /// Gets or sets Template.
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWebhookrequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateWebhookrequest other &&
                ((this.Url == null && other.Url == null) || (this.Url?.Equals(other.Url) == true)) &&
                ((this.Method == null && other.Method == null) || (this.Method?.Equals(other.Method) == true)) &&
                ((this.Encoding == null && other.Encoding == null) || (this.Encoding?.Equals(other.Encoding) == true)) &&
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
            toStringOutput.Add($"this.Events = {(this.Events == null ? "null" : $"[{string.Join(", ", this.Events)} ]")}");
            toStringOutput.Add($"this.Template = {(this.Template == null ? "null" : this.Template == string.Empty ? "" : this.Template)}");
        }
    }
}