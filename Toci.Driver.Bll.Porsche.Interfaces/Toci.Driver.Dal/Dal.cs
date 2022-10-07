using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Dal.Invitation
{
    public class Dal<TModel> : DalBase<TModel> where TModel : class
    {
        public Dal(DriverEntities db) : base(db)
        {
        }
        // ??
       
    }
}