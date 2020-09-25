using System.Text.RegularExpressions;

namespace CustomerManagement.Infrastructure.CrossCuting.Extensions
{
    public static class StringExtensions
    {
		public static string RemoveSpecialCharacters(this string text, bool allowSpace = false)
		{
			string ret;

			if (allowSpace)
				ret = Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
			else
				ret = Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

			return ret;
		}
	}
}
