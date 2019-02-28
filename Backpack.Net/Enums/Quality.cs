using System;

namespace Backpack.Net
{
    /// <summary>
    /// Used to define an item's quality in-game.
    /// </summary>
    public enum Quality
    {
        /// <summary>
        /// "Normal" quality.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// "Genuine" quality.
        /// </summary>
        Genuine = 1,

        /// <summary>
        /// "rarity2" quality.
        /// </summary>
        [Obsolete("This quality is unused in-game.")]
        Rarity2 = 2,

        /// <summary>
        /// "Vintage" quality.
        /// </summary>
        Vintage = 3,

        /// <summary>
        /// "rarity3" quality.
        /// </summary>
        [Obsolete("This quality is unused in-game.")]
        Rarity3 = 4,

        /// <summary>
        /// "Unusual" quality.
        /// </summary>
        Unusual = 5,

        /// <summary>
        /// "Unique" quality.
        /// </summary>
        Unique = 6,

        /// <summary>
        /// "Community" quality.
        /// </summary>
        Community = 7,

        /// <summary>
        /// "Valve" quality.
        /// </summary>
        Valve = 8,

        /// <summary>
        /// "Self-Made" quality.
        /// </summary>
        SelfMade = 9,

        /// <summary>
        /// "Customized" quality.
        /// </summary>
        [Obsolete("This quality is unused in-game.")]
        Customized = 10,

        /// <summary>
        /// "Strange" quality.
        /// </summary>
        Strange = 11,

        /// <summary>
        /// "Completed" quality.
        /// </summary>
        [Obsolete("This quality is unused in-game.")]
        Completed = 12,

        /// <summary>
        /// "Haunted" quality.
        /// </summary>
        Haunted = 13,

        /// <summary>
        /// "Collector's" quality.
        /// </summary>
        Collectors = 14,

        /// <summary>
        /// "Decorated Weapon" quality (skinned weapons).
        /// </summary>
        Decorated = 15
    }
}