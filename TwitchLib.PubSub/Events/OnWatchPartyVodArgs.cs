using System;

namespace TwitchLib.PubSub.Events
{
    /// <inheritdoc/>
    /// <summary>
    /// Watch Party VOD arguments class.
    /// </summary>
    public class OnWatchPartyVodArgs : EventArgs
    {
        /// <summary>
        /// Property representing the id of the Watch Party
        /// </summary>
        public string WpId;
        /// <summary>
        /// Property representing the type of Watch Party
        /// </summary>
        public string WpType;
        /// <summary>
        /// Property representing the increment url of the Watch Party 
        /// </summary>
        public string IncrementUrl;
        /// <summary>
        /// Property representing the id of the VOD of the Watch Party.
        /// </summary>
        public int? VodId;
        /// <summary>
        /// Property representing the title.
        /// </summary>
        public string Title;
        /// <summary>
        /// Property representing the broadcast type.
        /// </summary>
        public string BroadcastType;
        /// <summary>
        /// Property for whether this Watch Party is viewable or not.
        /// </summary>
        public string Viewable;
        /// <summary>
        /// Property for channel's ID.
        /// </summary>
        public string ChannelId;
    }
}