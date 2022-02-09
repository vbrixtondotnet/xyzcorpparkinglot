using System;
using XYZCorp.ParkingLot.BusinessLogic.Interfaces;
using XYZCorp.ParkingLot.Utilities;

namespace XYZCorp.ParkingLot.BusinessLogic
{
    public class SlotBL : ISlotBL
    {
        public string GetStatus(int slotStatus)
        {
            switch (slotStatus)
            {
                case (int)Enums.SlotStatus.Vacant:
                    return "VACANT";
                case (int)Enums.SlotStatus.Occupied:
                    return "OCCUPIED";
            }
            return string.Empty;
        }
    }
}
