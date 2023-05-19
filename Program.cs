internal class Program
{
    private static void Main(string[] args)
    {
        string? player;
        Random random = new Random();
        int attemps = 0; 
        int highestScoreAttemps = 0;

        Console.WriteLine("\tGuess The Number");

        StartGame();

        void StartGame()
        {

            Console.WriteLine("Hello!! Welcome to the game...");

            Console.WriteLine("What is your name?: ");
            player = Console.ReadLine();

            var randomNumber = random.Next(1, 10);

            WantToPlay(randomNumber);
           
        }

        void WantToPlay(int randomNumber, bool playAgain = false)
        {
            if (!playAgain)
                Console.WriteLine($"Hi {player}, are you ready to play? (Enter Y/N): ");
            else
                Console.WriteLine($"{player}, are you ready to play again? (Enter Y/N): ");


            var wantToPlay = Console.ReadLine();

            switch (wantToPlay?.ToLower().Trim())
            {
                case "y":
                    Play(randomNumber);
                    break;
                case "n":
                    DontPlay();
                    break;
                default:
                    Console.WriteLine("That is not a valid option.");
                    WantToPlay(randomNumber);
                    break;
            }
        }

        void Play(int randomNumber)
        {
            try
            {
                Console.WriteLine("Pick a number between 1 and 10: ");
                var pickedNumber = Console.ReadLine();

                if (pickedNumber is null || int.Parse(pickedNumber) < 1 || int.Parse(pickedNumber) > 10)
                    throw new Exception("Please pick a number between 1 and 10");
                if (int.Parse(pickedNumber) == randomNumber)
                {
                    YouGuessed();
                }
                else if (int.Parse(pickedNumber) < randomNumber)
                {
                    Console.WriteLine("Try again! The number is higher...");
                    attemps++;
                    Play(randomNumber);
                }
                else if (int.Parse(pickedNumber) > randomNumber)
                {
                    Console.WriteLine("Try again! The number is lower...");
                    attemps++;
                    Play(randomNumber);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There as been an error: {e.Message}");
                Play(randomNumber);
            }
        }

        void DontPlay()
        {
            Console.WriteLine("No worries! Have a good one!");
        }

        void YouGuessed()
        {
            Console.WriteLine("Nice you guessed the number!!");
            attemps++;

            if (highestScoreAttemps == 0 || attemps < highestScoreAttemps)
                highestScoreAttemps = attemps;
            

            Console.WriteLine($"It has taken you {attemps} attemps to guess the number");
            ShowScore();
            attemps = 0;
            
            var randomNumber = random.Next(1, 10);
            WantToPlay(randomNumber, true);
        }

        void ShowScore()
        {
            if (highestScoreAttemps == 0)
                Console.WriteLine("There is currently no high score, it´s your for the taking");
            else
                Console.WriteLine($"The current high score is {highestScoreAttemps}");
        }
    }
}