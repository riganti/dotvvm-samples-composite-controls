using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace PhoneNumbers.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

        public List<string> PhoneNumbers { get; set; } = new()
        {
            null,
            "123 456 789"
        };

    }
}
