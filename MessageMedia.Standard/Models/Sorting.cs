// <copyright file="Sorting.cs" company="APIMatic">
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
    /// Sorting.
    /// </summary>
    public class Sorting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sorting"/> class.
        /// </summary>
        public Sorting()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sorting"/> class.
        /// </summary>
        /// <param name="field">field.</param>
        /// <param name="order">order.</param>
        public Sorting(
            Models.FieldEnum? field = null,
            Models.OrderEnum? order = null)
        {
            this.Field = field;
            this.Order = order;
        }

        /// <summary>
        /// The value of the sort_by field provided for this report
        /// </summary>
        [JsonProperty("field", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.FieldEnum? Field { get; set; }

        /// <summary>
        /// The value of the sort_direction field provided for this report
        /// </summary>
        [JsonProperty("order", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderEnum? Order { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Sorting : ({string.Join(", ", toStringOutput)})";
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

            return obj is Sorting other &&
                ((this.Field == null && other.Field == null) || (this.Field?.Equals(other.Field) == true)) &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Field = {(this.Field == null ? "null" : this.Field.ToString())}");
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
        }
    }
}