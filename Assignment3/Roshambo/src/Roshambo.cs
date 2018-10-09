﻿using System;

namespace Roshambo
{
    public class Roshambo
    {
        public static string newLine = Environment.NewLine;

        public static void Main(string[] args)
        {
            int playerHealth = 100, compHealth = 100;
            bool playAgain = true;

            Console.WriteLine("----Roshambo----");
            do
            {
                Console.WriteLine($"Player HP: {playerHealth}        Computer HP: {compHealth}");

                (string player, string computer) round = PlayRound();

                Console.WriteLine($"{newLine}You picked: {round.player}{newLine}Computer picked: {round.computer}");

                if (round.player == round.computer)
                {
                    Console.WriteLine("-------------------------------------------->Draw");
                }
                else
                {
                    playerHealth -= DetermineDamage(round.player, round.computer);
                    compHealth -= DetermineDamage(round.computer, round.player);
                }

                if (playerHealth < 1)
                {
                    Console.WriteLine($"{newLine}----YOU LOSE!!!----{newLine}Would you like to play again ('y' or 'n')?");
                    playAgain = PromptForContinue();
                    playerHealth = 100;
                    compHealth = 100;
                }

                if (compHealth < 1)
                {
                    Console.WriteLine($"{newLine}----YOU WIN!!!----{newLine}Would you like to play again ('y' or 'n')?");
                    playAgain = PromptForContinue();
                    playerHealth = 100;
                    compHealth = 100;
                }
            } while (playAgain);
        }

        public static (string player, string computer) PlayRound()
        {
            string player = PromptPlayer();
            string computer = RandomChoice();
            return (player, computer);
        }

        public static string PromptPlayer()
        {
            Console.WriteLine("Enter 'rock', 'paper', or 'scissors':");
            return Console.ReadLine().ToLower();
        }

        public static string RandomChoice()
        {
            Random rand = new Random();
            string ret = "rock";
            switch (rand.Next(1, 4))
            {
                case 1:
                    ret = "paper";
                    break;
                case 2:
                    ret = "scissors";
                    break;
            }
            return ret;
        }

        public static int DetermineDamage(string player, string opponent)
        {
            switch (player)
            {
                case "rock":
                    if (opponent == "paper")
                    {
                        Console.WriteLine("-------------------------------------------->Paper covers Rock");
                        return 10;
                    }
                    break;
                case "paper":
                    if (opponent == "scissors")
                    {
                        Console.WriteLine("-------------------------------------------->Scissors cuts Paper");
                        return 15;
                    }
                    break;
                case "scissors":
                    if (opponent == "rock")
                    {
                        Console.WriteLine("-------------------------------------------->Rock crushes Scissors");
                        return 20;
                    }
                    break;
            }
            return 0;
        }

        public static bool PromptForContinue()
        {
            switch (Console.ReadLine())
            {
                case "y":
                    return true;
            }
            return false;
        }
    }
}
