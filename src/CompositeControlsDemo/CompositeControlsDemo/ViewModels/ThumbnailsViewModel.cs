using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace CompositeControlsDemo.ViewModels
{
    public class ThumbnailsViewModel : MasterPageViewModel
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

