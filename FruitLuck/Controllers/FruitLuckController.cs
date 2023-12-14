using ErrorOr;
using FruitLuck.Contracts.FruitLucks;
using FruitLuck.Models;
using FruitLuck.ServiceErrors;
using FruitLuck.Services;
using FruitLuck.Services.FruitLucks;
using Microsoft.AspNetCore.Mvc;

namespace FruitLuck.Controllers;



public class FruitLuckController : ApiController
{
    private readonly IFruitLuckService _fruitLuckService;

    public FruitLuckController(IFruitLuckService fruitLuckService)
    {
        _fruitLuckService = fruitLuckService;
    }

    [HttpPost]
    public IActionResult CreateFruitLuck(CreateFruitLuckRequest request)
    {
        ErrorOr<FruitLuckModel> requestToFruitLuckResult = FruitLuckModel.From(request);

        if (requestToFruitLuckResult.IsError)
        {
            return Problem(requestToFruitLuckResult.Errors);
        }
        var fruitLuck = requestToFruitLuckResult.Value;
        ErrorOr<Created> createFruitLuckResult = _fruitLuckService.CreateFruitLuck(fruitLuck);



        return createFruitLuckResult.Match(
            created => CreatedAtGetFruitLuck(fruitLuck),
            errors => Problem(errors)
        );
    }


    [HttpGet("{id:guid}")]
    public IActionResult GetFruitLuck(Guid id)
    {
        ErrorOr<FruitLuckModel> getFruitLuckResult = _fruitLuckService.GetFruitLuck(id);

        return getFruitLuckResult.Match(
            fruitLuck => Ok(MapFruitLuckResponse(fruitLuck)),
            errors => Problem(errors)
        );

    }


    [HttpPut("{id:guid}")]
    public IActionResult UpsertFruitLuck(Guid id, UpsertFruitLuckRequest request)
    {
        ErrorOr<FruitLuckModel> requestToFruitLuckResult = FruitLuckModel.From(id, request);

        if (requestToFruitLuckResult.IsError)
        {
            return Problem(requestToFruitLuckResult.Errors);
        }

        var fruitLuck = requestToFruitLuckResult.Value;
        ErrorOr<UpsertedFruitLuck> upsertedFruitLuckResult = _fruitLuckService.UpsertFruitLuck(fruitLuck);


        return upsertedFruitLuckResult.Match(
         upserted => upserted.IsNewlyCreated ? CreatedAtGetFruitLuck(fruitLuck) : NoContent(),
         errors => Problem(errors)
        );



    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteFruitLuck(Guid id)
    {
        ErrorOr<Deleted> deletedFruitLuckResult = _fruitLuckService.DeleteFruitLuck(id);


        return deletedFruitLuckResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );

    }


    private static FruitLuckResponse MapFruitLuckResponse(FruitLuckModel fruitLuck)
    {
        return new FruitLuckResponse(
            fruitLuck.Id,
            fruitLuck.Name,
            fruitLuck.Description,
            fruitLuck.StartDateTime,
            fruitLuck.EndDateTime,
            fruitLuck.LastModifiedDateTime,
            fruitLuck.Fruits
        );
    }


    private IActionResult CreatedAtGetFruitLuck(FruitLuckModel fruitLuck)
    {
        return CreatedAtAction(
            actionName: nameof(GetFruitLuck),
            routeValues: new { id = fruitLuck.Id },
            value: MapFruitLuckResponse(fruitLuck));
    }


}

