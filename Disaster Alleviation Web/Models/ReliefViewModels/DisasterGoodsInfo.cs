using Disaster_Alleviation_Web.Models.Donation;

namespace Disaster_Alleviation_Web.Models.ReliefViewModels
{
    public class DisasterGoodsInfo
    {
        public Disaster DisasterVM { get; set; }
        public Good GoodVM { get; set; }
        public Category CategoryVM { get; set; }
        public GoodsPurchase GoodsPurchaseVM { get; set; }
    }
}
