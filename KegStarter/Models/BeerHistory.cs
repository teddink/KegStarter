using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace KegStarter.Models
{
    public class BeerHistory
    {
        public int BeerHistoryId { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; }
        public bool Current { get; set; }
        public System.DateTime? DateTapped { get; set; }
    }
}