using Intotech.Common.Bll;
using Microsoft.EntityFrameworkCore;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence
{
    public class Logic<TModel> : LogicBase<TModel> where TModel : class
    {
        public Logic() : base("Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka") { }
        protected override DbContext GetEfHandle()
        {
            return new IntotechWheeloContext();
        }
    }
}
