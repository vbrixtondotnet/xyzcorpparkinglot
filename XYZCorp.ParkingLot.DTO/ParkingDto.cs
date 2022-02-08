using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using XYZCorp.ParkingLot.Utilities;

namespace XYZCorp.ParkingLot.DTO
{
    public class ParkingRequestDto
    {
        public int ID { get; set; }
        public string PlateNo { get; set; }
        public int SlotId { get; set; }
    }

    public class ParkingOutRequestDto
    {
        public int ParkingID { get; set; }
    }

    public class ParkingPaymentRequestDto
    {
        public int ParkingID { get; set; }
        public decimal Amount { get; set; }
    }

    public class ParkingResponseDto
    {
        public int ID { get; set; }
        public string PlateNo { get; set; }
        public int SlotID { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End{get;set; }
        public string Status { get; set; }
        public SlotDto Slot{get;set;}

        [JsonIgnore]
        public Enums.State State { get; set; }
        public string Message { get; set; }
    }

    public class ParkingOutResponseDto
    {
        public int ParkingID { get; set; }
        public string PlateNo { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int TotalHours { get; set; }
        public int ExcessHours { get; set; }
        public decimal TotalAmountPayable { get; set; }
        public string Status { get; set; }
        public SlotDto Slot { get; set; }
        public BaseRateDto BaseRates { get; set; }
        public SlotRateDto SlotRates{ get; set; }
    }
    public class ParkingPaymentResponseDto
    {
        public int ParkingID { get; set; }
        public string PlateNo { get; set; }
        public int TotalHours { get; set; }
        public int ExcessHours { get; set; }
        public decimal AmountPaid { get; set; }
        public string Status { get; set; }
        public SlotDto Slot { get; set; }
    }
}
