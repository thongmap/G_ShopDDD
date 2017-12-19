namespace G_Shop.Areas.Admin.Controllers
{
    public class ReportInfo
    {
        public double? AvgPrice { get; set; }
        public int Count { get; set; }
        public string Group { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public int? Total { get; set; }
    }
}