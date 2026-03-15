namespace UrlShortener.Api.Utils;

public static class Base62Converter
{
    private const string Base62Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string Encode(long id)
    {
        // Edge case for 0, as it would return an empty string otherwise
        if (id == 0) return Base62Chars[0].ToString();

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        while (id > 0)
        {
            sb.Append(Base62Chars[(int)(id % 62)]);
            id /= 62;
        }
        // Reverse the string to get the correct order
        char[] charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}
