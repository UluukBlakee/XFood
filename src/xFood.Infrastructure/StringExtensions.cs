namespace xFood.Infrastructure;

public static class StringExtensions
{
    public static bool IsNotEmpty(this string value) => !string.IsNullOrEmpty(value);
    public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
}