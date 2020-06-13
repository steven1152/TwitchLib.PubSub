namespace TwitchLib.PubSub.Enums
{
    /// <summary>
    /// Valid playback types.
    /// </summary>
    public enum VideoPlaybackType
    {
        Unknown,
        /// <summary>
        /// On stream up
        /// </summary>
        StreamUp,
        /// <summary>
        /// On stream down
        /// </summary>
        StreamDown,
        /// <summary>
        /// On view count
        /// </summary>
        ViewCount,
        /// <summary>
        /// On commercial
        /// </summary>
        Commercial,
        /// <summary>
        /// On Watch Party VOD (Rerun)
        /// </summary>
        WatchPartyVod
    }
}