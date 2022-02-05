using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmControls.Composite.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool AgeEnabled { get; set; }
    }
}
