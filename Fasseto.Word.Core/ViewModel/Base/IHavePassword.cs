using System.Security;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// An interface that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The secure password
        /// </summary>
        SecureString securePassword { get; }
    }
}
