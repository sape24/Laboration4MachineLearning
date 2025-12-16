using System;
using MyMLApp;

class Program
{
    static void Main()
    {
        while (true)   
        {
            Console.Clear();
            PrintHeader();
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;

            var sampleData = new SentimentModel.ModelInput()
            {
                Col0 = input
            };

            var result = SentimentModel.Predict(sampleData);

            float negativeScore = result.Score[1];
            float positiveScore = result.Score[0];

            string sentiment = result.PredictedLabel == 1
                ? " Positivt omdöme"
                : " Negativt omdöme";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(">>> Beräknar känslan av omdömet");
            Console.WriteLine();
            Console.WriteLine("Resultat");
            Console.WriteLine("---------------");
            Console.WriteLine($"Text: {sampleData.Col0}");
            Console.WriteLine($"Bedömning: {sentiment}");
            Console.WriteLine($"Känsla                              Score");
            Console.WriteLine($"------                              --------");
            Console.WriteLine($"Positiv                             {positiveScore:0.000}");
            Console.WriteLine($"Negativ                             {negativeScore:0.000}");
            Console.WriteLine("---------------");
            Console.WriteLine();
            Console.WriteLine("Tryck valfri tangent för att fortsätta...");
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.ReadKey();
        }
    }

    static void PrintHeader()
    {
        Console.WriteLine("====================================================");
        Console.WriteLine("                 Sentimentanalys ML                 ");
        Console.WriteLine("====================================================");
        Console.WriteLine("Skriv ett omdöme på engelska eller lämna tomt för att avsluta");
        Console.Write("Omdöme: ");
    }
}