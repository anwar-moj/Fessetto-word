using System.Windows;
using System.Windows.Input;
using System.Security;
using System;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The View Model for a Register Page
    /// </summary>
    public class RegisterViewModel : BaseViewModel
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
        public bool RegisterIsRunning { get; set; }

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
        public RegisterViewModel()
        {

            // Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter) );
            // Create commands
            LoginCommand = new RelayCommand(async () => await LoginAsync());

        }



        #endregion
        /// <summary>
        /// attempt to Register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view </param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async() =>
            {
                await Task.Delay(5000);

                var emial = Email;

                //IMPORTANT: Never store unsecure password in a variable like this
                var pass = (parameter as IHavePassword).securePassword.Unsecure();
            });
            
        }
        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            //return;
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            //TODO: Go to the register page
            await Task.Delay(1);
        }

    }
}