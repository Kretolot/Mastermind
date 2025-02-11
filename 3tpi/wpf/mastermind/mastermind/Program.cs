using System;

class Program
{
    static void Main(string[] args)
    {
        string[] kolory = { "czerwony", "niebieski", "zielony", "żółty", "pomarańczowy", "fioletowy", "szary", "czarny" };

        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            string[] wylosowaneBez = kolory.OrderBy(_ => random.Next()).Take(4).ToArray();
            Console.WriteLine($" Losowanie {i}: " + string.Join(", ", wylosowaneBez));
        }

        for (int i = 0; i < 20; i++)
        {
            string[] wylosowaneZ = Enumerable.Range(0, 4).Select(_ => kolory[random.Next(kolory.Length))] ;
        }
    }
}