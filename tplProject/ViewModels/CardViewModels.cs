namespace tplProject.ViewModels
{
    public class BaseCardViewModels
    {
        public int Id { get; set; }
        public int? Routes { get; set; }
        public int? PassId { get; set; }
    }
    public class GetPassIdViewModel
    {
        public int Id { get; set; }
    }
    public class DetailsCardViewModels
    {
        public int? Routes { get; set; }
        public int? PassId { get; set; }
    }
    public class GetPassCardViewModels
    {
        public string PassName { get; set; }
    }
    public class GetTicketsCardViewModels
    {
        public int? Routes { get; set; }
    }
}
