using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportingDashboard.Data;
using ReportingDashboard.Models;
using System.Diagnostics;

namespace ReportingDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var dashboardData = new DashboardViewModel
            {
                CategorySales = await _context.Products
                                              .GroupBy(p => p.Category)
                                              .Select(g => new CategorySalesData
                                              {
                                                  Category = g.Key,
                                                  TotalSales = g.Sum(p => p.Price * p.Quantity)
                                              })
                                              .ToListAsync()
            };

            return View(dashboardData);
        }

        public async Task<IActionResult> Sales()
        {
            var dashboardData = new DashboardViewModel
            {
                MostPopularProducts = await _context.Products
                                                 .GroupBy(p => p.ProductName)
                                                 .Select(g => new ProductSalesData
                                                 {
                                                     ProductName = g.Key,
                                                     QuantitySold = g.Sum(p => p.Quantity)
                                                 })
                                                 .OrderByDescending(p => p.QuantitySold)
                                                 .Take(10)
                                                 .ToListAsync()
            };


            return View(dashboardData);
        }

        public async Task<IActionResult> Trend()
        {
            var dashboardData = new DashboardViewModel
            {
                SalesTrend = await _context.Products
                                            .GroupBy(p => new { p.DateAdded.Year, p.DateAdded.Month })
                                            .Select(g => new SalesTrendData
                                            {
                                                Date = $"{g.Key.Month}/{g.Key.Year}",
                                                TotalSales = g.Sum(p => p.Price * p.Quantity)
                                            })
                                            .ToListAsync()
            };


            return View(dashboardData);
        }

    }
}
