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

        public List<ParkData> Parks { get; set; }

        public List<ColumnData> Columns { get; set; }

        public TabControlsViewModel()
        {
            Parks = new()
            {
                new ParkData()
                {
                    Name = "Acadia",
                    State = "Maine",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/93/Bass_Harbor_Head_Light_Station_2016.jpg/800px-Bass_Harbor_Head_Light_Station_2016.jpg",
                    Area = 198.6,
                    Established = 1919
                },
                new ParkData()
                {
                    Name = "Arches",
                    State = "Utah",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/78/USA_Arches_NP_Delicate_Arch%281%29.jpg/800px-USA_Arches_NP_Delicate_Arch%281%29.jpg",
                    Area = 310.3,
                    Established = 1971
                },
                new ParkData()
                {
                    Name = "Big Bend",
                    State = "Texas",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/On_the_Border_%2839960085292%29.jpg/800px-On_the_Border_%2839960085292%29.jpg",
                    Area = 3242.2,
                    Established = 1944
                }
            };

            Columns = new List<ColumnData>()
            {
                new ColumnData() { Parks2 = Parks },
                new ColumnData() { Parks2 = Parks }
            };
        }

    }

    public class ParkData
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string ImageUrl { get; set; }
        public double Area { get; set; }
        public int Established { get; set; }
    }

    public class ColumnData
    {
        public List<ParkData> Parks2 { get; set; }
    }
}

