// <copyright file="AssignedNumberListResponse.cs" company="APIMatic">
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
    /// AssignedNumberListResponse.
    /// </summary>
    public class AssignedNumberListResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignedNumberListResponse"/> class.
        /// </summary>
        public AssignedNumberListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignedNumberListResponse"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="pagination">pagination.</param>
        public AssignedNumberListResponse(
            List<Models.AssignedNumber> data = null,
            Models.Pagination1 pagination = null)
        {
            this.Data = data;
            this.Pagination = pagination;
        }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AssignedNumber> Data { get; set; }

        /// <summary>
        /// Gets or sets Pagination.
        /// </summary>
        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Pagination1 Pagination { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AssignedNumberListResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is AssignedNumberListResponse other &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true)) &&
                ((this.Pagination == null && other.Pagination == null) || (this.Pagination?.Equals(other.Pagination) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
            toStringOutput.Add($"this.Pagination = {(this.Pagination == null ? "null" : this.Pagination.ToString())}");
        }
    }
}