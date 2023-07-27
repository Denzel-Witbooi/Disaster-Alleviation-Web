using Disaster_Alleviation_Web.Data;
using Disaster_Alleviation_Web.Models;
using Disaster_Alleviation_Web.Models.ReliefViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Disaster_Alleviation_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DisasterReliefContext db;

        public decimal totalGoods { get; set; }
        public decimal totalDonation { get; set; }
        public decimal totalDisasters { get; set; }
        public HomeController(ILogger<HomeController> logger, DisasterReliefContext disasterReliefContext)
        {
            _logger = logger;
            db = disasterReliefContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GoodsStats()
        {
            ViewBag.getTotalGoods = getTotalGoods();
            /*
             * The LINQ statement groups the goods entities 
             * by donation date, calculates the number of entities 
             * in each group, and stores the results in a 
             * collection of DonationGroup view model objects.
             */
            IQueryable<DonationGroup> data =
                from good in db.Goods
                group good by good.DonationDate into
                dateGroup
                select new DonationGroup()
                {
                    DonationDate = dateGroup.Key,
                    GoodsCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }
        public decimal getTotalGoods()
        {
            totalGoods = db.Goods
                .Sum(m => m.NumberOfItems);
            return totalGoods;
        }

        public decimal getTotalDonation()
        {
            totalDonation = db.Monetaries
                .Sum(m => m.DonationAmount);
            return totalDonation;
        }
        public async Task<ActionResult> MonetaryStats()
        {
            ViewBag.totalDonation = getTotalDonation().ToString("C0");
            /*
             * The LINQ statement groups the monetary entities 
             * by donation date, calculates the number of entities 
             * in each group, and stores the results in a 
             * collection of Monetary view model objects.
             */
            IQueryable<MonetaryGroup> data =
                from monetary in db.Monetaries
                group monetary by monetary.DonationDate into
                dateGroup
                select new MonetaryGroup()
                {
                    DonationDate = dateGroup.Key,
                    MonetaryCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public decimal getTotalActiveDisasters()
        {
            totalDisasters = db.Disasters.Where(x => x.StartDate >= DateTime.Today).Count();
            return totalDisasters;
        }

        public async Task<ActionResult> DisasterStats()
        {
            ViewBag.totalDisasters = getTotalActiveDisasters();
            /*
             * The LINQ statement groups the disaster entities 
             * by Start date, calculates the number of entities 
             * in each group, and stores the results in a 
             * collection of DisasterGroup view model objects.
             */
            //IQueryable<DisasterGroup> data =
            //    from disaster in db.Disasters
            //    join goods in db.Goods
            //    on disaster.DisasterID equals goods.DisasterID
            //    group disaster by disaster.StartDate into
            //    dateGroup
            //    select new DisasterGroup()
            //    {
            //        Active = DateTime.Today,
            //        ActiveDate = dateGroup.Key,
            //        DisasterCount = dateGroup.Count()
            //    };

            var disasterViewModel = from disaster in db.Disasters
                                    join goods in db.Goods on disaster.DisasterID equals goods.DisasterID into disasterGood
                                    from goods in disasterGood.DefaultIfEmpty()

                                    join category in db.Categories on goods.CategoryID equals category.CategoryID into categoryGood
                                    from category in categoryGood.DefaultIfEmpty()

                                    join goodspurchase in db.GoodsPurchases on disaster.DisasterID equals goodspurchase.DisasterId into disasterFund
                                    from goodspurchase in disasterFund.DefaultIfEmpty()
                                    select new DisasterGoodsInfo { DisasterVM = disaster, GoodVM = goods, CategoryVM = category, GoodsPurchaseVM = goodspurchase };

            return View(await disasterViewModel.AsNoTracking().ToListAsync());
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}