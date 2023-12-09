using ErrorOr;
using FruitLuck.Models;
using FruitLuck.ServiceErrors;

namespace FruitLuck.Services.FruitLucks
{

    public class FruitLuckService : IFruitLuckService
    {

        private static readonly Dictionary<Guid, FruitLuckModel> _fruitLucks = new();

        public void CreateFruitLuck(FruitLuckModel fruitLuck)
        {
            _fruitLucks.Add(fruitLuck.Id, fruitLuck);
        }

        public void DeleteFruitLuck(Guid id)
        {
            _fruitLucks.Remove(id);
        }

        public ErrorOr<FruitLuckModel> GetFruitLuck(Guid id)
        {
            if (_fruitLucks.TryGetValue(id, out var fruitLuck))
            {
                return fruitLuck;
            }

            return Errors.FruitLuck.NotFound;
        }

        public void UpsertFruitLuck(FruitLuckModel fruitLuck)
        {
            _fruitLucks[fruitLuck.Id] = fruitLuck;
        }

        ErrorOr<FruitLuckModel> IFruitLuckService.GetFruitLuck(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}