using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LabyrinthDash
{
    static int currentRow = 0;
    static int currentCol = 0;
    static string lastMove = String.Empty;
    static int lives = 3;
    static int movesCount = 0;
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char[][] labyrinth = new char[size][];
        for (int i = 0; i < size; i++)
        {
            string input = Console.ReadLine();
            labyrinth[i] = new char[input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                labyrinth[i][j] = input[j];
            }
        }
        
        string commands = Console.ReadLine();
        
        foreach (var direction in commands)
        {
            switch (direction)
            {
                case '<':
                    {
                        lastMove = "left";
                        currentCol--;
                        ChangePosition(labyrinth);
                        break;
                    }
                case '>':
                    {
                        lastMove = "right";
                        currentCol++;
                        ChangePosition(labyrinth);
                        break;
                    }
                case '^':
                    {
                        lastMove = "up";
                        currentRow--;
                        ChangePosition(labyrinth);
                        break;
                    }
                case 'v':
                    {
                        lastMove = "down";
                        currentRow++;
                        ChangePosition(labyrinth);
                        break;
                    }
            }
        }
        Console.WriteLine("Total moves made: {0}", movesCount);
    }

    private static void ChangePosition(char[][] labyrinth)
    {
        try
        {
            if (labyrinth[currentRow][currentCol] == '|' || labyrinth[currentRow][currentCol] == '_')
            {
                switch (lastMove)
                {
                    case "right":
                        {
                            currentCol--;
                            break;
                        }
                    case "left":
                        {
                            currentCol++;
                            break;
                        }
                    case "up":
                        {
                            currentRow++;
                            break;
                        }
                    case "down":
                        {
                            currentRow--;
                            break;
                        }
                }
                Console.WriteLine("Bumped a wall.");
            }

            else if(labyrinth[currentRow][currentCol] == '@'
                || labyrinth[currentRow][currentCol] == '*'
                || labyrinth[currentRow][currentCol] == '#')
            {
                movesCount++;
                lives--;
                {
                    if (lives == 0)
                    {
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        Console.WriteLine("No lives left! Game Over!");
                        Console.WriteLine("Total moves made: {0}", movesCount);
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                    }
                    
                }
            }
            else if(labyrinth[currentRow][currentCol] == '$')
            {
                movesCount++;
                lives++;
                labyrinth[currentRow][currentCol] = '.';
                Console.WriteLine("Awesome! Lives left: {0}", lives);
            }
            else if(labyrinth[currentRow][currentCol] == '.')
            {
                movesCount++;
                Console.WriteLine("Made a move!");
            }
            else
            {
                movesCount++;
                Console.WriteLine("Fell off a cliff! Game Over!");
                Console.WriteLine("Total moves made: {0}", movesCount);
                Environment.Exit(0);
            }
        }
        catch(SystemException)
        {
            movesCount++;
            Console.WriteLine("Fell off a cliff! Game Over!");
            Console.WriteLine("Total moves made: {0}", movesCount);
            Environment.Exit(0);
        }       
    }
}

