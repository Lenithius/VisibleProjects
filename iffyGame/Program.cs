

//Console.Clear();

System.Random dice = new Random();

int roll1 = dice.Next(1, 7);
int roll2 = dice.Next(1, 7);
int roll3 = dice.Next(1, 7);

int total = roll1 + roll2 + roll3;
Console.WriteLine("Get 15 or higher to win");
Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");


if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
{   
    if ((roll1 == roll2) && (roll2 == roll3)) 
    {   
    Console.WriteLine("You rolled triples! +6 bonus to total!");
    total += 6;
    Console.WriteLine($"New total = {total}");
    }


    else
    {
    Console.WriteLine("You rolled doubles! +2 bonus to total!");
    total += 2;
    Console.WriteLine($"New total = {total}");
    }
}

if (total >= 16)
{
    Console.WriteLine("You win a new phantom car!");
}
else if (total >= 10)
{
    Console.WriteLine("You win a new ethereal laptop!");
}
else if (total == 7)
{
    Console.WriteLine("You win a fantasy trip for two!");
}
else
{
    Console.WriteLine("You win a faux kitten!");
}