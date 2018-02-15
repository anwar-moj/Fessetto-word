using Fasseto.Word.Core;
using System.Security;

namespace Fasseto_Word
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The secure password for this view
        /// </summary>
        public SecureString securePassword => PasswordText.SecurePassword;
    }
}
