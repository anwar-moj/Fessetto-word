using System.Windows;
using System.Windows.Input;
using System.Security;
using System;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The View Model for a Login Page
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Member

        #endregion

        #region Public Properties

        /// <summary>
        /// The email for the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag Indecating if the command login is runing
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to Login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to Register for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {

            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter) );
            // Create commands
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());

        }



        #endregion
        /// <summary>
        /// attempt to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view </param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async() =>
            {
                await Task.Delay(1000);
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
                //var emial = Email;
                //IMPORTANT: Never store unsecure password in a variable like this
                //var pass = (parameter as IHavePassword).securePassword.Unsecure();
            });
            
        }
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            //return;
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            //TODO: Go to the register page
            await Task.Delay(1);
        }

    }
}