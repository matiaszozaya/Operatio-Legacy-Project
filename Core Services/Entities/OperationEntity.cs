using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Services.Entities
{
    public class OperationEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public decimal? AmountARS { get; set; }
        public decimal? AmountUSD { get; set; }
        public DateTime? Date { get; set; }
    }
}