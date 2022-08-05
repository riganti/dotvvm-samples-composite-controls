using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace CompositeControlsDemo.ViewModels
{
    public class FormControlsViewModel : MasterPageViewModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool AgeEnabled { get; set; }

    }
}

