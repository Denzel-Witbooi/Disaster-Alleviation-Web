using Disaster_Alleviation_Web.Models.Donation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Web.Models
{
    public class GoodsPurchase
    {
        public int GoodsPurchaseId { get; set; }

        public int DisasterId { get; set; }
        public int MonetaryId { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Purchase Price")]
        public decimal purchaseAmount { get; set; }

        public Disaster Disaster { get; set; }
        public Monetary Monetary { get; set; }
    }
}
