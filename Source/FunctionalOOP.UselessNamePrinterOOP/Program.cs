using System;
using System.Diagnostics;
using FunctionalOOP.ExampleDBFunctions;

namespace FunctionalOOP.UselessNamePrinterOOP
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                var rawInput = ReadInput();

                if (!TryParseInput(rawInput, out int parseResult)) continue;

                var personId = Math.Abs(parseResult);
                var message = GetMessage(personId);
                Console.WriteLine(message);

            } while (ReadContinue());
        }

        private static string ReadInput()
        {
            Console.Write("Enter Active Person Id: ");
            return Console.ReadLine();
        }

        private static bool TryParseInput(string input, out int value)
        {
            try
            {
                value = int.Parse(input);
                return true;
            }
            catch (Exception e)
            {
                LogException(new Exception("Invalid Input.", e));
                value = -1;
                return false;
            }
        }

        private static string GetMessage(int personId)
        {
            var person = SafeGetPerson(personId);

            return person != null && person.IsActive
                ? $"Person Id {person.Id}: {person.FirstName} {person.LastName}"
                : "Person Not Found.";
        }

        private static Person SafeGetPerson(int personId)
        {
            try
            {
                return DBStuff.GetPersonById(personId);
            }
            catch (Exception e)
            {
                LogException(e);
                return null;
            }
        }

        private static bool ReadContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press <Esc> to exit, any other key to continue...");
            Console.WriteLine();
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }

        private static void LogException(Exception e)
        {
            Console.WriteLine(e.Message);
            Debug.WriteLine(e);
        }
    }
}