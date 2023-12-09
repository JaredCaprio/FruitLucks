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
        }
    }
}