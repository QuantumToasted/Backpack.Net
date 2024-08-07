﻿using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the IGetPriceHistory endpoint.
    /// </summary>
    public sealed class PriceHistory
    {
        [JsonConstructor]
        internal PriceHistory()
        { }

        /// <summary>
        /// Whether or not the request was successful.
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => _response?.IsSuccess ?? true;

        /// <summary>
        /// If <see cref="IsSuccess"/> is false, this is error reason explaining why the request failed.
        /// </summary>
        [JsonIgnore]
        public string? ErrorMessage => _response?.ErrorMessage;

        /// <summary>
        /// If <see cref="IsSuccess"/> is false, this may contain additional error information.
        /// </summary>
        [JsonIgnore]
        public string? Reason => _response?.Reason;

        /// <summary>
        /// A collection of <see cref="Price"/>s, ordered from newest to oldest.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<Price> History
            => _response!.Prices.OrderByDescending(x => x.LastUpdate).ToArray();

        [JsonPropertyName("response")]
        [JsonInclude]
        private PriceHistoryResponse? _response;
    }
}