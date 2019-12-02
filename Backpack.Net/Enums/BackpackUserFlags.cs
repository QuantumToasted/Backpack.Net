using System;

namespace Backpack.Net
{
    /// <summary>
    /// Represents flags a <see cref="BackpackUser"/> can hold on the site.
    /// </summary>
    [Flags]
    public enum BackpackUserFlags
    {
        /// <summary>
        /// If this is the only flag set, this user has no flags set.
        /// </summary>
        None = 0,

        /// <summary>
        /// This user is a backpack.tf admin.
        /// </summary>
        BackpackAdmin = 1,

        /// <summary>
        /// This user currently has backpack.tf Premium.
        /// </summary>
        Premium = 2,

        /// <summary>
        /// This user is a member of the "Meet the Stats" Steam group.
        /// </summary>
        GroupMember = 4,

        /// <summary>
        /// This user is a seller on marketplace.tf.
        /// </summary>
        MarketplaceSeller = 8,

        /// <summary>
        /// This user has backpack.tf Automatic enabled.
        /// </summary>
        Automatic = 16,

        /// <summary>
        /// This user is a SteamRep admin.
        /// </summary>
        SteamRepAdmin = 32,

        /// <summary>
        /// This user is marked as a scammer on SteamRep.
        /// </summary>
        SteamRepScammer = 64,

        /// <summary>
        /// This user is marked as "caution" on SteamRep.
        /// </summary>
        SteamRepCaution = 128,

        /// <summary>
        /// This user has one or more economy bans on Steam.
        /// </summary>
        [Obsolete("This value has been renamed to SteamEconomyBanned and will be removed in a future release.")]
        SteamEconomy = 256,

        /// <summary>
        /// This user has one or more economy bans on Steam.
        /// </summary>
        SteamEconomyBanned = 256,

        /// <summary>
        /// This user has one or more community bans on Steam.
        /// </summary>
        SteamCommunityBanned = 512,

        /// <summary>
        /// This user has one or more VAC bans on Steam.
        /// </summary>
        SteamVACBanned = 1024,

        /// <summary>
        /// This user has one or more game bans on Steam.
        /// </summary>
        ValveGameBanned = 2048
    }
}