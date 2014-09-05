using System;
using System.Diagnostics;

namespace KMorcinek.MisesTools
{
    public class MutualLinker
    {
        private readonly string firstPattern = "<a id=\"_ednref{0}\" href=\"#_end{0}\">[{0}]</a>";
        private readonly string secondPattern = "<a id=\"_end{0}\" href=\"#_ednref{0}\">[{0}]</a>";

        public string ChangeOneOccurrence(int index, string text)
        {
            string[] parts = text.Split(new[] {"[" + index + "]"}, StringSplitOptions.None);

            return parts[0] + string.Format(firstPattern, index) + parts[1] + string.Format(secondPattern, index) + parts[2];
        }

        public bool IsIndex(string text, int index)
        {
            string[] parts = text.Split(new[] { "[" + index + "]" }, StringSplitOptions.None);

            return parts.Length == 3;
        }

        public string AddLinks(string text)
        {
            int index = 1;

            while (IsIndex(text, index))
            {
                text = ChangeOneOccurrence(index, text);
                index++;
            }

            return text;
        }
    }
}