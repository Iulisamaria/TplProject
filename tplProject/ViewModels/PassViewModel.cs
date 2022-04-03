using System;

namespace tplProject.ViewModels
{
    public class PassViewModel
    {
    }
    public class BasePassViewModel
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdType { get; set; }
    }
    public class AddPassViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdType { get; set; }

    }

    public class DetailsPassViewModel:BasePassViewModel
    {

    }
   
}
