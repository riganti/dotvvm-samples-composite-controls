using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;

namespace DotvvmControlsDemo.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {

        public List<Person> People { get; set; } = new List<Person>()
        {
            new Person()
            {
                Name = "Tomáš Herceg",
                ImageUrl = "https://www.tomasherceg.com/img/header/13_1200.jpg"
            },
            new Person()
            {
                Name = "Humphrey Appleby",
                ImageUrl = ""
            }
        };

    }

    public class Person
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
