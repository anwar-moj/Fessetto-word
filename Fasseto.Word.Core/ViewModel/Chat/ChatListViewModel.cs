using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A view model the overview chat list
    /// </summary>
    public class ChatListViewModel:BaseViewModel
    {
        /// <summary>
        /// The chat list Items
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
        
    }
}
