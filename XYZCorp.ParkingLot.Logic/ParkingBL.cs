using System;
using XYZCorp.ParkingLot.BusinessLogic.Interfaces;
using XYZCorp.ParkingLot.Domain;
using XYZCorp.ParkingLot.Utilities;

namespace XYZCorp.ParkingLot.BusinessLogic
{
    public class ParkingBL : IParkingBL
    {
        public string GetStatus(int parkingStatus)
        {
            switch (parkingStatus)
            {
                case (int)Enums.ParkingStatus.Parked:
                    return "PARKED";
                case (int)Enums.ParkingStatus.Out:
                    return "OUT";
                case (int)Enums.ParkingStatus.Paid:
                    return "PAID";
            }
            return string.Empty;
        }
        public int CalculateTotalHours(Parking parking)
        {
            return (int)Math.Round(((DateTime)parking.End - parking.Start).TotalHours, 1);
        }
        public int CalculateExcessHours(Parking parking)
        {
            int totalParkingHours = CalculateTotalHours(parking);
            return (int)Math.Round((decimal)totalParkingHours - 3, 1);
        }
        public decimal CalculateParkingCharge(Parking parking, SlotRate slotRates, BaseRate baseRates)
        {
            decimal chargeableAmount = 0;

            // get total number of hours parked
            int totalParkingHours = CalculateTotalHours(parking);

            //All types of car pay the flat rate of 40 pesos for the first three (3) hours;
            chargeableAmount = baseRates.FlatRate;

            //For parking that exceeds 24 hours, every full 24 hour chunk is charged 5,000 pesos regardless of parking slot.
            if (totalParkingHours > 24)
            {
                chargeableAmount += (totalParkingHours / 24) * baseRates.ExcessRate;

                //calculate excess per hour
                var excessHours = totalParkingHours % 24;
                if(excessHours > 0)
                {
                    chargeableAmount += excessHours * slotRates.RatePerHour;
                }
            }
            else
            {
                // calculate excess per hour
                if (totalParkingHours > 3)
                {
                    var excess = CalculateExcessHours(parking);
                    chargeableAmount += excess * slotRates.RatePerHour;
                }
            }
            return chargeableAmount;
        }
    }
}
