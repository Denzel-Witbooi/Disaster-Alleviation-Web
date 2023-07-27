using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Disaster_Alleviation_Web.Models.Donation
{
    public class Monetary
    {
        public int MonetaryID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Donation Amount")]
        public decimal DonationAmount { get; set; }

        [DisplayFormat(NullDisplayText = "anonymous")]
        [Display(Name = "Donor Name")]
        public string DonorName { get; set; }
    }
}
