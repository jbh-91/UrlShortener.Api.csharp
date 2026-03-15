namespace UrlShortener.Api.Utils;

public static class Base62Converter
{
    private const string Base62Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string Encode(long id)
    {
        // Edge case for 0, otherwise it returns an empty string
        if (id == 0) return Base62Chars[0].ToString();

        // A long in Base62 is at most 11 characters.
        // Using stackalloc to avoid heap allocation for the buffer.
        Span<char> buffer = stackalloc char[11];

        // Populate the buffer backwards
        int index = 11;
        while (id > 0)
        {
            index--;
            buffer[index] = Base62Chars[(int)(id % 62)];
            id /= 62;
        }

        // Create the string from the actually used slice of the buffer
        return new string(buffer.Slice(index));
    }
}
