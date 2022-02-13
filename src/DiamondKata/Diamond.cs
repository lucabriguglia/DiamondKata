namespace DiamondKata
{
    public class Diamond : IDiamond
    {
        public string Create(string input)
        {
            if (!InputIsValid(input))
            {
                return Messages.InputNotValid;
            }

            var targetLetter = input[0];
            var length = targetLetter - 'A';

            var topHalfDiamond = new List<string>();

            for (var i = 0; i < length + 1; i++)
            {
                var letter = (char)('A' + i);

                var leftHalfLine = $"{new string(' ', length - i)}{letter}{new string(' ', i)}";
                var rightHalfLine = Reflect(leftHalfLine);
                var fullLine = leftHalfLine.Concat(rightHalfLine);

                topHalfDiamond.Add(string.Concat(fullLine));
            }

            var bottomHalfDiamond = Reflect(topHalfDiamond);
            var fullDiamond = topHalfDiamond.Concat(bottomHalfDiamond);

            return string.Join("\n", fullDiamond);
        }

        private static IEnumerable<T> Reflect<T>(IEnumerable<T> list)
        {
            return list.Reverse().Skip(1);
        }

        private static bool InputIsValid(string input)
        {
            return input.Length == 1 && char.IsUpper(input[0]);
        }
    }
}
