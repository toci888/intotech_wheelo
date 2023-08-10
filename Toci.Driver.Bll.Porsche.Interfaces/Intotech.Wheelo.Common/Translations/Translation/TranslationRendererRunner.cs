using Intotech.Wheelo.Common.I18nManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Wheelo.Common.Translations.Translation
{
    public class TranslationRendererRunner
    {
        public virtual void Run(string outputPath)
        {
            List<I18nManager> i18NManagers = new List<I18nManager>()
            {
                new EnI18nManager(),
                new PlI18nManager()
            };

            TranslationRenderer renderer = new();

            renderer.ClassRender(outputPath, i18NManagers);
        } 
    }
}
