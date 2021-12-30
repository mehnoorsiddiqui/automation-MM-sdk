// <copyright file="MessageMLP.cs" company="APIMatic">
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
    /// MessageMLP.
    /// </summary>
    public class MessageMLP
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMLP"/> class.
        /// </summary>
        public MessageMLP()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageMLP"/> class.
        /// </summary>
        /// <param name="content">content.</param>
        /// <param name="metadata">metadata.</param>
        public MessageMLP(
            string content,
            Dictionary<string, string> metadata)
        {
            this.Content = content;
            this.Metadata = metadata;
        }

        /// <summary>
        /// Gets or sets Content.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets Metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MessageMLP : ({string.Join(", ", toStringOutput)})";
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

            return obj is MessageMLP other &&
                ((this.Content == null && other.Content == null) || (this.Content?.Equals(other.Content) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Content = {(this.Content == null ? "null" : this.Content == string.Empty ? "" : this.Content)}");
            toStringOutput.Add($"Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
        }
    }
}