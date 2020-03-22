using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DonationDbContext :  DbContext
    {

        public DonationDbContext(DbContextOptions <DonationDbContext> options) : base(options)
        {

        }

        public DbSet<DCandidate> DCandidate { get; set; }
    }
}
