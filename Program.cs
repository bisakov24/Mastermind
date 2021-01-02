  
using System;
using System.Linq;

namespace Mastermind
{
    class Program
    {

       
        //const int iListSize = 4;
        static void Main(string[] args)
        {

        //int guesses = 1;
        const int maxGuesses = 10;
        // Placeholder for user's guess
        string playerGuess;
        //keeps track of the players turn
        int turn = 1;

        var validInput = false;
        var numberCheck = 0;

        // Instructs the player on the rules of the game
        Console.WriteLine("=====================================================================================================================================================================================");
        Console.WriteLine("Guess the randomly generated 4 digit number. Each digit is a number between 1 and 6. \nA minus (-) sign will be printed for every digit that is correct but in the wrong position, \n" + 
        "and a plus (+) sign will be printed for every digit that is both correct and in the correct position. \nNothing will be printed for incorrect digits.");
        Console.WriteLine("=====================================================================================================================================================================================");

        // Solution our player is trying to guess
        int[] solution = numberGenerator();

        // used the below commented out code to test the solution
        //Console.WriteLine("{0}{1}{2}{3}", solution[0], solution[1], solution[2], solution[3]);

        Console.WriteLine("Guess the {0} Digit code, You have {1} tries!\n", solution.Length, maxGuesses);

        // run the game as long as the turn does not exceed the max number of guesses
        while(turn <= maxGuesses){

        Console.WriteLine("This is your {0} attempt", turn);

        // ask user for their guess
        playerGuess = Console.ReadLine();

        //Checks to see if the player entered a number
        validInput = int.TryParse(playerGuess, out numberCheck);

        //Checks to see if the input is of valid length, value and make sure it is not empty
        if(!validInput){
            Console.WriteLine("Invalid Input! Please enter a 4 digit number");
            playerGuess = Console.ReadLine();
        } else if (playerGuess.Length != solution.Length){
            Console.WriteLine("Invalid Input! Please enter a 4 digit number");
            playerGuess = Console.ReadLine();
        } else if(playerGuess == "") {
            Console.WriteLine("Invalid Input! Please enter a 4 digit number");
            playerGuess = Console.ReadLine();
        }
        
        // number array for users guess
        int[] guess = playerGuess.Select(n => int.Parse(n.ToString())).ToArray();
        

        //Used this commented out code to test the guess Array
        //Console.WriteLine("{0}{1}{2}{3}", guessArray[0], guessArray[1], guessArray[2], guessArray[3]);
        
        //Check to see if the user has guessed the correct code and if the user has used all of their guesses
        if(solution.SequenceEqual(guess)){
            Console.WriteLine("Congradulations you have won the game! The number was {0}{1}{2}{3}", solution[0], solution[1], solution[2], solution[3]);
            break;
        } else if(turn == maxGuesses){
            Console.WriteLine("You have run out of guesses. Game Over :(");
            break;
        }

        //result array which will show the player + - on their guessed number
        string[] result = new string[guess.Length];

        for (int i = 0; i < guess.Length; i++){
            
            if(guess[i] == solution[i]){
                result[i] = "+";
            } else {
                result[i] = (solution.Contains(guess[i])) ? "-" : " ";
            }
        }
           Console.WriteLine("{0}{1}{2}{3}", result[0], result[1], result[2], result[3]);
           
           turn += 1;

        }


        }

        //method to generate a random 4 digit number array which is used for the solution array
        static int[] numberGenerator() {
        
        Random randy = new Random();
        int[] randomArray = new int[4];

        randomArray[0] = randy.Next(1, 7);
        randomArray[1] = randy.Next(1, 7);
        randomArray[2] = randy.Next(1, 7);
        randomArray[3] = randy.Next(1, 7);

        return randomArray;

        }
 

    }
}
