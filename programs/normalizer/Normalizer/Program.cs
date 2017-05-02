using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utn.IA.Grupo1.Normalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
                PrintErrorAndExit("Invalid number of arguments. Correct usage: normalize-dataset [input-dataset-path] [output-dataset-path]");
            }

            var inputFileName = args[0];
            var outputFileName = args[1];

            if (!File.Exists(inputFileName))
            {
                PrintErrorAndExit("Input dataset file is not found.");
            }

            var rawRecords = File.ReadAllLines(inputFileName);

            PrintInfo($"{rawRecords.Length} records found.");

            var dedupRecords = RemoveDuplicatePlays(rawRecords).ToList();

            PrintInfo($"{rawRecords.Length - dedupRecords.Count} duplicates removed.");

            var filteredRecords = ReduceNonDeterministicPlays(dedupRecords).ToList();

            PrintInfo($"{dedupRecords.Count - filteredRecords.Count} conflicting plays removed.");

            var header = "C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12,C13,C14,C15,C16,C17,C18,C19,C20,C21,C22,C23,C24,C25,C26,C27,C28,C29,C30,C31,C32,C33,C34,C35,C36,C37,C38,C39,C40,C41,C42,Columna_Jugada";

            File.WriteAllLines(outputFileName, new string[] { header }.Union(filteredRecords));

            PrintInfo($"{filteredRecords.Count} plays stored in {outputFileName}.");
        }

        private static IEnumerable<string> RemoveDuplicatePlays(IEnumerable<string> records)
        {
            return records.Distinct();
        }

        private static IEnumerable<string> ReduceNonDeterministicPlays(IEnumerable<string> records)
        {
            var groups = records
                .GroupBy(x => GetBoardState(x));

            return groups.SelectMany(x => x.Take(1));
        }

        private static string GetBoardState(string record)
        {
            var playIndex = record.LastIndexOf(',');
            return record.Substring(0, playIndex);
        }

        private static void PrintErrorAndExit(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Environment.Exit(-1);
        }

        private static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
