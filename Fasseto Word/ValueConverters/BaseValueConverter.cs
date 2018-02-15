using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasseto_Word
{
    /// <summary>
    /// A base value converter that allow direct XAML usage
    /// </summary>
    /// <typeparam name="T">The type of the value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Method Members

        /// <summary>
        /// A single static instance to this value converter 
        /// </summary>
        private static T mConverter = null;

        #endregion

        #region Markup Extention Methods
        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => mConverter ?? (mConverter = new T());

        #endregion

        #region Value converter methods
        /// <summary>
        /// The Method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        /// <summary>
        /// A method to convert a value back to its source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        #endregion
    }
}
