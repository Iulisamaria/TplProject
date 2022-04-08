using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tplProject.ViewModels
{
    public class BaseNewsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
    public class AddNewsViewModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
    public class UpdateNewsViewModel:BaseNewsViewModel
    {
    }
    public class NewsDetailsViewModel : BaseNewsViewModel
    {
    }
}

