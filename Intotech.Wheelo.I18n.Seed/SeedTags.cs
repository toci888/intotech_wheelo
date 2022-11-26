using Intotech.Wheelo.Common;
using Intotech.Wheelo.I18n.Database.Persistence.Models;
using Intotech.Wheelo.Tests.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.I18n.Seed
{
    public class SeedTags : SeedI18nLogic<Tag>
    {
        public override void Insert()
        {
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Success });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Polish });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.English });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.German });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.French });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Italian });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Spanish });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Portugese });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Ukrainian });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Swedish });
            ModelsCollection.Add(new Tag() { Tag1 = I18nTags.Dutch });  


            InsertCollection(ModelsCollection);
        }
    }
}
