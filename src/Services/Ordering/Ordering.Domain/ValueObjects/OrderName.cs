namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int DefaultMaxLength = 5;

    private OrderName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static OrderName Of(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultMaxLength);

        return new OrderName(value);
    }
}