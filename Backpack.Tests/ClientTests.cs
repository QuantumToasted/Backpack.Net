using Backpack.Net;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Backpack.Tests
{
    public class ClientTests
    {
        private static readonly BackpackClient Client 
            = new BackpackClient(Environment.GetEnvironmentVariable("BACKPACK_APIKEY"));

        [Fact]
        public async Task TestCurrenciesAsync()
        {
            var response = await Client.GetCurrenciesAsync();

            Assert.NotNull(response);
            Assert.True(response.IsSuccess, response.ErrorMessage);

            foreach (var currency in new[]
                {response.CraftHat, response.CrateKey, response.Earbuds, response.RefinedMetal})
            {
                Assert.NotNull(currency);
                Assert.True(Enum.IsDefined(typeof(Quality), currency.Quality));
                Assert.NotNull(currency.Price);
            }
        }

        [Fact]
        public async Task TestItemPricesAsync()
        {
            var response = await Client.GetItemPricesAsync();
            
            Assert.NotNull(response);
            Assert.True(response.IsSuccess, response.ErrorMessage);

            foreach (var item in response.Items)
            {
                Assert.False(string.IsNullOrWhiteSpace(item.Key));
                Assert.NotEmpty(item.Value.DefinitionIndexes);

                foreach (var quality in item.Value.Qualities)
                {
                    Assert.True(Enum.IsDefined(typeof(Quality), quality.Key));

                    Assert.NotNull(quality.Value.NonCraftable);
                    foreach (var price in quality.Value.NonCraftable)
                    {
                        Assert.NotNull(price.Key);
                        Assert.NotNull(price.Value);
                    }
                    
                    Assert.NotNull(quality.Value.Craftable);
                    foreach (var price in quality.Value.Craftable)
                    {
                        Assert.NotNull(price.Key);
                        Assert.NotNull(price.Value);
                    }
                }
            }
        }

        [Fact]
        public async Task TestPriceHistoryAsync()
        {
            var response = await Client.GetPriceHistoryAsync(
                "Mann Co. Supply Crate Key", Quality.Unique, true, PriceIndex.Default);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess, response.ErrorMessage);

            foreach (var price in response.History)
            {
                Assert.NotNull(price);
            }
        }

        [Theory]
        [InlineData(new ulong[] {76561198112217552, 76561198261978034, 76561198120467518, 76561198051696861, 76561198074081347, 76561198126507963 })]
        public async Task TestBackpackUsersAsync(ulong[] users)
        {
            var response = await Client.GetUsersAsync(users);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess, response.ErrorMessage);

            foreach (var user in response.Users)
            {
                Assert.True(user.Id > 0);
                Assert.False(string.IsNullOrWhiteSpace(user.Name));
                Assert.NotNull(user.AvatarUrl);

                if (user.Voting is not null)
                {
                    Assert.NotNull(user.Voting.Suggestions);
                    Assert.NotNull(user.Voting.Votes);
                }

                Assert.NotNull(user.Inventory);
            }
        }

        [Theory]
        [InlineData(new ulong[] {203139091657654272, 167452465317281793 })]
        public async Task TestFailedBackpackUsersAsync(ulong[] users)
        {
            var response = await Client.GetUsersAsync(users);

            Assert.NotNull(response);
            Assert.True(response.IsSuccess); // 
        }

        [Fact]
        public async Task TestImpersonatedUsersAsync()
        {
            var response = await Client.GetImpersonatedUsersAsync();

            Assert.NotNull(response);
            Assert.True(response.IsSuccess, response.ErrorMessage);
            Assert.True(response.Total > 0);

            foreach (var user in response.Users)
            {
                Assert.NotNull(user.Name);
                Assert.NotNull(user.AvatarUrl);
                Assert.True(user.SteamId > 0);
            }
        }
    }
}