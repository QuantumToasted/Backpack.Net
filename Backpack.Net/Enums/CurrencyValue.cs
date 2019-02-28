namespace Backpack.Net
{
    /// <summary>
    /// Represents additional currency values able to be requested for endpoints which return <see cref="Price"/> models.
    /// </summary>
    public enum CurrencyValue
    {
        /// <summary>
        /// The <see cref="Price"/> model will only display its value.
        /// </summary>
        None = 0,

        /// <summary>
        /// The <see cref="Price"/> model will carry a raw value, which is the value in the lowest currency without rounding.
        /// </summary>
        Raw = 1,

        /// <summary>
        /// The <see cref="Price"/> model will carry a raw value and raw high value, which is the upper bound of the average value in the lowest currency without rounding.
        /// </summary>
        RawHigh = 2
    }
}