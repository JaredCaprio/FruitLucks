using ErrorOr;

namespace FruitLuck.ServiceErrors
{

    public static class Errors
    {
        public static class FruitLuck
        {
            public static Error NotFound => Error.NotFound(
                code: "FruitLuck.NotFound",
                description: "FruitLuck Not Found"
            );
            public static Error InvalidName => Error.Validation(
                code: "FruitLuck.InvalidName",
                description: $"FruitLuck name is must be at least {Models.FruitLuckModel.MinNameLength} " +
                 $" characters long and at most {Models.FruitLuckModel.MaxNameLength} characters long."
            );
            public static Error InvalidDescription => Error.Validation(
                code: "FruitLuck.InvalidName",
                description: $"FruitLuck description is must be at least {Models.FruitLuckModel.MinDescriptionLength}  " +
                 $" characters long and at most {Models.FruitLuckModel.MaxDescriptionLength} characters long."
            );
        }
    }
}