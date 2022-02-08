using System;

namespace XYZCorp.ParkingLot.Domain
{
    public abstract class BaseDomain
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? ModifiedBy { get; set; }
    }
}
