using BakeryCore.Data;
using BakeryCore.Extensions;
using BakeryCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakeryCore.Controllers;

public class BakeryControllers : ControllerBase
{
    private readonly BakeryContext _context;
    private readonly Random _rand;

    public BakeryControllers(BakeryContext context)
    {
        _context = context;
        _rand = new Random();
    }

    [HttpPost("start")]
    public async Task<IActionResult> BakeryStart(int count)
    {
        if (count <= 0)
            return BadRequest();

        var buns = new List<Bun>();

        for (var i = 0; i < count; i++)
            buns.Add(GenerateBun());

        await _context.Buns.AddRangeAsync(buns);

        await _context.SaveChangesAsync();

        return Ok(count);
    }

    [HttpGet("buns")]
    public async Task<IActionResult> GetBuns()
    {
        var buns = await _context.Buns
            .Where(x => x.ExpiredTime > DateTime.UtcNow && x.Price > 0)
            .ToListAsync();

        if (buns.Count > 0)
        {
            foreach (var bun in buns)
            {
                bun.Price = bun.ComputePrice();
            }

            await _context.SaveChangesAsync();
        }

        var bunsData = buns.Select(x => new BunData()
        {
            Id = x.Id,
            Type = x.Type,
            Price = x.Price,
            ExpectedPrice = x.ComputePrice(true),
            EstimatedTime = x.ComputeEstimatedTime()
        }).ToList();

        return Ok(bunsData);
    }
    private Bun GenerateBun()
    {
        return new Bun()
        {
            Type = BunType(_rand.Next(1, 6)),
            Price = _rand.Next(1, 101),
            SaleTimeInHour = _rand.Next(1, 6),
            BakingTime = DateTime.UtcNow,
            ExpiredTime = DateTime.UtcNow.AddHours(_rand.Next(7, 12))
        };
    }
    private static string BunType(int typeNumber)
    {
        switch (typeNumber)
        {
            case 1: return "cruasan";
            case 2: return "crendel";
            case 3: return "smetannik";
            case 4: return "baget";
            case 5: return "baton";
            default: return "baget";
        }
    }
}
