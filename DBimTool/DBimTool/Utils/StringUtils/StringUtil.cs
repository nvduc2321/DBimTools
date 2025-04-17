using System.Text.RegularExpressions;

namespace DBimTool.Utils.StringUtils
{
    public static class StringUtil
    {
        public static int GetInterger(this string textValue, string baseValue)
        {
            try
            {
                var num = 0;
                string pattern = $"{Regex.Escape(baseValue)} \\((\\d+)\\)";
                var regex = new Regex(pattern);
                var match = regex.Match(textValue);
                if (match.Success && match.Groups.Count > 1)
                    if (int.TryParse(match.Groups[1].Value, out int number))
                        num = number;
                return num;
            }
            catch (Exception)
            {
            }
            return 0;
        }
    }
}
