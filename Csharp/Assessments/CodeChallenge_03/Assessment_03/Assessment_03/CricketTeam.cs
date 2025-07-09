using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_03
{
    class CricketTeam
    {
        public void PointsCalculation(int no_of_matches)
        {
            int count_of_matches = 0;
            int sum_of_scores = 0;
            int average;
            int[] scores = new int[no_of_matches];
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine($"Enter the {i + 1} match score");
                scores[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < no_of_matches; i++)
            {
                count_of_matches++;
                sum_of_scores += scores[i];
            }
            average = sum_of_scores / count_of_matches;
            Console.WriteLine("Count of Matches : {0} ", count_of_matches);
            Console.WriteLine("Average of scores : {0} ", average);
            Console.WriteLine("Sum of Scores : {0} ", sum_of_scores);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CricketTeam obj = new CricketTeam();
            Console.WriteLine("Enter the number of matches : ");
            int n = Convert.ToInt32(Console.ReadLine());
            obj.PointsCalculation(n);
            Console.Read();
        }
    }
}


