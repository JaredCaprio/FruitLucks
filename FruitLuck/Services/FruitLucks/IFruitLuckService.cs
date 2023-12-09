using FruitLuck.Contracts.FruitLucks;
using FruitLuck.Models;

namespace FruitLuck.Services.FruitLucks
{



    public interface IFruitLuckService
    {
        void CreateFruitLuck(FruitLuckModel FruitLucks);
        void DeleteFruitLuck(Guid id);
        FruitLuckModel GetFruitLuck(Guid id);
        void UpsertFruitLuck(FruitLuckModel fruitLuck);
    }

}