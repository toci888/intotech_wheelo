using Intotech.Wheelo.Bll.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Persistence;

public class WorktripgenLogic : Logic<Worktripgen>, IWorktripgenLogic
{
    public override Worktripgen Insert(Worktripgen model)
    {
        Random r = new Random();
        if (model.Searchid == null)
        {
            model.Searchid = "123zxc"+r.Next(0,10000);
        }

        return base.Insert(model);
    }
}
