using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Fasseto_Word
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {

        #region Public Properties
        /// <summary>
        /// A flag indicating if this is the first time this property has been changed
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            //Don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            //On First load
            if (FirstLoad)
            {
                //Create a single self)unhookable event
                //For the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    //Unhook ourselves
                    element.Loaded -= onLoaded;

                    //Do desired animation
                    DoAnimation(element, (bool)value);

                    //No longer in first load
                    FirstLoad = false;
                };
                //Hook into the loaded event of the element
                element.Loaded += onLoaded;
            }
            else
                //Do desired animation
                DoAnimation(element, (bool)value);
        }
        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="value">The value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }

    /// <summary>
    /// Animates a fraework element sliding it in from the left on show
    /// and sliding out to the left on hide
    /// </summary>
    public class AnimationSlideInFromLeftProperty : AnimateBaseProperty<AnimationSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                //Animate In
                await element.SlideAndFadeInFromLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                //Animate out
                await element.SlideAndFadeOutToLeft(FirstLoad ? 0 : 0.3f, keepMargin: false);

        }
    }
}
