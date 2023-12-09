namespace FruitLuck.Contracts.FruitLucks;

public record UpsertFruitLuckRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Fruits);