using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        public static void Main(string[] args)
        {
            int bankDifficulty = Greeting();

            Team team = BuildTeam();

            Console.Write("How many trial runs would you like to perform?");
            Console.WriteLine();
            int parsedAnswer = 0;
            bool success = int.TryParse(Console.ReadLine(), out parsedAnswer);


            if(success)
            {
                PerformTrialRuns(team, parsedAnswer, bankDifficulty);
            }
            else{
                while(!success)
                {
                    Console.Write("How many trial runs would you like to perform? Try using a number this time, guy.");
                    success = int.TryParse(Console.ReadLine(), out parsedAnswer);
                }
            }
            
        }

        public static int Greeting()
        {
            Console.WriteLine("Plan your heist!");
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.Write("How difficult is this bank? Enter an integer: ");
            string answer = Console.ReadLine();
            Console.WriteLine();

            int parsedAnswer = 0;

            bool success = int.TryParse(answer, out parsedAnswer);

            if(success)
            {
                return parsedAnswer;
            }
            else
            {
                while(!success)
                {
                    Console.Write("How difficult is this bank? Enter an integer: ");
                    answer = Console.ReadLine();
                    success = int.TryParse(answer, out parsedAnswer);
                }
            }
            return parsedAnswer;



        }

        public static Member GatherData()
        {
            
            Console.Write("Enter team member's name: ");
            string name = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(name))
            {

            Console.Write("Enter team member's skill level: ");
            string skillLevel = Console.ReadLine();
            int parsedSkill = int.Parse(skillLevel);

            Console.Write("Enter team member's courage level (0.0 - 2.0): ");
            string courage = Console.ReadLine();
            double parsedCourage = double.Parse(courage);

            while(true)
            {
                if(parsedCourage < 0 || parsedCourage > 2)
                {
                    Console.Write("Enter team member's courage level (0.0 - 2.0): ");
                    courage = Console.ReadLine();
                    parsedCourage = double.Parse(courage);
                }
                else
                {
                    break;
                }
            }

            Member member = new Member(name, parsedSkill, parsedCourage);

            return member;
            }
            else
            {
                return null;
            }

        }

        public static void PerformTrialRuns(Team team, int tries, int difficulty)
        {
            
            
            int index = 0;
            int success = 0;

            while(index < tries)
            {
                Bank bank = new Bank(difficulty + GetLuckValue());
                


                if(bank.DifficultyLevel > team.TeamSkill)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"Bank difficulty level: {bank.DifficultyLevel}");
                    Console.WriteLine($"Team skill level: {team.TeamSkill}");
                    Console.WriteLine();
                    Console.WriteLine("You got arrested. Good job, dumbass.");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------");
                }
                else
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"Bank difficulty level: {bank.DifficultyLevel}");
                    Console.WriteLine($"Team skill level: {team.TeamSkill}");
                    Console.WriteLine();
                    Console.WriteLine("You robbed a bank. What a terrible fucking person you are.");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------------");
                    success++;

                }
                index++;
            }
            Console.WriteLine();
            Console.WriteLine($"You were successful {success} times.");

        }
        public static Team BuildTeam()
        {
            List<Member> teamList = new List<Member>();
            
            while(true)
            {
                Member member = GatherData();
                if(member != null)
                {

                    teamList.Add(member);
                }
                else
                {
                    break;
                }
            }
            Team team = new Team(teamList);
            return team;
        }

        public static int GetLuckValue()
        {
            Random random = new Random();
            int luckValue = random.Next(-10, 10);

            return luckValue;

        }

    }

}