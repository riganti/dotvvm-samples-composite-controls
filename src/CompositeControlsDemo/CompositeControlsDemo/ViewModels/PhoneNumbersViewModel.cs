using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace CompositeControlsDemo.ViewModels
{
    public class PhoneNumbersViewModel : MasterPageViewModel
    {
        public List<string> PhoneNumbers { get; set; } = new()
        {
            null,
            "123 456 789"
        };

    }
}

