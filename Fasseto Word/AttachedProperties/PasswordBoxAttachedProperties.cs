using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto_Word
{

    /// <summary>
    /// The MonitorPassword attached Property for <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty:BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the caller
            var passwordBox = (sender as PasswordBox);
            //make sure that is a PasswordBox
            if (passwordBox == null)
                return;
            //Remove any previous Event
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
            //If the caller set MonitorPassword to true...
            if ((bool)e.NewValue)
            {
                //Set Default property
                HasTextProperty.SetValue(passwordBox);
                //Star listening out for password Changes
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged; ;
            }
        }
        /// <summary>
        /// fires when the passwordbox value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Set the HasText attached value
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }
    /// <summary>
    /// The HasText attached Property for <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty:BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            SetValue((PasswordBox)sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
