using System;
using System.Text.RegularExpressions;

namespace Backpack.Net
{
    /// <summary>
    /// Represents a price index for an item, to distinguish items of the same definition index and <see cref="Quality"/>.
    /// </summary>
    public abstract class PriceIndex
    {
        internal PriceIndex()
        { }

        internal static PriceIndex Create(string name, Quality quality, string priceIndex)
        {
            if (quality == Quality.Unusual && 
                int.TryParse(priceIndex, out var particleEffect))
            {
                return new UnusualPriceIndex((ParticleEffect) particleEffect);
            }

            if (CratePriceIndex.CrateRegex.IsMatch(name) &&
                int.TryParse(priceIndex, out var crateSeries))
            {
                return new CratePriceIndex(crateSeries);
            }

            if ((name.ToLower().Contains("strangifier") ||
                name.ToLower().Contains("unusualifier")) &&
                int.TryParse(priceIndex, out var definitionIndex))
            {
                return new ModifierPriceIndex(definitionIndex);
            }

            if (priceIndex.Contains("-"))
            {
                var split = priceIndex.Split('-');
                if (int.TryParse(split[0], out definitionIndex) && int.TryParse(split[1], out var itemQuality))
                {
                    return new ChemistrySetPriceIndex(definitionIndex, (Quality) itemQuality);
                }
            }

            return new DefaultPriceIndex();
        }

        /// <summary>
        /// Creates a new <see cref="DefaultPriceIndex"/> (used for most normal items).
        /// </summary>
        public static PriceIndex Default => new DefaultPriceIndex();

        /// <summary>
        /// Creates a new <see cref="UnusualPriceIndex"/> with a specified particle effect.
        /// </summary>
        /// <param name="particleEffect">The particle effect.</param>
        public static PriceIndex Unusual(ParticleEffect particleEffect) => new UnusualPriceIndex(particleEffect);

        /// <summary>
        /// Creates a new <see cref="CratePriceIndex"/> with a specified crate series number.
        /// </summary>
        /// <param name="crateSeries">The crate series number.</param>
        public static PriceIndex Crate(int crateSeries) => new CratePriceIndex(crateSeries);

        /// <summary>
        /// Creates a new <see cref="ModifierPriceIndex"/> with a specified definition index for the item it's used for.
        /// </summary>
        /// <param name="definitionIndex">The definition index of the item this can be used on.</param>
        public static PriceIndex Modifier(int definitionIndex) => new ModifierPriceIndex(definitionIndex);

        /// <summary>
        /// Creates a new <see cref="ChemistrySetPriceIndex"/> with a specified item definition index and quality as the outputs.
        /// </summary>
        /// <param name="definitionIndex">The definition index of the item this chemistry set outputs.</param>
        /// <param name="quality">The <see cref="Net.Quality"/> of the item this chemistry set outputs.</param>
        public static PriceIndex ChemistrySet(int definitionIndex, Quality quality)
            => new ChemistrySetPriceIndex(definitionIndex, quality);

        /// <summary>
        /// Returns the formatted price index as it was returned by the API.
        /// </summary>
        public abstract override string ToString();
    }

    /// <inheritdoc />
    /// <summary>
    /// The default price index type.
    /// </summary>
    public sealed class DefaultPriceIndex : PriceIndex
    {
        internal DefaultPriceIndex()
        { }

        /// <inheritdoc />
        public override string ToString()
            => "0";
    }

    /// <inheritdoc />
    /// <summary>
    /// An Unusual item's price index.
    /// </summary>
    public sealed class UnusualPriceIndex : PriceIndex
    {
        internal UnusualPriceIndex(ParticleEffect particleEffect)
        {
            ParticleEffect = particleEffect;
        }

        /// <summary>
        /// The <see cref="Net.ParticleEffect"/> for this unusual item.
        /// </summary>
        public ParticleEffect ParticleEffect { get; }

        /// <inheritdoc />
        public override string ToString()
            => ((int) ParticleEffect).ToString();
    }

    /// <inheritdoc />
    /// <summary>
    /// A crate (or case)'s price index.
    /// </summary>
    public sealed class CratePriceIndex : PriceIndex
    {
        internal static readonly Regex CrateRegex =
            new Regex(@"( case\b|crate\b)(?! key)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        internal CratePriceIndex(int crateSeries)
        {
            CrateSeries = crateSeries;
        }

        /// <summary>
        /// The series for this particular crate or case.
        /// </summary>
        public int CrateSeries { get; }

        /// <inheritdoc />
        public override string ToString()
            => CrateSeries.ToString();
    }

    /// <inheritdoc />
    /// <summary>
    /// A Strangifier or Unusualifier's price index.
    /// </summary>
    public sealed class ModifierPriceIndex : PriceIndex
    {
        internal ModifierPriceIndex(int definitionIndex)
        {
            DefinitionIndex = definitionIndex;
        }

        /// <summary>
        /// The definition index for the item that this Unusualifier or Strangifier is for.
        /// </summary>
        public int DefinitionIndex { get; }

        /// <inheritdoc />
        public override string ToString()
            => DefinitionIndex.ToString();
    }

    /// <inheritdoc />
    /// <summary>
    /// A Chemistry Set's price index.
    /// </summary>
    public sealed class ChemistrySetPriceIndex : PriceIndex
    {
        internal ChemistrySetPriceIndex(int definitionIndex, Quality quality)
        {
            DefinitionIndex = definitionIndex;
            Quality = quality;
        }

        /// <summary>
        /// The definition index for the item that this Chemistry Set is for.
        /// </summary>
        public int DefinitionIndex { get; }

        /// <summary>
        /// The <see cref="Net.Quality"/> of the item that this Chemistry set is for.
        /// </summary>
        public Quality Quality { get; }

        /// <inheritdoc />
        public override string ToString()
            => $"{DefinitionIndex}-{(int) Quality}";
    }
}