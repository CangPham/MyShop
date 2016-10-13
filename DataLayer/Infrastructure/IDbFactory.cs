using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopDbContext Init();
    }
}
