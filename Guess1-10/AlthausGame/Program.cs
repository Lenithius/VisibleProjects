Random random = new Random();
int correctNumber = random.Next(1, 11);
int attempts = 3;

Console.Write("Guess the number (1-10): ");

for (int i = 1; i <= attempts; i++)
{
    Console.Write($"Attempt {i}: ");
    int guess;

    if (guess == correctNumber)
    {
        Console.WriteLine("You guessed correctly!");
      
    }
    if(!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 10)
    {
        Console.WriteLine("Please enter a valid number between 1 and 10.");
        i--;
        continue;
    }


    else if (guess > correctNumber)
    {
        Console.WriteLine("Too high");
    }
    else
    {
        Console.WriteLine("Too low");
    }
}
Console.WriteLine($"Out of attempts! The correct number was {correctNumber}.");