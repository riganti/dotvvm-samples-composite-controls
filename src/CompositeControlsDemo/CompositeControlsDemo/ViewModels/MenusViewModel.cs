using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace CompositeControlsDemo.ViewModels
{
    public class MenusViewModel : MasterPageViewModel
    {

        public List<PageEntry> MenuItems { get; set; } = new()
        {
            new PageEntry() { Title = "Page 1", Id = 1 },
            new PageEntry() { Title = "Page 2", Id = 2 },
            new PageEntry() { Title = "Page 3", Id = 3 }
        };

        [FromRoute("PageIndex")]
        public int ActivePageIndex { get; set; } = 1;

    }

    public class PageEntry
    {
        public string Title { get; set; }

        public int Id { get; set; }
    }

}

