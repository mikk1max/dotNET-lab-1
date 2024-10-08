// Console.WriteLine("ZAD-1");
// for (int i = 1; i < 100; i++)
// {
//     if (i % 3 == 0 && i % 5 == 0)
//     {
//         Console.WriteLine("FizzBuzz");
//     }
//     else if (i % 3 == 0)
//     {
//         Console.WriteLine("Fizz");
//     }
//     else if (i % 5 == 0)
//     {
//         Console.WriteLine("Buzz");
//     }
//     else
//     {
//         Console.Write(i + "\n");
//     }
// }

using Lab_1;
using System.Text.Json;
Console.WriteLine("ZAD-2");

var rand = new Random();
bool result = false;
int quantityOfTries = 0;

string[] inputLines = File.ReadAllLines("input.txt"); // optional: for gitHub workflow test

while (!result)
{
    var value = rand.Next(1, 100);
    Console.WriteLine("Guess a number between 1 and 100:");
    // int guess = Convert.ToInt32(Console.ReadLine()); // uncomment for testing locally
    int guess = Convert.ToInt32(inputLines[0]); // optional: for gitHub workflow test

    if (!(guess >= 1 && guess <= 100))
    {
        Console.WriteLine("Please write a number between 1 and 100!");
    }
    else
    {
        if (value > guess)
        {
            Console.WriteLine("Your number " + guess + " is lower than randomNumber " + value);
            quantityOfTries++;
        }
        else if (value == guess)
        {
            Console.WriteLine("Gratulations! Your number " + guess + " is equal to randomNumber " + value);
            quantityOfTries++;
            result = true;
            Console.WriteLine("You tried " + quantityOfTries);
            Console.WriteLine("Write your name: ");

            // string userName = Console.ReadLine(); // uncomment for testing locally
            string userName = inputLines[1]; // optional: for gitHub workflow test

            var hs = new HighScore { Name = "Unknown", Trials = quantityOfTries };

            if (!string.IsNullOrWhiteSpace(userName))
            {
                hs = new HighScore { Name = userName, Trials = quantityOfTries };
            }
            else
            {
                userName = "Unknown";
            }

            List<HighScore> highScores;
            const string FileName = "highscores.json";

            if (File.Exists(FileName))
                highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
            else
                highScores = new List<HighScore>();

            highScores.Add(hs);

            // Sort the high scores by number of trials
            highScores = highScores.OrderBy(item => item.Trials).ToList();

            // Write the sorted high scores back to the file
            File.WriteAllText(FileName, JsonSerializer.Serialize(highScores));

            Console.WriteLine("-------------\nBest results:\n-------------");
            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name} -- {item.Trials} trials");
            }
        }
        else
        {
            Console.WriteLine("Your number " + guess + " is bigger than randomNumber " + value);
            quantityOfTries++;
        }
    }
}






