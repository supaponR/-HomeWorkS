using System;

namespace HWS._6
{
    class Program
    {

        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        enum Difficulty
        {
            Easy = 3,
            Normal = 5,
            Hard = 7
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }

        static int inputHomePage(int ModeNum )
        {
            while (ModeNum != 1 && ModeNum != 2 && ModeNum != 0)
            {
                Console.WriteLine("Please input 0-2.");
                ModeNum = int.Parse(Console.ReadLine());
            }
            return ModeNum;
        }
        static void Homepage()
        {
            
            Console.WriteLine("No.0 Play Game");
            Console.WriteLine("No.1 Setting");
            Console.WriteLine("No.2 Exit");
        }
        //ความยาก
        static void NumberDifficulty()
        {
            Console.WriteLine("Level 0 : Easy");
            Console.WriteLine("Level 1 : Normal");
            Console.WriteLine("Level 2 : Hard");
        }



        static void Main(string[] args)
        {
            double score = 0;
            int setDifficulty = 0;
            float Time;
            int Answer ,NumPage,NumPageNew;
            Problem[] ProblemRandom;
            int CountPoint = 0;

            bool  End = true;
            Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Easy);

            while (End == true)
            {
                
                Homepage();
                NumPage = int.Parse(Console.ReadLine());
                NumPageNew = inputHomePage(NumPage);
                if (NumPage == 0 || NumPageNew == 0)
                {
                    if (setDifficulty == 0)
                    {
                        Time = DateTimeOffset.Now.ToUnixTimeSeconds();
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Easy);
                        ProblemRandom = GenerateRandomProblems((int)Difficulty.Easy);
                        for (int E = 0; E < 3; E++)
                        {
                            
                            Console.WriteLine(ProblemRandom[E].Message);
                            Answer = int.Parse(Console.ReadLine());
                            int PointE = ProblemRandom[E].Answer; 
                            if(Answer == PointE)
                            {
                                CountPoint++;
                            }
   
                        }
                        score += (CountPoint / ProblemRandom.GetLength(0)) * (25 - (Math.Pow((int)Difficulty.Easy, 2)) / (Math.Max(Time, 25- (int)Difficulty.Easy) * Math.Pow((int)Difficulty.Easy*2, 2)));
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Easy);
                    }
                    else if (setDifficulty == 1)
                    {
                        Time = DateTimeOffset.Now.ToUnixTimeSeconds();
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Normal);
                        ProblemRandom = GenerateRandomProblems((int)Difficulty.Normal);
                        for (int N = 0; N < 5; N++)
                        {
                            Console.WriteLine(ProblemRandom[N].Message);
                            Answer = int.Parse(Console.ReadLine());
                            int PointN = ProblemRandom[N].Answer;
                            if (Answer == PointN)
                            {
                                CountPoint++;
                            }
                        }
                        score += (CountPoint / ProblemRandom.GetLength(0)) * (25 - (Math.Pow((int)Difficulty.Normal, 2)) / (Math.Max(Time, 25-(int)Difficulty.Normal) * Math.Pow((int)Difficulty.Normal*2, 2)));
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Normal);
                    }
                    else if (setDifficulty == 2)
                    {
                        Time = DateTimeOffset.Now.ToUnixTimeSeconds();
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Hard);
                        ProblemRandom = GenerateRandomProblems((int)Difficulty.Hard);
                        for (int H = 0; H < 7; H++)
                        {
                            Console.WriteLine(ProblemRandom[H].Message);
                            Answer = int.Parse(Console.ReadLine());
                            int PointH = ProblemRandom[H].Answer;
                            if (Answer == PointH)
                            {
                                CountPoint++;
                            }
                        }
                        score += (CountPoint / ProblemRandom.GetLength(0)) * (25 - (Math.Pow((int)Difficulty.Hard, 2)) / (Math.Max(Time, 25-(int)Difficulty.Hard) * Math.Pow((int)Difficulty.Hard*2, 2)));
                        Console.WriteLine("Score : {0} , Difficulty : {1}", score, Difficulty.Hard);
                    }
                    
                }
                else if (NumPage == 1 || NumPageNew == 1)
                {
                    NumberDifficulty();
                    
                    setDifficulty = int.Parse(Console.ReadLine());
                    
                    switch (setDifficulty)
                    {
                        case 0:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Easy);
                            setDifficulty = 0;
                            NumPage = 0;
                            break;
                        case 1:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Normal);
                            setDifficulty = 1;
                            NumPage = 1;
                            break;
                        case 2:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Hard);
                            setDifficulty = 2;
                            NumPage = 2;
                            break;
                            if (setDifficulty == 0)
                            {
                                Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Easy);
                            }
                            if (setDifficulty == 1)
                            {
                                Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Normal);
                            }
                            if (setDifficulty == 2)
                            {
                                Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Hard);
                            }
                    }
                }
                else if (NumPage == 2 || NumPageNew == 2 )
                {
                    switch (setDifficulty)
                    {
                        case 0:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Easy);
                            break;
                        case 1:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Normal);
                            break;
                        case 2:
                            Console.WriteLine("Score : {0} , Difficulty : {1} ", score, Difficulty.Hard);
                            break;
                    }
                    End = false;
                }
                
            }


            //Console.ReadLine();
        }
    }
}
