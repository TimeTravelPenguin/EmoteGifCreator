using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using TEA.Core.Types;

namespace TEA.Controls.ViewModels
{
  internal class GifAnimatorViewModel : PropertyChangedBase
  {
    private ObservableCollection<string> _files = new ObservableCollection<string>();

    public ObservableCollection<string> Files
    {
      get => _files;
      set => SetValue(ref _files, value);
    }

    public ICommand OnDroppedCommand => new DelegateCommand<IEnumerable<string>>(SetFiles);

    private void SetFiles(object dropped)
    {
      switch (dropped)
      {
        case null:
          throw new ArgumentNullException(nameof(dropped));
        case IEnumerable<string> files:
        {
          foreach (var file in files)
          {
            Files.Add(file);
          }

          OnPropertyChanged(nameof(Files));
          break;
        }
        default:
          throw new InvalidOperationException();
      }
    }
  }
}