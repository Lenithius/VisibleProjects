using System;
using System.Dynamic;




    class Program()
    {
        static void Main()
        {
            //Initializing game breaks and rolls
            bool isProgramFinished = false;
            bool isGameFinished = false;
            bool houseBust = false;
            bool playerBust = false;
            Random newCard = new Random();
            
            //Game Start
            while (!isProgramFinished)
            {
                Console.Clear();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("#----***---# Welcome to the 21 game! #----***---# ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Do you dare play the house? \"Y\"/\"N\" ??? ");
                string playGame = Console.ReadLine().ToLower();
                // Init Variables of house and player game start 2 "cards" each
                if (playGame == "y")
                {
                    int playerScore = 0;
                    int houseScore = 0;

                    int playerInitialDraw1 = newCard.Next(1, 11);
                    int playerInitialDraw2 = newCard.Next(1, 11);
                    int houseInitialDraw1 = newCard.Next(1, 11);
                    int houseInitialDraw2 = newCard.Next(1, 11);

                    isGameFinished = false;

                    int newCards = (playerInitialDraw1 + playerInitialDraw2);
                    int houseCards = (houseInitialDraw1 + houseInitialDraw2);

                    playerScore = newCards;
                    houseScore = houseCards;
                    while (!isGameFinished)
                    { // over 21 bust checks
                        Console.WriteLine($"Your current total is: {playerScore}");
                        if (playerScore > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your total is greater than 21, you've lost! Better luck next time ");
                            Console.ForegroundColor = ConsoleColor.White;
                            playerBust = true;
                            isGameFinished= true;
                            
                        }
                        else
                        { // Draw a new card
                            Console.WriteLine("Would you like to Hit or Stay? ");
                            Console.WriteLine("Would you like another card? \"Y\"/\"N\" ");
                            String hit = Console.ReadLine().ToLower();
                            if (hit == "y")
                            {
                                playerScore += newCard.Next(1, 11);
                            }
                            else if (hit == "n")
                            {   // house draws up to 16 stays on 17
                                while (houseScore < 17)
                                {

                                    houseScore += newCard.Next(1, 11);
                                    if (houseScore > 21)
                                    {
                                        Console.WriteLine("The house is bust.");
                                        houseBust = true;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        isGameFinished = true;
                                    }
                                }
                                //house bust break and score comparison win/lose
                                if (playerScore > houseScore || houseBust)
                                {
                                    Console.WriteLine($"House got {houseScore} player got {playerScore}");
                                }
                                else
                                {
                                    Console.WriteLine($"You Lost, house got {houseScore}");
                                }

                                isGameFinished = true;
                            }
                            else
                            {
                                Console.WriteLine($"Please enter \"Y\"/\"N\"");
                            }
                        }
                    }

                    if (playerScore > houseScore && !playerBust || houseBust)
                    {

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Player Wins");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                    }
                    else if (house)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("House Wins!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }// if player doesn't play
                else if (playGame == "n")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Too bad, See you next time, Coward!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                isProgramFinished = true;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'");
                }
            }
        }
    }

