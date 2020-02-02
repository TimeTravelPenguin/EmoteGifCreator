using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace TEA.Wpf.Behaviors
{
  internal class DropBehavior : Behavior<UIElement>
  {
    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty OnDroppedProperty =
      DependencyProperty.Register(nameof(OnDropped), typeof(ICommand), typeof(DropBehavior));


    public ICommand OnDropped
    {
      get => (ICommand) GetValue(OnDroppedProperty);
      set => SetValue(OnDroppedProperty, value);
    }


    protected override void OnAttached()
    {
      base.OnAttached();

      AssociatedObject.AllowDrop = true;
      AssociatedObject.DragEnter += AssociatedObject_DragEnter;
      AssociatedObject.DragOver += AssociatedObject_DragOver;
      AssociatedObject.DragLeave += AssociatedObject_DragLeave;
      AssociatedObject.Drop += AssociatedObject_Drop;
    }

    private void AssociatedObject_Drop(object sender, DragEventArgs e)
    {
      var dropped = e.Data.GetData(DataFormats.FileDrop);

      OnDropped.Execute(dropped);

      e.Handled = true;
    }

    private void AssociatedObject_DragLeave(object sender, DragEventArgs e)
    {
      e.Handled = true;
    }

    private void AssociatedObject_DragOver(object sender, DragEventArgs e)
    {
      e.Handled = true;
    }

    private void AssociatedObject_DragEnter(object sender, DragEventArgs e)
    {
      e.Handled = true;
    }
  }
}