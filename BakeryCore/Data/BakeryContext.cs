using BakeryCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryCore.Data;

public class BakeryContext : DbContext
{
    public BakeryContext(DbContextOptions<BakeryContext> options) : base(options) { }

    public DbSet<Bun> Buns { get; set; }
}
