using System.Windows;
using System.Windows.Media;

namespace AdventRunner.Helpers
{
    public static class DependencyObjectExtensions
    {
        public static T FindChild<T>(this DependencyObject parent, string childName)
            where T : DependencyObject
        {
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is not T dependencyObject)
                {
                    foundChild = FindChild<T>(child, childName);

                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    if (dependencyObject is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                    {
                        foundChild = dependencyObject;
                        break;
                    }
                }
                else
                {
                    foundChild = dependencyObject;
                    break;
                }
            }

            return foundChild;
        }
    }
}