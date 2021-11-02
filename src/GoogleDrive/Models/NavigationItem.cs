using ModernWpf.Controls;
using System;

namespace GoogleDrive.Models
{
    internal class NavigationItem : NavigationViewItem
    {
        Action action;

        public NavigationItem(Action action)
        {
            this.action = action;
        }
        internal void Invoke()
        {
            if (this.action != null)
            {
                this.action();
            }
        }
    }
}
