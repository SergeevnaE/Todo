using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Desktop
{
    public static class PageTransition
    {
        public static void Transition(Page current, Page next)
        {
            if (current == null || next == null)
                return;

            current.Opacity = 1.0;

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            fadeOutAnimation.Completed += (s, e) =>
            {
                current.NavigationService.Navigate(next);
                next.Opacity = 0.0;
                DoubleAnimation fadeInAnimation = new DoubleAnimation
                {
                    From = 0.0,
                    To = 1.0,
                    Duration = TimeSpan.FromSeconds(0.3)
                };
                next.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            };

            current.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
        }
    }
}