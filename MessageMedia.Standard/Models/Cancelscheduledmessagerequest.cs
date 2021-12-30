// <copyright file="Cancelscheduledmessagerequest.cs" company="APIMatic">
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
    /// Cancelscheduledmessagerequest.
    /// </summary>
    public class Cancelscheduledmessagerequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cancelscheduledmessagerequest"/> class.
        /// </summary>
        public Cancelscheduledmessagerequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cancelscheduledmessagerequest"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        public Cancelscheduledmessagerequest(
            string status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Must be set to ```cancelled```.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Cancelscheduledmessagerequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is Cancelscheduledmessagerequest other &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
        }
    }
}