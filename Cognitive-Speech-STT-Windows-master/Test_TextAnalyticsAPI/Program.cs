using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;

namespace Test_TextAnalyticsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westcentralus;
            client.SubscriptionKey = "9c0bc0190edf451fa24029d7c2419210";

            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Extracting sentiment
            Console.WriteLine("\n\n===== SENTIMENT ANALYSIS ======");

            SentimentBatchResult result3 = client.Sentiment(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                          //new MultiLanguageInput("en", "0", "I had the best day of my life."),
                          //new MultiLanguageInput("en", "1", "This was a waste of my time. The speaker put me to sleep."),
                          //new MultiLanguageInput("es", "2", "No tengo dinero ni nada que dar..."),
                          //new MultiLanguageInput("it", "3", "L'hotel veneziano era meraviglioso. È un bellissimo pezzo di architettura."),
                          new MultiLanguageInput("es", "0", "bueno"),
                        }));


            // Printing sentiment results
            foreach (var document in result3.Documents)
            {
                Console.WriteLine("Document ID: {0} , Sentiment Score: {1:0.00}", document.Id, document.Score);
            }
            Console.ReadLine();
        }
    }
}
