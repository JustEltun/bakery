using BakeryCore.Models;

namespace BakeryCore.Extensions;

public static class BunExtensions
{
    public static  double ComputePrice(this Bun bun, bool isFuture = false)
    {
        var estimatedPeriod = bun.ComputeEstimatedPeriod();
        switch (bun.Type)
        {
            case "crendel":
                if(estimatedPeriod >= 1) 
                    return Math.Round(bun.Price -= bun.Price / Math.Pow(2,Math.Truncate(estimatedPeriod)) , 2);

                if (isFuture)
                    return Math.Round(bun.Price -= bun.Price / Math.Pow(2,Math.Truncate(estimatedPeriod+1)) , 2);

                break;

            case "smetannik":
                if (!isFuture)
                    return Math.Round(bun.Price -= (DateTime.UtcNow - bun.BakingTime).Hours * (bun.Price * Math.Pow(2,(DateTime.UtcNow - bun.BakingTime).Hours+1) / 100), 2);

                bun.Price = Math.Round(bun.Price -= (DateTime.UtcNow.AddHours(1) - bun.BakingTime).Hours * (bun.Price * Math.Pow(2,(DateTime.UtcNow.AddHours(1) - bun.BakingTime).Hours+1) / 100), 2);
                break;
            default:
                if (!isFuture)
                   return  Math.Round(bun.Price -= (DateTime.UtcNow - bun.BakingTime).Hours * (bun.Price *  2 / 100), 2);

                bun.Price = Math.Round(bun.Price -= (DateTime.UtcNow.AddHours(1) - bun.BakingTime).Hours * (bun.Price *  2 / 100), 2);
                break;
        }

        if (bun.Price <= 0)
            bun.Price = 0;
        
        return bun.Price;
    }
    
    public static string ComputeEstimatedTime(this Bun bun)
    {
        var totalPeriod = bun.ComputeEstimatedPeriod();
        var calcPeriod = totalPeriod - Math.Truncate(totalPeriod);

        return (DateTime.UtcNow.AddMinutes(Math.Abs(bun.SaleTimeInHour*60 - (bun.SaleTimeInHour* 60 * calcPeriod))) - DateTime.UtcNow).ToString("g");
    }
    private static double ComputeEstimatedPeriod(this Bun bun)
    {
        var totalMinutes = (DateTime.UtcNow - bun.BakingTime).TotalMinutes;
        var saleTimeInMinutes = bun.SaleTimeInHour * 60;
        var totalPeriod = totalMinutes / saleTimeInMinutes;

        return totalPeriod;
    }

}
