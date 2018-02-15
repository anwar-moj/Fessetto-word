namespace Fasseto.Word.Core
{
    /// <summary>
    /// A view model for each list item in the over view chat list
    /// </summary>
    public class ChatListItemViewModel:BaseViewModel
    {
        /// <summary>
        /// The display name of the chat list item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The latest message from this message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The initials to show for the picture profile
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// The random background colors for the profile pictures (In Hex)
        /// For example #FF00FF
        /// </summary>
        public string ProfilePictureRGB { get; set; }
        /// <summary>
        /// True if there are new unread messages
        /// </summary>
        public bool NewContentAvailable { get; set; }
        /// <summary>
        /// True if this item is currently active
        /// </summary>
        public bool IsSelected { get; set; }

    }
}
