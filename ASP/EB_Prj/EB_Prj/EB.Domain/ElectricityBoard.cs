using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EB.Data;

namespace EB.Domain
{
    public class ElectricityBoard
    {
        private readonly DBHandler _db;

        public ElectricityBoard()
        {
            _db = new DBHandler();
        }

        // Slab calculation exactly per spec
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double total = 0;

            int remaining = units;

            // First 100 units free
            int take = Math.Min(remaining, 100);
            total += take * 0.0;
            remaining -= take;

            // 101–300 @ 1.5
            if (remaining > 0)
            {
                take = Math.Min(remaining, 200);
                total += take * 1.5;
                remaining -= take;
            }

            // 301–600 @ 3.5
            if (remaining > 0)
            {
                take = Math.Min(remaining, 300);
                total += take * 3.5;
                remaining -= take;
            }

            // 601–1000 @ 5.5
            if (remaining > 0)
            {
                take = Math.Min(remaining, 400);
                total += take * 5.5;
                remaining -= take;
            }

            // >1000 @ 7.5
            if (remaining > 0)
            {
                total += remaining * 7.5;
            }

            ebill.BillAmount = total;
        }

        public void AddBill(ElectricityBill ebill)
        {
            using (var con = _db.GetConnection())
            using (var cmd = new SqlCommand(@"
                INSERT INTO dbo.ElectricityBill(consumer_number, consumer_name, units_consumed, bill_amount)
                VALUES (@no, @name, @units, @amount);", con))
            {
                cmd.Parameters.AddWithValue("@no", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            var list = new List<ElectricityBill>();

            using (var con = _db.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT TOP (@n) consumer_number, consumer_name, units_consumed, bill_amount
                FROM dbo.ElectricityBill
                ORDER BY bill_id DESC;", con))
            {
                cmd.Parameters.Add("@n", SqlDbType.Int).Value = num;

                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        var eb = new ElectricityBill
                        {
                            // ConsumerNumber setter validates format; data in DB should be valid
                            ConsumerNumber = rd.GetString(0),
                            ConsumerName = rd.GetString(1),
                            UnitsConsumed = rd.GetInt32(2),
                            BillAmount = rd.GetDouble(3)
                        };
                        list.Add(eb);
                    }
                }
            }

            return list;
        }
    }
}
