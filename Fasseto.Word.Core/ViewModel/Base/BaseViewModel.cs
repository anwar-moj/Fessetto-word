using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers
        /// <summary>
        /// Runs a command if the updating is not set
        /// If the flag is true (Indecating the function is already running) then the action is not runing
        /// If the flag is flase (Indecting the function is not running) the the actiong is running
        /// Once the action is finished if it was run, then the flag is reset to false;
        /// </summary>
        /// <param name="UpdatingFlag">The boolean property flage defining if the command is already runing</param>
        /// <param name="action">The action to run if the comand is not runing</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> UpdatingFlag, Func<Task> action)
        {
            //Check if the flag property is true (meaning the function is already runing)
            if (UpdatingFlag.GetPropertyValue<bool>())
                return;

            //Set the property flag to true to indecation we are running
            UpdatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //Set the property flag back to flase
                UpdatingFlag.SetPropertyValue(false);
            }

        }

        #endregion
    }
}
