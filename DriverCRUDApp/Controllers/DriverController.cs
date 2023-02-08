using Microsoft.AspNetCore.Mvc;
using DriverCRUDApp.Models;
namespace DriverCRUDApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : Controller
{
	public DriverController()
	{
	}


    [HttpPost("create")]
	public Task<IActionResult> CreateDriver([FromBody] Driver driver)
	{

	}

    [HttpGet("read")]
    public Task<IActionResult> GetDriver([FromBody] Driver driver)
    {

    }

    [HttpPut("update")]
    public Task<IActionResult> UpdateDriver([FromBody] Driver driver)
    {

    }

    [HttpDelete("delete")]
    public Task<IActionResult> DeleteDriver([FromBody] Driver driver)
    {

    }
}



