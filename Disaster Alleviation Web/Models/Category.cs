using Disaster_Alleviation_Web.Models.Donation;

namespace Disaster_Alleviation_Web.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Good> Goods { get; set; }
    }
}
