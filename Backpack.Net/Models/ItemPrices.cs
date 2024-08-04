using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the IGetPrices endpoint.
    /// </summary>
    public sealed class ItemPrices
    {
        [JsonConstructor]
        internal ItemPrices()
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
        /// The timestamp representing when the request was made to the API.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset CurrentTime => BackpackClient.UnixEpoch.AddSeconds(_response!.CurrentTime);

        /// <summary>
        /// The value of the lowest currency in USD at the time of this request.
        /// </summary>
        [JsonIgnore]
        public decimal RawUSDValue => _response!.RawUSDValue;

        /// <summary>
        /// The lowest currency's name used in <see cref="RawUSDValue"/>.
        /// </summary>
        [JsonIgnore]
        public string USDCurrency => _response!.USDCurrency;

        /// <summary>
        /// The definition index of the item referenced in <see cref="USDCurrency"/>.
        /// </summary>
        [JsonIgnore]
        public int USDCurrencyIndex => _response!.USDCurrencyIndex;

        /// <summary>
        /// A mapping of item names to their respective item entries, including their <see cref="Price"/>s.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyDictionary<string, Item> Items 
            => _response!.Items.ToDictionary(x => x.Key, x => x.Value.WithName(x.Key));

        [JsonPropertyName("response")]
        [JsonInclude]
        private ItemPricesResponse? _response;
    }
}