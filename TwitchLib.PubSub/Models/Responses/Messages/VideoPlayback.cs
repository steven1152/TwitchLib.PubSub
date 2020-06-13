using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
    /// <summary>
    /// VideoPlayback model constructor.
    /// Implements the <see cref="MessageData" />
    /// </summary>
    /// <seealso cref="MessageData" />
    /// <inheritdoc />
    public class VideoPlayback : MessageData
    {
        /// <summary>
        /// Video playback type
        /// </summary>
        /// <value>The type.</value>
        public VideoPlaybackType Type { get; }
        /// <summary>
        /// Server time stamp
        /// </summary>
        /// <value>The server time.</value>
        public string ServerTime { get; }
        /// <summary>
        /// Current delay (if one exists)
        /// </summary>
        /// <value>The play delay.</value>
        public int PlayDelay { get; }
        /// <summary>
        /// Viewer count
        /// </summary>
        /// <value>The viewers.</value>
        public int Viewers { get; }
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; }
        /// <summary>
        /// Title
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Broadcast Type
        /// </summary>
        /// <value>The broadcast type.</value>
        public string BroadcastType { get; set; }
        /// <summary>
        /// If viewable or not
        /// </summary>
        /// <value>True if viewable.</value>
        public string Viewable { get; set; }
        /// <summary>
        /// Watch Party Id
        /// </summary>
        /// <value>The watch party id.</value>
        public string WpId { get; set; }
        /// <summary>
        /// Watch Party Type
        /// </summary>
        /// <value>The watch party type.</value>
        public string WpType { get; set; }
        /// <summary>
        /// VOD id
        /// </summary>
        /// <value>The VOD id.</value>
        public int? VodId { get; set; }
        /// <summary>
        /// Increment Url
        /// </summary>
        /// <value>The increment url.</value>
        public string IncrementUrl { get; set; }

        /// <summary>
        /// VideoPlayback constructor.
        /// </summary>
        /// <param name="jsonStr">The json string.</param>
        public VideoPlayback(string jsonStr)
        {
            JToken json = JObject.Parse(jsonStr);
            switch (json.SelectToken("type").ToString())
            {
                case "stream-up":
                    Type = VideoPlaybackType.StreamUp;
                    break;
                case "stream-down":
                    Type = VideoPlaybackType.StreamDown;
                    break;
                case "viewcount":
                    Type = VideoPlaybackType.ViewCount;
                    break;
                case "commercial":
                    Type = VideoPlaybackType.Commercial;
                    break;
                case "watchparty-vod":
                    Type = VideoPlaybackType.WatchPartyVod;
                    break;
                default:
                    return;
            }
            ServerTime = json.SelectToken("server_time")?.ToString();
            switch (Type)
            {
                case VideoPlaybackType.StreamUp:
                    PlayDelay = int.Parse(json.SelectToken("play_delay")?.ToString() ?? "0");
                    break;
                case VideoPlaybackType.ViewCount:
                    Viewers = int.Parse(json.SelectToken("viewers").ToString());
                    break;
                case VideoPlaybackType.StreamDown:
                    break;
                case VideoPlaybackType.Commercial:
                    Length = int.Parse(json.SelectToken("length").ToString());
                    break;
                case VideoPlaybackType.WatchPartyVod:
                    var vod = json.SelectToken("vod");
                    Title = vod?.SelectToken("title")?.ToString();
                    BroadcastType = vod?.SelectToken("broadcast_type")?.ToString();
                    Viewable = vod?.SelectToken("viewable")?.ToString();
                    IncrementUrl = vod?.SelectToken("increment_url")?.ToString();
                    WpType = vod?.SelectToken("wp_type")?.ToString();
                    WpId = vod?.SelectToken("wp_id")?.ToString();
                    if (int.TryParse(vod?.SelectToken("vod_id")?.ToString(), out var value))
                    {
                        VodId = value;
                    }
                    break;
            }
        }
    }
}
