using System.Collections.Generic;

namespace BestBuy.Models
{
    public class ValidationCriteria
    {
        public string LowerNumber { get; set; }
        public string HigherNumber { get; set; }
        public List<string> ObjectsToValidate { get; set; }
    }
}
