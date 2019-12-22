using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.Parser
{
    /// <summary>
    /// Parser for translit that uses a dictionary for parsing values
    /// </summary>
    public static class TranslitParser
    {
        /// <summary>
        /// Dictionary with big letters
        /// </summary>
        static Dictionary<char, string> keyValuePairsBig = new Dictionary<char, string>()
        {
            ['А'] = "A",
            ['Б'] = "B",
            ['В'] = "V",
            ['Г'] = "G",
            ['Д'] = "D",
            ['Е'] = "E",
            ['Ё'] = "YO",
            ['Ж'] = "ZH",
            ['З'] = "Z",
            ['И'] = "I",
            ['Й'] = "J",
            ['К'] = "K",
            ['Л'] = "L",
            ['М'] = "M",
            ['Н'] = "N",
            ['О'] = "O",
            ['П'] = "P",
            ['Р'] = "R",
            ['С'] = "S",
            ['Т'] = "T",
            ['У'] = "U",
            ['Ф'] = "F",
            ['Х'] = "H",
            ['Ц'] = "TS",
            ['Ч'] = "CH",
            ['Ш'] = "SH",
            ['Щ'] = "SHCH",
            ['Ъ'] = "",
            ['Ы'] = "Y",
            ['Ь'] = "b",
            ['Э'] = "EH",
            ['Ю'] = "YU",
            ['Я'] = "YA",
        };

        /// <summary>
        /// Dictionary with little letters
        /// </summary>
        static Dictionary<char, string> keyValuePairsLittle = keyValuePairsBig
            .ToDictionary(key => key.Key.ToString().ToLower().First(), value => value.Value.ToLower());

        /// <summary>
        /// Check for big russian letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        static bool IsBigRussianLetter(char letter)
            => (letter >= 'А' && letter <= 'Я');

        /// <summary>
        /// Check for little russian letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        static bool IsLittleRussianLetter(char letter)
            => (letter >= 'а' && letter <= 'я');

        /// <summary>
        /// ToTranslit Method
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string ToTranslit(string pattern)
        {
            if (String.IsNullOrEmpty(pattern))
                throw new FormatException("Invalid Format");

            StringBuilder forAppend = new StringBuilder();

            pattern.Select(symb => (IsBigRussianLetter(symb) ?
                keyValuePairsBig[symb] : (IsLittleRussianLetter(symb) ? keyValuePairsLittle[symb] : symb.ToString())))
                .ToList().ForEach(symb => forAppend.Append(symb));

            return forAppend.ToString();
        }

    }
}
