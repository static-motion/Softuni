using System;

namespace exerciseCycles
{
    class Program
    {
        static void Main()
        {
            int inputA = char.Parse(Console.ReadLine());
            int inputB = char.Parse(Console.ReadLine());
            int inputC = char.Parse(Console.ReadLine());
            int inputD = char.Parse(Console.ReadLine());
            int inputNum = int.Parse(Console.ReadLine());

            int combinationsCount = 0;

            for (char firtLetter = 'A'; firtLetter <= inputA; firtLetter++)
            {
                for (int secondLetter = 'a'; secondLetter <= inputB; secondLetter++)
                {
                    for (int thirdLetter = 'a' ;thirdLetter <= inputC; thirdLetter++)
                    {
                        for (int fourthLetter = 'a' ; fourthLetter <= inputD; fourthLetter++)
                        {
                            for (int number = 0; number <= inputNum; number++)
                            {
                                if (firtLetter == inputA
                                    && secondLetter == inputB
                                    && thirdLetter == inputC
                                    && fourthLetter == inputD
                                    && number == inputNum)
                                {
                                    Console.WriteLine(combinationsCount);
                                    return;
                                }
                                combinationsCount++;
                            }
                        }
                    }
                }
            }
        }
    }
}