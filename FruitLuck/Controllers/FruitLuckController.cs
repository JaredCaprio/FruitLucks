using FruitLuck.Contracts.FruitLucks;
using FruitLuck.Models;
using FruitLuck.Services.FruitLucks;
using Microsoft.AspNetCore.Mvc;

namespace FruitLuck.Controllers;


[ApiController]
[Route("[controller]")]
public class FruitLuckController : ControllerBase
{
    private readonly IFruitLuckService _fruitLuckService;

    public FruitLuckController(IFruitLuckService fruitLuckService)
    {
        _fruitLuckService = fruitLuckService;
    }

    [HttpPost]
    public IActionResult CreateFruitLuck(CreateFruitLuckRequest request)
    {
        var fruitLuck = new FruitLuckModel(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Fruits);

        _fruitLuckService.CreateFruitLuck(fruitLuck);


        var response = new FruitLuckResponse(
            fruitLuck.Id,
            fruitLuck.Name,
            fruitLuck.Description,
            fruitLuck.StartDateTime,
            fruitLuck.EndDateTime,
            fruitLuck.LastModifiedDateTime,
            fruitLuck.Fruits);

        return CreatedAtAction(
            actionName: nameof(GetFruitLuck),
            routeValues: new { id = fruitLuck.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetFruitLuck(Guid id)
    {
        FruitLuckModel fruitLuck = _fruitLuckService.GetFruitLuck(id);

        var response = new FruitLuckResponse(
            fruitLuck.Id,
            fruitLuck.Name,
            fruitLuck.Description,
            fruitLuck.StartDateTime,
            fruitLuck.EndDateTime,
            fruitLuck.LastModifiedDateTime,
            fruitLuck.Fruits
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertFruitLuck(Guid id, UpsertFruitLuckRequest request)
    {
        var fruitLuck = new FruitLuckModel(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Fruits
        );

        _fruitLuckService.UpsertFruitLuck(fruitLuck);
        //TODO: return 201 if a new fruit luck was created

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteFruitLuck(Guid id)
    {
        _fruitLuckService.DeleteFruitLuck(id);
        return NoContent();
    }


}

