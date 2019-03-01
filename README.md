# Backpack.Net

A REST API wrapper for (most of) https://backpack.tf 's endpoints.

A rewrite of [my old wrapper library](https://github.com/Kuromu/BackpackWebAPI), with a great amount of cleanup.

### Currently supported endpoints
IGetCurrencies/v1

IGetPriceHistory/v1

IGetPrices/v4

IGetUsers/GetImpersonatedUsers

users/info/v1

## Sample usage

Using the client is pretty straightforward: create an instance of `BackpackClient` and use Intellisense to view the availble methods.

XML docs are available on all properties and methods.

```cs
// Initialize a new backpack.tf client.
// Get your API key from https://backpack.tf/developer/apikey/view
var client = new BackpackClient("MY_API_KEY");

// Example usage: Get currency information
var currencies = await client.GetCurrenciesAsync();
Console.WriteLine($"Keys are currently worth {currencies.CrateKey.Price.Value} refined.");
```