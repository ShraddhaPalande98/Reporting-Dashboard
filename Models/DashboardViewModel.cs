namespace ReportingDashboard.Models
{
    public class DashboardViewModel
    {
        public List<CategorySalesData> CategorySales { get; set; }
        public List<ProductSalesData> MostPopularProducts { get; set; }
        public List<SalesTrendData> SalesTrend { get; set; }
    }

    public class CategorySalesData
    {
        public string Category { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class ProductSalesData
    {
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
    }

    public class SalesTrendData
    {
        public string Date { get; set; }
        public decimal TotalSales { get; set; }
    }
}
