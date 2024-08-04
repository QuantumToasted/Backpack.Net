using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an individual user on backpack.tf.
    /// </summary>
    public sealed class BackpackUser
    {
        [JsonConstructor]
        internal BackpackUser()
        { }

        /// <summary>
        /// The user's SteamID64 identifier.
        /// </summary>
        [JsonIgnore]
        public ulong Id { get; private set; }

        internal BackpackUser WithId(ulong id)
        {
            Id = id;
            return this;
        }

        /// <summary>
        /// The user's Steam persona name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        /// <summary>
        /// The user's Steam persona avatar.
        /// </summary>
        [JsonIgnore]
        public Uri AvatarUrl => new Uri(_avatar);

        /// <summary>
        /// The last time this user was online on backpack.tf. Will be <see langword="null"/> if the user has never logged in.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? LastOnline => _lastOnline == 0 ? (DateTimeOffset?) null : BackpackClient.UnixEpoch.AddSeconds(_lastOnline);

        [JsonPropertyName("admin")]
        [JsonInclude]
        private bool _admin;

        /// <summary>
        /// The amount of money, (in $USD) this user has donated.
        /// </summary>
        [JsonPropertyName("donated")]
        public decimal AmountDonated { get; init; }

        [JsonPropertyName("premium")]
        [JsonInclude]
        private bool _premium;

        /// <summary>
        /// The number of months of backpack.tf Premium this user has gifted to others.
        /// </summary>
        [JsonPropertyName("premium_months_gifted")]
        public int PremiumMonthsGifted { get; init; }

        /// <summary>
        /// A collection of flags this user has set on the site.
        /// </summary>
        [JsonIgnore]
        public BackpackUserFlags Flags
        {
            get
            {
                var flags = BackpackUserFlags.None;

                if (_admin)
                    flags |= BackpackUserFlags.BackpackAdmin;
                if (_premium)
                    flags |= BackpackUserFlags.Premium;

                if (_integrations is not null)
                {
                    if (_integrations.IsGroupMember)
                        flags |= BackpackUserFlags.GroupMember;
                    if (_integrations.IsMarketplaceSeller)
                        flags |= BackpackUserFlags.MarketplaceSeller;
                    if (_integrations.IsAutomatic)
                        flags |= BackpackUserFlags.Automatic;
                    if (_integrations.IsSteamRepAdmin)
                        flags |= BackpackUserFlags.SteamRepAdmin;
                }

                if (_bans is not null)
                {
                    if (_bans.IsSteamRepScammer)
                        flags |= BackpackUserFlags.SteamRepScammer;
                    if (_bans.IsSteamRepCaution)
                        flags |= BackpackUserFlags.SteamRepCaution;
                    if (_bans.Valve.IsEconomyBanned)
                        flags |= BackpackUserFlags.SteamEconomyBanned;
                    if (_bans.Valve.IsCommunityBanned)
                        flags |= BackpackUserFlags.SteamCommunityBanned;
                    if (_bans.Valve.IsVACBanned)
                        flags |= BackpackUserFlags.SteamVACBanned;
                    if (_bans.Valve.IsGameBanned)
                        flags |= BackpackUserFlags.ValveGameBanned;
                }

                return flags;
            }
        }

        /// <summary>
        /// A collection of <see cref="SiteBan"/>s this user has on the site.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<SiteBan> SiteBans
        {
            get
            {
                if (_bans is null)
                    return new List<SiteBan>();
                
                return new List<SiteBan>()
                    .WithBan(_bans.All, SiteBanType.All)
                    .WithBan(_bans.Suggestions, SiteBanType.Suggestions)
                    .WithBan(_bans.Comments, SiteBanType.Comments)
                    .WithBan(_bans.Trust, SiteBanType.Trust)
                    .WithBan(_bans.Issues, SiteBanType.Issues)
                    .WithBan(_bans.Classifieds, SiteBanType.Classifieds)
                    .WithBan(_bans.Customizations, SiteBanType.Customizations)
                    .WithBan(_bans.Reports, SiteBanType.Reports);
            }
        }

        /// <summary>
        /// This user's <see cref="Net.Voting"/> stats.
        /// </summary>
        [JsonPropertyName("voting")]
        public Voting? Voting { get; init; }

        /// <summary>
        /// This user's <see cref="Net.Trust"/> stats.
        /// </summary>
        [JsonPropertyName("trust")]
        public Trust? Trust { get; init; }

        /// <summary>
        /// This user's <see cref="Net.Inventory"/>.
        /// </summary>
        [JsonIgnore]
        public Inventory Inventory => _inventories.TryGetValue("440", out var value) ? value : new Inventory();

        [JsonPropertyName("bans")]
        [JsonInclude]
        private InternalBans? _bans;

        [JsonPropertyName("integrations")]
        [JsonInclude]
        private Integrations? _integrations;

        [JsonPropertyName("last_online")]
        [JsonInclude]
        private int _lastOnline;

        [JsonPropertyName("avatar")]
        [JsonInclude]
        private string _avatar = null!;

        [JsonPropertyName("inventory")]
        [JsonInclude]
        private Dictionary<string, Inventory> _inventories = null!;
    }
}