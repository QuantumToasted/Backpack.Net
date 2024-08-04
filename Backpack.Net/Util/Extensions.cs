using System.Collections.Generic;
using System.Text;

namespace Backpack.Net
{
    internal static class Extensions
    {
        internal static StringBuilder AppendJoin<T>(this StringBuilder builder,
            string separator, IEnumerable<T> data)
            => builder.Append(string.Join(separator, data));

        internal static List<SiteBan> WithBan(this List<SiteBan> bans, SiteBan ban, SiteBanType type)
        {
            if (ban is not null)
                bans.Add(ban.WithType(type));
            
            return bans;
        }
    }
}