using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents the response returned by the IGetCurrencies endpoint.
    /// </summary>
    public sealed class Currencies
    {
        [JsonConstructor]
        internal Currencies()
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
        /// The name of the game these currencies are for. Normally just "Team Fortress 2".
        /// </summary>
        [JsonIgnore]
        public string Name => _response!.Name;

        /// <summary>
        /// A URL linking back to https://backpack.tf.
        /// </summary>
        [JsonIgnore]
        public Uri Url => new Uri(_response!.Url);

        /// <summary>
        /// A <see cref="Currency"/> representing Refined Metal, or "ref".
        /// </summary>
        [JsonIgnore]
        public Currency RefinedMetal => _response!.Currencies["metal"];

        /// <summary>
        /// A <see cref="Currency"/> representing craft hats.
        /// </summary>
        [JsonIgnore]
        public Currency CraftHat => _response!.Currencies["hat"];

        /// <summary>
        /// A <see cref="Currency"/> representing Crate Keys, or "keys".
        /// </summary>
        [JsonIgnore]
        public Currency CrateKey => _response!.Currencies["keys"];

        /// <summary>
        /// A <see cref="Currency"/> representing Earbuds, or "buds".
        /// </summary>
        [JsonIgnore]
        public Currency Earbuds => _response!.Currencies["earbuds"];

        [JsonPropertyName("response")]
        [JsonInclude]
        private CurrenciesResponse? _response;
    }
}