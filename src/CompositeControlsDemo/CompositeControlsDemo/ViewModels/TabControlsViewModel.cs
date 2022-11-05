using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace CompositeControlsDemo.ViewModels
{
    public class TabControlsViewModel : MasterPageViewModel
    {

        public List<ParkData> Parks { get; set; } = new()
        {
            new ParkData()
            {
                Name = "Acadia",
                State = "Maine",
                ImageUrl = "https://en.wikipedia.org/wiki/File:Bass_Harbor_Head_Light_Station_2016.jpg",
                Area = 198.6,
                Established = 1919
            },
            new ParkData()
            {
                Name = "Arches",
                State = "Utah",
                ImageUrl = "https://en.wikipedia.org/wiki/File:USA_Arches_NP_Delicate_Arch(1).jpg",
                Area = 310.3,
                Established = 1971
            },
            new ParkData()
            {
                Name = "Big Bend",
                State = "Texas",
                ImageUrl = "https://en.wikipedia.org/wiki/File:On_the_Border_(39960085292).jpg",
                Area = 3242.2,
                Established = 1944
            }
        };

    }

    public class ParkData
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
        public double Area { get; set; }
        public int Established { get; set; }
    }
}

