using System;
using System.Diagnostics;
using FunctionalOOP.ExampleDBFunctions;

namespace FunctionalOOP.UselessNamePrinterResult
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Result.SetLogger(LogException);
            do
            {
                ReadInput()
                    .Bind(ParseInput)
                    .Map(Math.Abs)
                    .Map(GetMessage)
                    .Iter(Console.WriteLine);
            } while (ReadContinue());
        }

        private static IResult<string> ReadInput()
        {
            Console.Write("Enter Active Person Id: ");
            return Result.Wrap(Console.ReadLine);
        }

        private static IResult<int> ParseInput(string input)
        {
            return Result.Wrap(() => int.Parse(input), e => new Exception("Invalid Input.", e));
        }

        private static string GetMessage(int personId)
        {
            return SafeGetPerson(personId)
                .Filter(p => p.IsActive)
                .Fold((_, person) => $"Person Id {person.Id}: {person.FirstName} {person.LastName}",
                    "Person Not Found");
        }

        private static IResult<Person> SafeGetPerson(int personId)
        {
            return Result.Wrap(() => DBStuff.GetPersonById(personId));
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