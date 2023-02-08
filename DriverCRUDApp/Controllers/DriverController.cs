using Microsoft.AspNetCore.Mvc;
using DriverCRUDApp.Models;
using DriverCRUDApp.Services;
namespace DriverCRUDApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : Controller
{
    private readonly DriverService _driverService;
	public DriverController(DriverService driverService)
	{
        _driverService = driverService;
	}

    [HttpGet]
    public async Task<IActionResult> GetDriver()
    {
        try
        {
            List<Driver> drivers = await _driverService.GetAllDrivers();

            return Ok(drivers);
        }
        catch(Exception e)
        {
            return StatusCode(500, $"Internal Server Error \n{e}");
        }
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateDriver([FromBody] Driver driver)
    {
        try
        {
            List<Driver> newDrivers = await _driverService.CreateDriver(driver);

            return Ok(newDrivers);

        }
        catch(Exception e)
        {
            return StatusCode(500, $"Internal Server Error \n{e}");
        }
    }


    
    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] Driver driver)
    {
        try
        {
            List<Driver> newDrivers = await _driverService.UpdateDriver(driver);

            return Ok(newDrivers);
        }
        catch(Exception e)
        {
            return StatusCode(500, $"Internal Server Error\n{e}");
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteDriver([FromBody] string id)
    {
        try
        {
            List<Driver> newDrivers = await _driverService.DeleteDriver(id);
            return Ok(newDrivers);
        }
        catch(Exception e)
        {
            return StatusCode(500, $"Internal Server Error {e}");
        }
    }
    

}



