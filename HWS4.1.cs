using System;

namespace HomeworkS4
{
    class Program
    {
        static void Main(string[] args)
        {

            //ข้อ1
            int n, r, Num;
            int wall = 0;
            Num = int.Parse(Console.ReadLine());
            while (Num < 0)
            {
                Console.WriteLine("Invalid Pascal's triangle triangle number");
                int Num2 =  int.Parse(Console.ReadLine());
                Num = Num2;  
            }
            if(Num > 0)
            {

                for (n = 0; n <= Num; n++)
                {
                    for (r = 0; r <= n; r++)
                    {
                        if (n == 0 || r == 0)
                        {
                            wall = 1;
                            Console.Write(wall);
                        }
                        else { Console.Write(wall = wall * ((n - r) + 1) / r); }

                    }
                    Console.WriteLine("");
                }
            }
            else { Console.WriteLine(wall+1);}
            
             





            

           


            Console.ReadLine();
        }
    }
}

