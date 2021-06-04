using System;

namespace HWS._6_2
{
    class Program
    {
        enum Instock
        {
            SoapPukPick = 49 ,
            HandCream = 40,
            Shippingcost = 25 
        }


        static void Homepage()
        {
            Console.WriteLine("No.1 Order Soap");
            Console.WriteLine("No.2 Setting stock. (Owner only) ");
            Console.WriteLine("No.3 Finish");
        }
        static int inputHomePage(int ModeNum)
        {
            while (ModeNum != 1 && ModeNum != 2 && ModeNum != 3)
            {
                Console.WriteLine("Please input 1-3.");
                ModeNum = int.Parse(Console.ReadLine());
            }
            return ModeNum;
        }

            static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Pukpick ");
            int NumPage ,NewNumPage , Orderstuff ,Price, NumHandCream, Numsoap;
            string Address ,Name;
            int CountSoap = 0;
            int CountHanadCream = 0; 
            int SoapPukpick = 100;
            int HandCream = 100;
            NumHandCream = 0;
            Numsoap = 0;
            Price = ((int)Instock.SoapPukPick * CountSoap) + ((int)Instock.HandCream * CountHanadCream);
            string  PickOrder;

            Console.WriteLine("Soap Pukpuck : {0} Bath",(int)Instock.SoapPukPick);
            Console.WriteLine("HandCream : {0}",(int)Instock.HandCream);
            Console.WriteLine("Shipping Cost : {0}",(int)Instock.Shippingcost);
            Console.WriteLine();
            Console.Write("Please Enter your Shipping address first:");
            Address = Console.ReadLine();
            Console.Write("Please Enter your Name:");
            Name = Console.ReadLine();
            Console.WriteLine();
            bool Order = true;
            bool TofinishOrder = true;
            Console.WriteLine("Soap in stock : {0}", (SoapPukpick - CountSoap) + Numsoap);
            Console.WriteLine("HandCream in stock : {0}", (HandCream - CountHanadCream) + NumHandCream);

            while (Order == true)
            {
                Homepage();
                NumPage = int.Parse(Console.ReadLine());
                NewNumPage = inputHomePage(NumPage);
                if (NumPage == 1 || NewNumPage ==1)
                {
                    
                    Console.WriteLine("To finish Order Please type '0',");
                    Console.WriteLine();
                    while (TofinishOrder == true)
                    {
                        Console.Write("Input Order ,You need to Order :");
                        PickOrder = Console.ReadLine();
                        
                        if (PickOrder == "Soap")
                        {
                            Console.Write("How much you need? :");
                            Orderstuff = int.Parse(Console.ReadLine());
                            SoapPukpick -= Orderstuff;
                            CountSoap = CountSoap + Orderstuff;
                        }
                        else if (PickOrder == "HandCream")
                        {
                            Console.Write("How much you need? :");
                            Orderstuff = int.Parse(Console.ReadLine());
                            HandCream -= Orderstuff;
                            CountHanadCream = CountHanadCream + Orderstuff;
                        }
                        if (PickOrder == "0")
                        {
                            TofinishOrder = false;
                            Console.WriteLine();
                        }

                    }
                    
                }
                else if (NumPage == 2 || NewNumPage == 2)
                {
                    int PassWord = 150200;
                    Console.Write(" Enter PassWord Owner :");
                    int PasswordOwner = int.Parse(Console.ReadLine());
                    if (PasswordOwner == 150200)
                    {
                        Console.Write("Soap Pucpick :");
                        Numsoap = int.Parse(Console.ReadLine());
                        Console.Write("HandCream :");
                        NumHandCream = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Soap in stock : {0}", SoapPukpick + Numsoap);
                        Console.WriteLine("HandCream in stock : {0}", HandCream + NumHandCream);
                        Console.WriteLine();
                    }
                    else if (PasswordOwner != 150200)
                    {
                        Console.WriteLine("You're not Store Owner");
                    }
                }
                else if (NumPage == 3 || NewNumPage == 3)
                {
                    Order = false;
                    Price = ((int)Instock.SoapPukPick * CountSoap) + ((int)Instock.HandCream * CountHanadCream);
                    Console.WriteLine("{1} Address : {0}", Address, Name);
                    Console.WriteLine("Your quantity is :{0}", CountSoap + CountHanadCream);
                    Console.WriteLine("Shipping cost : " + (int)Instock.Shippingcost);
                    Console.WriteLine("Your total amount :{0} ", Price + (int)Instock.Shippingcost);
                    Console.WriteLine("Order status : Waiting for Shipment");
                    Console.WriteLine();
                }
            }
            

        }
    }
}
