using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Web.Models.ReliefViewModels
{
    public class MonetaryGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }

        public int MonetaryCount { get; set; }
    }
}
