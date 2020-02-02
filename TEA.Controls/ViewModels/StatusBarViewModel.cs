using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TEA.Core.ExtensionMethods;
using TEA.Core.Resources;
using TEA.Core.Types;

namespace TEA.Controls.ViewModels
{
  internal class StatusBarViewModel : PropertyChangedBase
  {
    private static readonly string Default = TextStringResources.NoFilesSelected;
    private string _statusMessage;

    public string StatusMessage
    {
      get => _statusMessage;
      private set => SetValue(ref _statusMessage, value);
    }

    public StatusBarViewModel() : this(Default)
    {
    }

    private StatusBarViewModel(string initialMessage)
    {
      StatusMessage = initialMessage;
    }

    public void UpdateStatus(IReadOnlyList<string> files)
    {
      
    }
  }
}