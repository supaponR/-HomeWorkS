using System;

namespace HomeworkS4._2
{
    class Program
    {
        static bool IsValidSequence(string halfDNASequence)
        {
            foreach(char nucleotide in halfDNASequence)
            {
                if (!"ATCG".Contains(nucleotide))
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string  halfDNA;
            char RepYN, OtherYN2='Y' ;
            
            while (OtherYN2 == 'Y')
            {
                Console.Write("");
                halfDNA = Console.ReadLine();
                if (IsValidSequence(halfDNA) == true)
                {
                    Console.WriteLine("Current half DNA sequence: " + halfDNA);
                    Console.Write("Do you want to replicate it? (Y/N) : ");
                    RepYN = char.Parse(Console.ReadLine());
                    while (RepYN != 'Y' && RepYN != 'N')
                    {
                        Console.WriteLine("Please input Y or N.");
                        RepYN = char.Parse(Console.ReadLine());
                    }

                    if (RepYN == 'Y')
                    {
                        Console.WriteLine("Replicated half DNA sequence : "+ ReplicateSeqeunce(halfDNA));
                        Console.Write("Do you want to process another sequence?(Y/N) :");
                        OtherYN2 = char.Parse(Console.ReadLine());
                        while (OtherYN2 != 'Y' && OtherYN2 != 'N')
                        {
                            Console.WriteLine("Please input Y or N.");
                            Console.Write("Do you want to process another sequence?(Y/N):");
                            OtherYN2 = char.Parse(Console.ReadLine());
                        }
                        if(OtherYN2 != 'N')
                        {
                            Console.WriteLine();
                        }
                    }

                    else if (RepYN == 'N')
                    {
                        Console.Write("Do you want to process another sequence?(Y/N):");
                        OtherYN2 = char.Parse(Console.ReadLine());
                        while (OtherYN2 != 'Y' && OtherYN2 != 'N')
                        {
                            Console.Write("Do you want to process another sequence?(Y/N):");
                            OtherYN2 = char.Parse(Console.ReadLine());
                        }
                        if (OtherYN2 != 'N')
                        {
                            Console.WriteLine();
                        }
                    }
                }
                else if (IsValidSequence(halfDNA) == false)
                {
                    Console.WriteLine("That half DNA sequence is invalid.");
                    Console.Write("Do you want to process another sequence?(Y/N):");
                    OtherYN2 = char.Parse(Console.ReadLine());
                    if (OtherYN2 == 'N')
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        while (OtherYN2 != 'Y' && OtherYN2 != 'N')
                        {
                            Console.WriteLine("Please input Y or N.");
                            Console.WriteLine();
                        }
                        if (OtherYN2 == 'N')
                        {
                            Console.WriteLine();
                        }
                    }
                }
                else { Console.WriteLine(); }
            }
            Console.ReadLine();



            //Methode1
            static bool IsVAlidSequence(string halfDNASequence)
            {
                foreach (char nucleotide in halfDNASequence)
                {
                    if (!"ATCG".Contains(nucleotide))
                    {
                        return false;
                    }
                }
                return true;
            }
            //Methode2
            static string ReplicateSeqeunce(string halfDNASequence)
            {
                string result = "";
                foreach (char nucleotide in halfDNASequence)
                {
                    result += "TAGC"["ATCG".IndexOf(nucleotide)];
                }
                return result;
            }


        }

    }
}
