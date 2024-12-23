/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static int screenWidth = 40;
    static int screenHeight = 20;
    static List<(int, int)> snake = new List<(int, int)>();
    static (int, int) food;
    static (int, int) direction = (0, 1); // Initially moving to the right
    static Random random = new Random();
    static bool gameOver = false;

    static void Main()
    {
        Console.CursorVisible = false;
        InitializeGame();
        DrawBorder();

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                ChangeDirection(key);
            }

            MoveSnake();
            CheckCollision();
            UpdateScreen();
            Thread.Sleep(100); // Snake speed
        }

        Console.SetCursorPosition(0, screenHeight + 2);
        Console.WriteLine("Game Over!");
    }

    static void InitializeGame()
    {
        snake.Add((screenHeight / 2, screenWidth / 2)); // Snake initial position
        GenerateFood();
    }

    static void GenerateFood()
    {
        food = (random.Next(1, screenHeight - 1), random.Next(1, screenWidth - 1));
        DrawCharacter(food, 'X'); // Draw food on the screen
    }

    static void ChangeDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow when direction != (1, 0):
                direction = (-1, 0);
                break;
            case ConsoleKey.DownArrow when direction != (-1, 0):
                direction = (1, 0);
                break;
            case ConsoleKey.LeftArrow when direction != (0, 1):
                direction = (0, -1);
                break;
            case ConsoleKey.RightArrow when direction != (0, -1):
                direction = (0, 1);
                break;
        }
    }

    static void MoveSnake()
    {
        var head = (snake[0].Item1 + direction.Item1, snake[0].Item2 + direction.Item2);
        snake.Insert(0, head);

        if (head == food)
        {
            GenerateFood();
        }
        else
        {
            var tail = snake[snake.Count - 1];
            DrawCharacter(tail, ' '); // Erase the last part of the snake
            snake.RemoveAt(snake.Count - 1);
        }
    }

    static void CheckCollision()
    {
        var head = snake[0];

        // Check wall collision
        if (head.Item1 <= 0 || head.Item1 >= screenHeight || head.Item2 <= 0 || head.Item2 >= screenWidth)
        {
            gameOver = true;
        }

        // Check self collision
        if (snake.Skip(1).Contains(head))
        {
            gameOver = true;
        }
    }

    static void DrawBorder()
    {
        for (int i = 0; i < screenHeight; i++)
        {
            for (int j = 0; j < screenWidth; j++)
            {
                if (i == 0 || i == screenHeight - 1 || j == 0 || j == screenWidth - 1)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write("#"); // Boundary
                }
            }
        }
    }

    static void UpdateScreen()
    {
        DrawCharacter(snake[0], 'O'); // Draw the snake head
    }

    static void DrawCharacter((int, int) position, char character)
    {
        Console.SetCursorPosition(position.Item2, position.Item1); // Set cursor to the correct position
        Console.Write(character);
    }
   


}
*/

using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //making array and
        //by default I am providing 0-9 where no use of zero
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //By default player 1 is set
        static int choice; //This holds the choice at which position user want to mark
        // The flag variable checks who has won if it's value is 1 then someone has won the match
        //if -1 then Match has Draw if 0 then match is still running
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();// whenever loop will be again start then screen will be clear
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//checking the chance of the player
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board();// calling the board Function
                choice = int.Parse(Console.ReadLine());//Taking users choice
                // checking that position where user want to run is marked (with X or O) or not
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //if chance is of player 2 then mark O else mark X
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //If there is any possition where user want to run
                //and that is already marked then show message and load board again
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// calling of check win
            }
            while (flag != 1 && flag != -1);
            // This loop will be run until all cell of the grid is not marked
            //with X and O or some player is not win
            Console.Clear();// clearing the console
            Board();// getting filled board again
            if (flag == 1)
            // if flag value is 1 then someone has win or
            //means who played marked last time which has win
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else// if flag value is -1 the match will be draw and no one is winner
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        // Board method which creats board
        private static void Board()
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Winning Condition For Second Row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Winning Condition For Third Row
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region vertical Winning Condtion
            //Winning Condition For First Column
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Winning Condition For Second Column
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Winning Condition For Third Column
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Checking For Draw
            // If all the cells or values filled with X or O then any player has won the match
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}