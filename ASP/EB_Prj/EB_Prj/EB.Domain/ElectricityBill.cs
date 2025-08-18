using System;
using System.Text.RegularExpressions;

namespace EB.Domain
{
    public class ElectricityBill
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber
        {
            get => consumerNumber;
            set
            {
                // Validates like "EB12345" (EB + 5 digits)
                if (value == null || !Regex.IsMatch(value.Trim(), @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");
                consumerNumber = value.Trim();
            }
        }

        public string ConsumerName
        {
            get => consumerName;
            set => consumerName = (value ?? string.Empty).Trim();
        }

        public int UnitsConsumed
        {
            get => unitsConsumed;
            set => unitsConsumed = value;
        }

        public double BillAmount
        {
            get => billAmount;
            set => billAmount = value;
        }
    }
}
