using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ass3_Q2_RecursionNumbersList
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            List<int> newList = new List<int> { 3, 7, 9, 8, -3 };

            sw.Start();
            Console.WriteLine(CanMakeSum2(newList, 100));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            
            //always included code to make sure you can see the output before the console closes
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        //This way loops through every possible combination
        //Although it works it is inefficient
        private static bool CanMakeSum(List<int> curList, int targetSum)
        {
            foreach (int value in curList)
            {
                Debug.WriteLine("index " + curList.IndexOf(value) + " check " + value + " == " + targetSum);
                if (value == targetSum) {
                    return true;
                }
                else
                {
                    List<int> newList = new List<int>(curList);
                    newList.Remove(value);
                    if (CanMakeSum(newList, targetSum - value) == true){
                        return true;
                    }
                }

            }

            return false;

        }

        //This way removes the item from the original list after it has been used in
        //Every way, so that item then never gets checked again, making it more efficient
        //
        //NB. You have to itterate backwards through the list, as you can't remove an item
        //during itteration if moving forwards - this is a C# quirk!
        private static bool CanMakeSum2(List<int> curList, int targetSum)
        {
            foreach (int value in curList.Reverse<int>())
            {
                Debug.WriteLine("index " + curList.IndexOf(value) + " check " + value + " == " + targetSum);
                if (value == targetSum)
                {
                    return true;
                }
                else
                {
                    List<int> newList = new List<int>(curList);
                    newList.Remove(value);
                    if (CanMakeSum(newList, targetSum - value) == true)
                    {
                        return true;
                    }
                }
                curList.Remove(value);
            }

            return false;

        }

        private static bool CanMakeSum3(List<int> curList, int targetSum)
        {
            foreach (int value in curList.Reverse<int>())
            {
                Debug.WriteLine("index " + curList.IndexOf(value) + " check " + value + " == " + targetSum);
                if (value == targetSum)
                {
                    return true;
                }
                else
                {
                    List<int> newList = new List<int>(curList);
                    newList.Remove(value);
                    //in method, where the value is in the subset
                    if (CanMakeSum(newList, targetSum - value) == true)
                    {
                        return true;
                    }
                    //out method where you exclude from subset
                    if (CanMakeSum(newList, targetSum) == true)
                    {
                        return true;
                    }
                }
                curList.Remove(value);
            }

            return false;

        }

    }
    
}
