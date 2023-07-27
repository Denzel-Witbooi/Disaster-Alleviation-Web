using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Web.Models.ReliefViewModels
{
    public class DonationGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }

        public int GoodsCount { get; set; }
    }
}
