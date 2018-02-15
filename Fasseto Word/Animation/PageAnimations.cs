using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace Fasseto_Word
{
    /// <summary>
    /// Helpers to animate pages in a spesifec ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slid a page In from the right
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">Duration of the animation</param>
        /// <returns></returns>
        public static async Task SlidAndFadeInFromRight(this Page page, float seconds)
        {
            //Create a stroyboard
            var sb = new Storyboard();
            //Add slid from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Add fade in animation
            sb.AddFadeIn(seconds);
            //Start animating
            sb.Begin(page);
            //Make page visibile
            page.Visibility = Visibility.Visible;
            //Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }
        /// <summary>
        /// Slide a page Out to the left
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">Duration of the animation</param>
        /// <returns></returns>
        public static async Task SlidAndFadeOutFromLeft(this Page page, float seconds)
        {
            //Create a stroyboard
            var sb = new Storyboard();
            //Add slid from left animation
            sb.AddSlideFromLeft(seconds, page.WindowWidth);

            //Add fade out animation
            sb.AddFadeOut(seconds);
            //Start animating
            sb.Begin(page);
            //Make page visibile
            page.Visibility = Visibility.Visible;
            //Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }
    }
}
