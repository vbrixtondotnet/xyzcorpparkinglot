using System;

namespace XYZCorp.ParkingLot.Utilities
{
    public static class Enums
    {
        public enum SlotSize
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
        public enum SlotStatus
        {
            Vacant = 0,
            Occupied = 1
        }
        public enum ParkingStatus
        {
            Parked = 1,
            Out = 2,
            Paid = 3
        }

        public enum State
        {
            Success,
            Fail
        }
    }
}
