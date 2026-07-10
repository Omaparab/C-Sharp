using System;

public class ConditionalDemo
{
    public void displayConditions()
    {
        int age = 22;
        char grade = 'A';
        bool isTrainee = true;

        if (age >= 18)
        {
            Console.WriteLine("Adult");
        }
        else
        {
            Console.WriteLine("Minor");
        }

        string traineeStatus = isTrainee ? "Trainee" : "Not a Trainee";
        Console.WriteLine(traineeStatus);

        switch (grade)
        {
            case 'A':
                Console.WriteLine("Excellent Grade");
                break;

            case 'B':
                Console.WriteLine("Good Grade");
                break;

            default:
                Console.WriteLine("Average Grade");
                break;
        }
    }
}
