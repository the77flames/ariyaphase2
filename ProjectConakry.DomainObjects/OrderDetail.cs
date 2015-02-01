using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConakry.DomainObjects
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public string BoughtFrom { get; set; }
        public string IncomingTrackingNumber { get; set; }
        public string OutgoingTrackingNumber { get; set; }
        public int WeightInPounds { get; set; }
        public int AmountPaidToShipInDollars { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
