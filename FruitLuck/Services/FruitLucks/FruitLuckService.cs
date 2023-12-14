using ErrorOr;
using FruitLuck.Models;
using FruitLuck.ServiceErrors;

namespace FruitLuck.Services.FruitLucks
{

    public class FruitLuckService : IFruitLuckService
    {

        private static readonly Dictionary<Guid, FruitLuckModel> _fruitLucks = new();

        public ErrorOr<Created> CreateFruitLuck(FruitLuckModel fruitLuck)
        {
            _fruitLucks.Add(fruitLuck.Id, fruitLuck);

            return Result.Created;
        }

        public ErrorOr<Deleted> DeleteFruitLuck(Guid id)
        {
            _fruitLucks.Remove(id);

            return Result.Deleted;
        }

        public ErrorOr<FruitLuckModel> GetFruitLuck(Guid id)
        {
            if (_fruitLucks.TryGetValue(id, out var fruitLuck))
            {
                return fruitLuck;
            }

            return Errors.FruitLuck.NotFound;
        }

        public ErrorOr<UpsertedFruitLuck> UpsertFruitLuck(FruitLuckModel fruitLuck)
        {
            var IsNewlyCreated = !_fruitLucks.ContainsKey(fruitLuck.Id);

            _fruitLucks[fruitLuck.Id] = fruitLuck;

            return new UpsertedFruitLuck(IsNewlyCreated);
        }


    }
}