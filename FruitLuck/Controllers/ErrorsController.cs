using Microsoft.AspNetCore.Mvc;

namespace FruitLuck.Controllers;


public class ErrorsController : ControllerBase
{
    [Route("/error")]

    public IActionResult Error()
    {
        return Problem();
    }
}