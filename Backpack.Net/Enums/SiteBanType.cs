namespace Backpack.Net
{
    /// <summary>
    /// Represents a <see cref="SiteBan"/>'s type.
    /// </summary>
    public enum SiteBanType
    {
        /// <summary>
        /// This user is banned from all site functionality.
        /// </summary>
        All,

        /// <summary>
        /// This user is banned from making price suggestions.
        /// </summary>
        Suggestions,

        /// <summary>
        /// This user is banned from leaving comments.
        /// </summary>
        Comments,

        /// <summary>
        /// This user is banned from leaving trust ratings on users' profiles.
        /// </summary>
        Trust,

        /// <summary>
        /// This user is banned from opening issues.
        /// </summary>
        Issues,

        /// <summary>
        /// This user is banned from creating classified listings.
        /// </summary>
        Classifieds,

        /// <summary>
        /// This user is banned from profile customizations.
        /// </summary>
        Customizations,

        /// <summary>
        /// This user is banned from making user reports.
        /// </summary>
        Reports
    }
}