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
            // SentimentAnalysis();
            // KeyPhrasesExtraction();
            LanguageExtraction();
        }

        private static void SentimentAnalysis()
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westcentralus;
            client.SubscriptionKey = "9c0bc0190edf451fa24029d7c2419210";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            Console.WriteLine("Análisis de opiniones");

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

        private static void KeyPhrasesExtraction()
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westcentralus;
            client.SubscriptionKey = "9c0bc0190edf451fa24029d7c2419210";

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            KeyPhraseBatchResult result = client.KeyPhrases(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                          //new MultiLanguageInput("ja", "1", "猫は幸せ"),
                          //new MultiLanguageInput("de", "2", "Fahrt nach Stuttgart und dann zum Hotel zu Fu."),
                          //new MultiLanguageInput("en", "3", "My cat is stiff as a rock."),
                          new MultiLanguageInput("es", "4", "A mi me encanta el fútbol!")
                        }));


            // Printing keyphrases
            foreach (var document in result.Documents)
            {
                Console.WriteLine("Document ID: {0} ", document.Id);

                Console.WriteLine("\t Key phrases:");

                foreach (string keyphrase in document.KeyPhrases)
                {
                    Console.WriteLine("\t\t" + keyphrase);
                }
            }

            Console.ReadLine();
        }

        private static void LanguageExtraction()
        {
            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westcentralus;
            client.SubscriptionKey = "9c0bc0190edf451fa24029d7c2419210";

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            LanguageBatchResult result = client.DetectLanguage(
                    new BatchInput(
                        new List<Input>()
                        {
                          //new Input("1", "This is a document written in English."),
                          //new Input("2", "Este es un document escrito en Español."),
                          //new Input("3", "这是一个用中文写的文件")
                          new Input("2", "Este es un document escrito en Español."),
                        }));

            // Printing language results.
            foreach (var document in result.Documents)
            {
                Console.WriteLine("Document ID: {0} , Language: {1}", document.Id, document.DetectedLanguages[0].Iso6391Name);
            }

            Console.ReadLine();
        }
    }
}
