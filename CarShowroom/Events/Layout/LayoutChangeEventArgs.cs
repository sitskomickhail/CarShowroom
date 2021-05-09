using System;
using System.Windows;

namespace CarShowroom.Events.Layout
{
    public class LayoutChangeEventArgs : EventArgs
    {
        public readonly Rect Rect;
        public LayoutChangeEventArgs(Rect rect) => Rect = rect;
    }
}