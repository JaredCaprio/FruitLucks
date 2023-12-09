namespace FruitLuck.Contracts.FruitLucks;

public record FruitLuckResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Fruits
);