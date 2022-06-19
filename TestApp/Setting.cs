using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
  public class Setting : BindableBase
  {
    private double _width;
    public double Width { get=>_width; set
      {
        if (value == _width)
          return;
        _width = value;
        IsModified = true;
        RaisePropertyChanged();
      }
    }
    private bool _isModified;
    public bool IsModified { get=>_isModified; set=>SetProperty(ref _isModified,value); }
  }
}
