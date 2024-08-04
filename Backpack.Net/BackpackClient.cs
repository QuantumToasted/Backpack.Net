using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backpack.Net
{
    /// <summary>
    /// A client for backpack.tf granting access to its APIs.
    /// </summary>
    public sealed class BackpackClient : IDisposable
    {
        internal static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions { Converters = { new BooleanConverter() } };
        internal static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0), TimeSpan.Zero);
        private const string API_URL = "https://backpack.tf/api";
        private readonly HttpClient _http;
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new instance of a <see cref="BackpackClient"/>.
        /// </summary>
        /// <param name="apiKey">Your backpack.tf API key, obtainable from https://backpack.tf/developer/apikey/view .</param>
        public BackpackClient(string apiKey)
        {
            _apiKey = apiKey;
            _http = new HttpClient();
        }

        /// <summary>
        /// Gets information about the currencies used by backpack.tf.
        /// </summary>
        /// <param name="value">The type(s) of price values desired to be included in the response.</param>
        public async Task<Currencies> GetCurrenciesAsync(CurrencyValue value = CurrencyValue.None)
            => await GetAsync<Currencies>("IGetCurrencies/v1", ("raw", (int) value)).ConfigureAwait(false);

        /// <summary>
        /// Gets current price information for all items. 
        /// </summary>
        /// <param name="value">The type(s) of price values desired to be included in the response.</param>
        /// <param name="since">If set, only items with prices newer than this <see cref="DateTimeOffset"/> will be returned.</param>
        public async Task<ItemPrices> GetItemPricesAsync(CurrencyValue value = CurrencyValue.None,
            DateTimeOffset? since = null)
        {
            var dto = (since ?? UnixEpoch).ToUniversalTime();
            if (dto < UnixEpoch)
                throw new ArgumentOutOfRangeException(nameof(since),
                    "The specified value must be greater than the value of the UNIX epoch.");

            return await GetAsync<ItemPrices>("IGetPrices/v4", 
                ("raw", (int) value),
                ("since", (dto - UnixEpoch).TotalSeconds)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets price history information for an item.
        /// </summary>
        /// <param name="itemName">The name of the item. (Exact match only)</param>
        /// <param name="quality">The <see cref="Quality"/> of the item.</param>
        /// <param name="craftable">Whether to search for the Craftable or Non-Craftable variant of the item.</param>
        /// <param name="priceIndex">A specific <see cref="PriceIndex"/> for the item.</param>
        public async Task<PriceHistory> GetPriceHistoryAsync(string itemName, Quality quality, bool craftable = true,
            PriceIndex? priceIndex = null)
            => await GetAsync<PriceHistory>("IGetPriceHistory/v1",
                ("appid", 440),
                ("item", itemName.Replace(" ", "%20")),
                ("quality", (int) quality),
                ("tradable", 1),
                ("craftable", craftable ? 1 : 0),
                ("priceindex", (priceIndex ?? PriceIndex.Default).ToString())).ConfigureAwait(false);

        /// <summary>
        /// Gets a list of frequently impersonated users on backpack.tf.
        /// </summary>
        /// <param name="limit">The limit of users to fetch. Used for pagination.</param>
        /// <param name="skip">The number of users to "skip" before fetching. Used for pagination.</param>
        public async Task<ImpersonatedUsers> GetImpersonatedUsersAsync(int limit = 200, int skip = 0)
        {
            if (limit < 1)
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit of users must be greater than 0.");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), "Number of users skipped must not be negative.");

            return await GetAsync<ImpersonatedUsers>("IGetUsers/GetImpersonatedUsers",
                ("limit", limit),
                ("skip", skip)).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets various backpack.tf user information.
        /// <para /> This method functions correctly but is undocumented and may be removed from the API without warning.
        /// </summary>
        /// <param name="steamIds">A collection of SteamID64 identifiers.</param>
        public async Task<BackpackUsers> GetUsersAsync(params ulong[] steamIds)
        {
            if (steamIds.Length == 0)
                throw new ArgumentException("Steam ID collection must not be empty", nameof(steamIds));

            return await GetAsync<BackpackUsers>("users/info/v1", ("steamids", string.Join(",", steamIds.Distinct()))).ConfigureAwait(false);
        }

        private async Task<T> GetAsync<T>(string endpoint, params (string Name, object Data)[] parameters)
        {
            var url = new StringBuilder($"{API_URL}/{endpoint}?key={_apiKey}")
                .AppendJoin(string.Empty, parameters.Select(x => $"&{x.Name}={x.Data}"))
                .ToString();

            using var response = await _http.GetAsync(url).ConfigureAwait(false);
            // response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(content, JsonOptions)!;
        }
        
        /// <inheritdoc />
        public void Dispose()
        {
            _http?.Dispose();
        }
    }
}
