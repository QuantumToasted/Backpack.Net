using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Backpack.Net.Extensions;
using Newtonsoft.Json;

namespace Backpack.Net
{
    /// <summary>
    /// Represents an individual user on backpack.tf.
    /// </summary>
    public sealed class BackpackUser
    {
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
        [JsonProperty("name")]
        public string Name { get; private set; }

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

        [JsonProperty("admin")]
        private readonly bool _admin;

        /// <summary>
        /// The amount of money, (in $USD) this user has donated.
        /// </summary>
        [JsonProperty("donated")]
        public decimal AmountDonated { get; private set; }

        [JsonProperty("premium")]
        private readonly bool _premium;

        /// <summary>
        /// The number of months of backpack.tf Premium this user has gifted to others.
        /// </summary>
        [JsonProperty("premium_months_gifted")]
        public int PremiumMonthsGifted { get; private set; }

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

                if (_integrations.IsGroupMember)
                    flags |= BackpackUserFlags.GroupMember;
                if (_integrations.IsMarketplaceSeller)
                    flags |= BackpackUserFlags.MarketplaceSeller;
                if (_integrations.IsAutomatic)
                    flags |= BackpackUserFlags.Automatic;
                if (_integrations.IsSteamRepAdmin)
                    flags |= BackpackUserFlags.SteamRepAdmin;

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

                return flags;
            }
        }

        /// <summary>
        /// A collection of <see cref="SiteBan"/>s this user has on the site.
        /// </summary>
        [JsonIgnore]
        public ImmutableArray<SiteBan> SiteBans
            => new List<SiteBan>()
                .WithBan(_bans.All, SiteBanType.All)
                .WithBan(_bans.Suggestions, SiteBanType.Suggestions)
                .WithBan(_bans.Comments, SiteBanType.Comments)
                .WithBan(_bans.Trust, SiteBanType.Trust)
                .WithBan(_bans.Issues, SiteBanType.Issues)
                .WithBan(_bans.Classifieds, SiteBanType.Classifieds)
                .WithBan(_bans.Customizations, SiteBanType.Customizations)
                .WithBan(_bans.Reports, SiteBanType.Reports)
                .ToImmutableArray();

        /// <summary>
        /// This user's <see cref="Net.Voting"/> stats.
        /// </summary>
        [JsonProperty("voting")]
        public Voting Voting { get; private set; } = new Voting();

        /// <summary>
        /// This user's <see cref="Net.Trust"/> stats.
        /// </summary>
        [JsonProperty("trust")]
        public Trust Trust { get; private set; } = new Trust();

        /// <summary>
        /// This user's <see cref="Net.Inventory"/>.
        /// </summary>
        [JsonIgnore]
        public Inventory Inventory => _inventories.TryGetValue("440", out var value) ? value : new Inventory();

        [JsonProperty("bans")]
        private InternalBans _bans = new InternalBans();

        [JsonProperty("integrations")]
        private Integrations _integrations = new Integrations();

        [JsonProperty("last_online")]
        private readonly int _lastOnline;

        [JsonProperty("avatar")]
        private readonly string _avatar;

        [JsonProperty("inventory")]
        private Dictionary<string, Inventory> _inventories = new Dictionary<string, Inventory>();
    }
}