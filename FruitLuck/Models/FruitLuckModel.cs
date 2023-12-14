using ErrorOr;
using FruitLuck.Contracts.FruitLucks;
using FruitLuck.ServiceErrors;

namespace FruitLuck.Models;

public class FruitLuckModel

{

    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 50;
    public const int MaxDescriptionLength = 150;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Fruits { get; }


    private FruitLuckModel(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> fruits
    )
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Fruits = fruits;
    }


    public static ErrorOr<FruitLuckModel> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> fruits,
        Guid? id = null
    )
    {

        List<Error> errors = new();
        //enforce invariants
        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.FruitLuck.InvalidName);
        }

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)

        {
            errors.Add(Errors.FruitLuck.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }


        return new FruitLuckModel(
        id ?? Guid.NewGuid(),
        name,
        description,
        startDateTime,
        endDateTime,
        DateTime.UtcNow,
        fruits
        );


    }

    public static ErrorOr<FruitLuckModel> From(CreateFruitLuckRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Fruits
            );
    }

    public static ErrorOr<FruitLuckModel> From(Guid id, UpsertFruitLuckRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Fruits,
            id);
    }

}