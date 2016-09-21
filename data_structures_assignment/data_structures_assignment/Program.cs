/*
 * Author: Jacob Peterson
 * Description: give 100 customers burgers and print out results
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_assignment
{
    class Program
    {
        public static Random random = new Random();

        public static string randomName()//return a random name
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()//get a random number
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
        static void Main(string[] args)
        {
            Queue<String> myQueue = new Queue<string>();
            Dictionary<String,int> myDitionary = new Dictionary<String,int>();

            //load up queue with 100 customers
            for(int i = 0; i < 100; i++)
            {
                myQueue.Enqueue(randomName());
            }

            //assign burger numbers for each customer in queue
            foreach(string item in myQueue)
            {
                if(!myDitionary.ContainsKey(item))//add to dict if new
                {
                    myDitionary.Add(item, randomNumberInRange());
                }
                else//add to total if already in dict
                {
                    myDitionary[item] += randomNumberInRange();
                }
            }

            //print the results for each customer in dict
            foreach(KeyValuePair<String,int> entry in myDitionary)
            {
                Console.WriteLine(entry.Key + "\t\t" + entry.Value);
            }
            //keep console open until key is read so we can see output
            Console.Read();


        }
    }
}
