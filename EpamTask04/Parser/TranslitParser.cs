using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask04.Parser
{
    public static class TranslitParser
    {
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

        static Dictionary<char, string> keyValuePairsLittle = keyValuePairsBig
            .ToDictionary(key => key.Key.ToString().ToLower().First(), value => value.Value.ToLower());

        static bool IsBigRussianLetter(char letter)
            => (letter >= 'А' && letter <= 'Я');

        static bool IsLittleRussianLetter(char letter)
            => (letter >= 'а' && letter <= 'я');

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
