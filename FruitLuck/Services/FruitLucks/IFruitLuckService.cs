using ErrorOr;
using FruitLuck.Contracts.FruitLucks;
using FruitLuck.Models;

namespace FruitLuck.Services.FruitLucks
{



    public interface IFruitLuckService
    {
        ErrorOr<Created> CreateFruitLuck(FruitLuckModel FruitLucks);
        ErrorOr<Deleted> DeleteFruitLuck(Guid id);
        ErrorOr<List<FruitLuckModel>> GetAllFruitLucks();
        ErrorOr<FruitLuckModel> GetFruitLuck(Guid id);
        ErrorOr<UpsertedFruitLuck> UpsertFruitLuck(FruitLuckModel fruitLuck);
    }

}