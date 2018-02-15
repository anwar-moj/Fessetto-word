namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design-time date for the <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singletone
        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This how we do thing us lazy people!";
            ProfilePictureRGB = "3099c5";
        }
        #endregion


    }
}
