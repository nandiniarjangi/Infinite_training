using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////Exception Handling :  
//1.
//•	You have a class which has methods for transaction for a banking system. (created earlier)
//•	Define your own methods for deposit money, withdraw money and balance in the account.
//•	Write your own new application Exception class called InsuffientBalanceException.
//•	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
//•	Identify and categorize all possible checked and unchecked exception.

namespace Assignment_5
{
    class Insufficient_Balance_Exception : ApplicationException
    {
        public Insufficient_Balance_Exception(string msg) : base(msg)
        {

        }
    }
    class ExceptionHandling
    {
        public int amount;
        public int balance;
        public string transaction_type;

        public ExceptionHandling(int amo, int bal, string trans_type)
        {
            amount = amo;
            balance = bal;
            transaction_type = trans_type;
        }
        public void Deposit(int amount, int balance)
        {
            balance = balance + amount;
            Console.WriteLine("The balance after depositing amount {0} is {1}", amount, balance);
        }
        public void WithDraw(int amount, int balance)
        {
            try
            {
                if (amount > balance)
                {
                    throw (new Insufficient_Balance_Exception("Customer does not have sufficient balance"));
                }
                else
                {
                    balance = balance - amount;
                    Console.WriteLine("The balance after withdrawing amount {0} is {1}", amount, balance);
                }
            }
            catch (Insufficient_Balance_Exception insufficient_balance)
            {
                Console.WriteLine("Error :" + insufficient_balance.Message);
            }

        }
        public void Update_Balance(string transac_type)
        {
            if (transac_type == "d" || transac_type == "D")
            {
                Deposit(amount, balance);
            }
            else if (transac_type == "w" || transac_type == "W")
            {
                WithDraw(amount, balance);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the balance");
            int bal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the amount");
            int amo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the transaction type");
            string trans_type = Console.ReadLine();

            ExceptionHandling obj = new ExceptionHandling(amo, bal, trans_type);

            obj.Update_Balance(trans_type);
            Console.Read();

        }
    }
}
