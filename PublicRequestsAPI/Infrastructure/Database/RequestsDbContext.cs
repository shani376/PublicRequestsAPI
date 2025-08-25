using Microsoft.EntityFrameworkCore;
using PublicRequestsAPI.Domain.DbModel;
using System.Collections.Generic;

namespace PublicRequestsAPI.Infrastructure.Database
{
    public class RequestsDbContext : DbContext
    {
        public RequestsDbContext(DbContextOptions<RequestsDbContext> options) : base(options) { }

        public DbSet<Request> Requests { get; set; }
        

    }
}
