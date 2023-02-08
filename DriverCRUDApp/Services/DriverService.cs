using System;
using System.IO;
using DriverCRUDApp.Models;
namespace DriverCRUDApp.Services;

public class DriverService
{
	private readonly string _filePath = $"{Directory.GetCurrentDirectory()}/Data/main.txt";


	private async Task<List<string>> ReadFullFile()
	{
        string[] input = await File.ReadAllLinesAsync(_filePath);
		return input.ToList();
    }

	private async Task WriteFullFile(List<string> data)
	{
		await File.WriteAllLinesAsync(_filePath, data);
		return;
	}


	public async Task<List<Driver>> GetAllDrivers()
	{
		List<string> data = await ReadFullFile();
		List<Driver> drivers = new List<Driver>();

		foreach(string line in data)
		{
			string[] entries = line.Split(',');

			if (entries.Length != 5) throw new Exception("Invalid item in data file");

			Driver driver = new Driver(entries);

			drivers.Add(driver);
		}

		return drivers;
	}

	public async Task<List<Driver>> CreateDriver(Driver driver)
	{

        string newItem = $"{driver.Id},{driver.FirstName},{driver.LastName},{driver.Email},{driver.PhoneNumber}";

		string[] appendedItems = { newItem }; //created an array of one item bec the append method takes an Ienumerable for the new data parameter
		await File.AppendAllLinesAsync(_filePath, appendedItems);


		return await GetAllDrivers();
    }

	public async Task<List<Driver>> DeleteDriver(string id)
	{
        List<string> data = await ReadFullFile();

		data.RemoveAll(item => item.Split(',')[0] == id);

		await WriteFullFile(data);

		return await GetAllDrivers();

    }

    public async Task<List<Driver>> UpdateDriver(Driver newDriver)
    {
        List<string> data = await ReadFullFile();

		int count = 0;
        foreach(string item in data)
		{
			string[] entries = item.Split(',');
			if (entries[0] == newDriver.Id)
			{
				data[count] = $"{newDriver.Id},{newDriver.FirstName},{newDriver.LastName},{newDriver.Email},{newDriver.PhoneNumber}";
				break;
			}

			count++;
		}

        await WriteFullFile(data);

        return await GetAllDrivers();

    }
}

