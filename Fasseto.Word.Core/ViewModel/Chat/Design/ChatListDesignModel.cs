using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design-time date for the <see cref="ChatListDesignModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singletone
        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "This how we do thing us lazy people!",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "JE",
                    Message = "Hey dude, This the new look of our app",
                    ProfilePictureRGB = "f1c40f"
                },
                new ChatListItemViewModel
                {
                    Name = "Parnelle",
                    Initials = "PA",
                    Message = "Our new database need to be set agin, but I don't have much of time",
                    ProfilePictureRGB = "2ecc71",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Name = "Sora-senpai",
                    Initials = "SO",
                    Message = "This my lovely name I guess you should now about it",
                    ProfilePictureRGB = "1abc9c"
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "LM",
                    Message = "This how we do thing us lazy people!",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "JE",
                    Message = "Hey dude, This the new look of our app",
                    ProfilePictureRGB = "f1c40f"
                },
                new ChatListItemViewModel
                {
                    Name = "Parnelle",
                    Initials = "PA",
                    Message = "Our new database need to be set agin, but I don't have much of time",
                    ProfilePictureRGB = "2ecc71"
                },
                new ChatListItemViewModel
                {
                    Name = "Sora-senpai",
                    Initials = "SO",
                    Message = "This my lovely name I guess you should now about it",
                    ProfilePictureRGB = "1abc9c"
                },
            };
        }
        #endregion


    }
}
