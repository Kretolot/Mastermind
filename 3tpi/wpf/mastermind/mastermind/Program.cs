using System.Collections.Generic;

string[] dot_colors = ["red", "blue", "green", "yellow", "orange", "violet", "gray", "white"];

string[] gen_rand_unique_colors(string[] colors)
{
    Random rand = new Random();
    return dot_colors.OrderBy(_ => rand.Next()).Take(4).ToArray();
}

string[] gen_rand_repeteated_colors(string[] colors)
{
    Random rand = new Random();
    return Enumerable.Range(0, 4).Select(_ => dot_colors[rand.Next(dot_colors.Length)]).ToArray();
}

List< int> verify_colors(string[] colors, string[] guess)
{
    List<int> result = [];
    bool[] used = new bool[colors.Length];

    for (int i = 0; i < guess.Length; i++)
    {
        used[i] = false;

        for (int j = 0; j < colors.Length; j++)
        {
            if (colors[j] == guess[i])
            {
                if (!used[i])
                {
                    result.Add(i == j ? 2 : 1); // correct : present
                    used[i] = true;
                }

            }
        }
    }

    return result;
}

for (int i = 1; i < 21; i++)
{
    Console.WriteLine($"Próba nr {i}:");

    string[] generated = gen_rand_repeteated_colors(dot_colors);
    string[] guessed = gen_rand_repeteated_colors(dot_colors);

    string[] info = ["Absent", "Present", "Correct"];

    foreach (var item in generated)
    {
        Console.Write(item + " ");
    };
    Console.WriteLine();

    foreach (var item in guessed)
    {
        Console.Write(item + " ");
    };
    Console.WriteLine();

    foreach (int item in verify_colors(generated, guessed))
    {
        Console.Write(info[item] + " ");
    };
    Console.WriteLine();
}