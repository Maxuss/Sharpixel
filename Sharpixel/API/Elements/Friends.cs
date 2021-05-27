using System;
using Newtonsoft.Json;
using Sharpixel.API.Requests;

namespace Sharpixel.API.Elements
{
    /// <summary>
    /// This class is used for storing friends data of player
    /// </summary>
    public sealed class Friends : RequestElement
    {
        /// <summary>
        /// Minecraft UUID of the player
        /// </summary>
        [JsonProperty("uuid")] public string UUID;
        /// <summary>
        /// All recorded friend requests
        /// </summary>
        [JsonProperty("records")] public FriendElement[] Records;
    }

    /// <summary>
    /// This class is used for storing a single record of player's friend
    /// </summary>
    public sealed class FriendElement
    {
        /// <summary>
        /// Hypixel ID of Friend Request
        /// </summary>
        [JsonProperty("_id")] public string RequestID;
        /// <summary>
        /// Minecraft UUID of request sender
        /// </summary>
        [JsonProperty("uuidSender")] public string SenderUUID;
        /// <summary>
        /// Minecraft UUID of request receiver
        /// </summary>
        [JsonProperty("uuidReceiver")] public string ReceiverUUID;
        /// <summary>
        /// Unix Timestamp in milliseconds of when request was sent
        /// </summary>
        [JsonProperty("started")] public ulong UnixSent;

        /// <summary>
        /// DateTime object of when request was sent
        /// </summary>
        public DateTime DateSent
        {
            get
            {
                DateTime convert = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return convert.AddMilliseconds(UnixSent).ToLocalTime();
            }
        }
    }
}