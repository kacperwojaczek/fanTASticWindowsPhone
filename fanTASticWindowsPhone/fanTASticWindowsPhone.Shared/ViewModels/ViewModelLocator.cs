using System;
using System.Collections.Generic;
using System.Text;

namespace fanTASticWindowsPhone.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel { get; private set; }
        public ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
        }
    }
}
