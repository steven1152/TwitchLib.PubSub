using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc/>
    /// <summary>
    /// Commercial arguments class.
    /// </summary>
    public class OnCommercialArgs : EventArgs
    {
        /// <summary>
        /// The length of the commercial.
        /// </summary>
        public int Length;
        /// <summary>
        /// Server time issued by Twitch.
        /// </summary>
        public string ServerTime;

        /// <summary>
        /// Property for channel's ID.
        /// </summary>
        public string ChannelId;
    }
}