namespace FruitLuck.Contracts.FruitLucks;

public record CreateFruitLuckRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Fruits
);