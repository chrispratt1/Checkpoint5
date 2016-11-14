using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Checkpoint4.Models;
using System.Data.Entity;

namespace Checkpoint4.DAL
{
    public class BlowOutContext : DbContext
    {
        public BlowOutContext() : base("BlowOutContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}