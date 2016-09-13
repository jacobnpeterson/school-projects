/*
 * Author: Jacob Peterson
 * Description: this program runs a tournament for an inputted number of teams and displays the results.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_console_assignment
{
    class Program
    {
        abstract class Team//parent. only used for children 
        {
            public string name;
            public int wins;
            public int loss;
        }
        class SoccerTeam : Team //inherits from team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;
            public List<game> games;

            public SoccerTeam(String name, int points)//constructor
            {
                this.name = name;
                this.points = points;
            }
        }
        class game
        {
            public String sHomeTeam;
            public String sAwayTeam;
            public int iHomeScore;
            public int iAwayScore;
        }
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        
        static void Main(string[] args)
        {
            Boolean bContinue = true;
            String sTeamName = "";
            int iPoints = 0;
            int iNumTeams = 0;
            List<SoccerTeam> Teams = new List<SoccerTeam>();
            int iPositionCounter = 0;

            Console.Write("How many teams? ");
           
                //validate number of teams as positive integer
                while (bContinue)
                {
                    try
                    {
                        iNumTeams = Convert.ToInt32(Console.ReadLine());//exeption if not an int

                        //exception if less than 0
                        if (iNumTeams < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            bContinue = false;//won't continue until it makes it here with no errors
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Write("please enter a valid number of teams: ");
                    }
                }
                bContinue = true;//set back for future controls

            //loop through teams and load up info
            for (int i = 0; i < iNumTeams; i++)
            {
                Console.Write("\nEnter team " + (i + 1) + "'s name: ");
                sTeamName = UppercaseFirst(Console.ReadLine());

                Console.Write("Enter " + sTeamName + "'s points: ");

                    //validate number of points
                    while (bContinue)
                    {
                        try
                        {
                            iPoints = Convert.ToInt32(Console.ReadLine());//exeption if not an int

                            //exception if less than 0
                            if (iPoints < 0)
                            {
                                throw new Exception();
                            }
                            else
                            {
                                bContinue = false;//won't continue until it makes it here with no errors
                            }
                        }
                        catch (Exception e)
                        {
                            Console.Write("please enter a valid number of points: ");
                        }
                    }
                bContinue = true;//reset for future controls

                Teams.Add(new SoccerTeam(sTeamName,iPoints));//add this team to the list
            }

            //Sort teams by points
            Teams = Teams.OrderByDescending(team => team.points).ToList();
            
            //display results
            Console.Write("\nHere is the sorted list:\n\n");
            Console.Write(Convert.ToString("Position").PadRight(15, ' '));
            Console.Write(Convert.ToString("Name").PadRight(30, ' '));
            Console.WriteLine(Convert.ToString("Points").PadRight(25, ' '));
            Console.Write(Convert.ToString("--------").PadRight(15, ' '));
            Console.Write(Convert.ToString("----").PadRight(30, ' '));
            Console.WriteLine(Convert.ToString("------").PadRight(25, ' '));
            
            foreach (SoccerTeam team in Teams)
            {
                Console.Write(Convert.ToString(++iPositionCounter).PadRight(15, ' '));
                Console.Write(Convert.ToString(team.name).PadRight(30, ' '));
                Console.WriteLine(Convert.ToString(team.points).PadRight(25, ' '));
            }

            Console.Read();
        }
           
    }
}
