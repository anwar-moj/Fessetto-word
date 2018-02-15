
using System;
using System.Windows;

namespace Fasseto_Word
{
    /// <summary>
    /// A base Attached Property to replace the vanilla WPF attached Property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be the attached property</typeparam>
    /// <typeparam name="Property">the type of the attached Property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : new()
    {

        #region Public Events 
        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        /// <summary>
        /// Fired when the value changed, even when the value is the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public Properties
        /// <summary>
        /// A singleton of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// The attached Property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(Property),
            typeof(BaseAttachedProperty<Parent, Property>),
            new PropertyMetadata(
                default(Property),
                new PropertyChangedCallback(OnValuePropertyChanged),
                new CoerceValueCallback(OnValuePropertyUpdated)
                    ));

        /// <summary>
        /// The callback event <see cref="ValueProperty"/> is Changed 
        /// </summary>
        /// <param name="d">The UI element that had its property changed</param>
        /// <param name="e">The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(d, e);
            //Call Event listener
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueChanged(d, e);
        }
        /// <summary>
         /// The callback event <see cref="ValueProperty"/> is Changed, even if it is the same value
         /// </summary>
         /// <param name="d">The UI element that had its property changed</param>
         /// <param name="e">The argument for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            //Call the parent function
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(d, value);
            //Call Event listener
            (Instance as BaseAttachedProperty<Parent, Property>)?.ValueUpdated(d, value);

            //Return the value
            return value;
        }
        /// <summary>
        /// Gets the attached property 
        /// </summary>
        /// <param name="d">The element to get the peroperty from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        /// <summary>
        /// Sets the attached Property
        /// </summary>
        /// <param name="d">The element to set the peroperty for</param>
        /// <param name="value">The value to set to the property</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);
        #endregion

        #region Event Methods
        /// <summary>
        /// The mathod that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that is this property was changed for</param>
        /// <param name="e">The argument for the event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        /// <summary>
        /// The mathod that is called when any attached property of this type is changed, even if the value is the same
        /// </summary>
        /// <param name="sender">The UI element that is this property was changed for</param>
        /// <param name="e">The argument for the event</param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }
        #endregion
    }

}
