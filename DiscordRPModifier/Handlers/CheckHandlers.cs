using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DiscordRPModifier.Handlers
{
    static class CheckHandlers
    {
        //function for finding what type of control it is.
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static bool CheckBoxes(MainWindow window)
        {
            foreach (TextBox t in FindVisualChildren<TextBox>(window.DetailsGrid))
            {
                //Part_TextBox is part of the IntegerUpAndDown and doesnt like this
                if (t.Text.Length <= 1 && t.Name != "PART_TextBox")
                {
                    MessageBox.Show("All fields must contain at least 2 characters!");
                    return false;
                }
            }
            return true;
        }
    }
}
