using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_system
{
    public class Vehicle
    {
        //Declaring variables
        protected double min_fee;
        protected double add_charge;
        protected double max_fee;
        protected int max_time = 24;
        protected double _hours;

        //Constructor
        public Vehicle(double hours) //accept hours
        {
            this._hours = hours;

        }

        public virtual double Charges()
        {
            double total_fee = 0;


            if (_hours<= 3)

                return min_fee;

            else if (_hours > 3 && _hours<max_time)
            {
                total_fee = min_fee;
                
                while (_hours> 3)
                {
                    total_fee += add_charge;
                    _hours--;
                    if (total_fee > max_fee)
                    {
                        total_fee = max_fee;
                    }
                }
                return total_fee;

            }
            else
            {
                Console.WriteLine("Sorry you cannot park your vehicle for more than 24 hours");
                return total_fee;
            }
            
             
            

        }
      

    }

    public class Bike : Vehicle
    {
       public Bike(double hours) : base(hours)
        {

        }

        public override double Charges()
        {
         base.min_fee = 2.00;
         base.add_charge = 0.50;
         base.max_fee = 10;
         double charges = base.Charges();
         return charges;
    }

    }



    public class Cars : Vehicle
    {
        public Cars(double hours) : base(hours)
        {

        }

        public override double Charges()
        {
            base.min_fee = 4;
            base.add_charge = 1;
            base.max_fee = 20;
            double charges = base.Charges();
            return charges;
        }

    }

    public class Buses : Vehicle
    {
        public Buses(double hours) : base(hours)
        {

        }

        public override double Charges()
        {
            base.min_fee = 6;
            base.add_charge = 1.50;
            base.max_fee = 30;
            double charges = base.Charges();
            return charges;
        }

    }






    public class Parking
    {
        static void Main(string[] args)
        {
            int Customers;
            double hours;
            String type;
            
            Console.WriteLine("Please Enter Number of Customers");
            Customers = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= Customers; i++)
            {
                Console.WriteLine("Enter type of the vehicle");
                type = Console.ReadLine();
                Console.WriteLine("\nEnter Number of Hours parked by "+ i + " Customer");
                hours = (float.Parse(Console.ReadLine()));
               
                
                Bike B = new Bike(hours);
                Cars C = new Cars(hours);
                Buses Bs = new Buses(hours);

                if (type == "bike")
                    Console.WriteLine("\nCustomer " + i + " charges for Bike parking are " + B.Charges());
                else if (type == "car")
                    Console.WriteLine("\nCustomer " + i + " charges for Car parking are " + C.Charges());
                else if (type == "bus")
                    Console.WriteLine("\nCustomer " + i + " charges for Bus parking are " + Bs.Charges());
                else
                    Console.WriteLine("\nEnter valid vehicle");
            }

            Console.ReadLine();

        }
    }
}
