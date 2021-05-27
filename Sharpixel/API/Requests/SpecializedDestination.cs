using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpixel.API.Requests
{
    /// <summary>
    /// Provides specialized destination URL for <see cref="SpecializedRequest{T}"/>
    /// </summary>
    public enum SpecializedDestination
    {
        /// <summary>
        /// Equal to https://api.hypixel.net/player
        /// </summary>
        Player,
        /// <summary>
        /// Equal to https://api.hypixel.net/friends
        /// </summary>
        Friends,
    }
}
