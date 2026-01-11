using System;
using MyMLApp;

class Program
{
    static void Main()
    {
        while (true)   //loop som körs kontinuerligt så att användaren kan testa flera meningar
        {
            Console.Clear();
            PrintHeader();
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))                   //avsluta programmet om användaren lämnar tomt och trycker enter
                break;

            var sampleData = new SentimentModel.ModelInput()                //skapa ett input objekt som matchar formatet modellen tränades på
            {
                Col0 = input
            };

            var result = SentimentModel.Predict(sampleData);                 //skickar datan till ML modellen och får tillbaka ett resultat

            float negativeScore = result.Score[1];                             //hämtar scoren för de olika utfallen
            float positiveScore = result.Score[0];

            string sentiment = result.PredictedLabel == 1                  
                ? " Positivt omdöme"
                : " Negativt omdöme";
            Console.WriteLine();                                              //presentation av resultatet 
            Console.WriteLine();
            Console.WriteLine(">>> Beräknar känslan av omdömet");
            Console.WriteLine();
            Console.WriteLine("Resultat");
            Console.WriteLine("---------------");
            Console.WriteLine($"Text: {sampleData.Col0}");                           //skriver ut den exakta sannolikheten
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

    static void PrintHeader()                                                   //hjälpmetod för att skriva ut en snygg header
    {
        Console.WriteLine("====================================================");
        Console.WriteLine("                 Sentimentanalys ML                 ");
        Console.WriteLine("====================================================");
        Console.WriteLine("Skriv ett omdöme på engelska eller lämna tomt för att avsluta");
        Console.Write("Omdöme: ");
    }
}