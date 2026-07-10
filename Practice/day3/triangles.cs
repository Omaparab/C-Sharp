
using System;

class TrianglePatterns
{
    public void triangles()
    {

        Console.WriteLine("Left Triangle:");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }


        Console.WriteLine("Left Inverted Triangle:");
        for (int i = 5; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Right Triangle:");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                if (j <= 5 - i)
                    Console.Write(" ");
                else
                    Console.Write("*");
            }

            Console.WriteLine();
        }

    }

    
}

