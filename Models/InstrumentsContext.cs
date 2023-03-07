using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rosseev_backend_LR1.Models
{
    public class InstrumentsContext : DbContext
    {
    public InstrumentsContext(DbContextOptions<InstrumentsContext> options)
            : base(options)
    {
    }

    public DbSet<Instruments> Instrument { get; set; }
    public DbSet<Consumables> Consumables { get; set; }
    }
}
