using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Intotech.Wheelo.Common.Translations.Translation
{
    public class TranslationRenderer
    {
        public void ClassRender(string outputPath, List<I18nManager> i18NManagers)
        {
            outputPath += "WheeloTranslationEngineI18n.cs";

            using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
            {
                writer.WriteLine("using System;\r\n" +
                                "using System.Collections.Generic;\r\n" +
                                "using System.Linq;\r\n" +
                                "using System.Text;\r\n" +
                                "using System.Threading.Tasks;\r\n");

                writer.WriteLine("namespace Intotech.Wheelo.Common.Translations\r\n{");

                writer.WriteLine("    public class WheeloTranslationEngineI18n");

                writer.WriteLine("    {\r\n        protected Dictionary<string, Dictionary<string, string>> ApplicationTranslationData;      ");

                writer.WriteLine("        public WheeloTranslationEngineI18n(Dictionary<string, Dictionary<string, string>> applicationTranslationData)\r\n        " +
                    "{\r\n            ApplicationTranslationData = applicationTranslationData;\r\n            ");

                foreach (var nManager in i18NManagers)
                {
                    foreach (var item in nManager.TranslationsMap)
                    {
                        writer.WriteLine(
                            
                            
                            $"\r\n                        {{\"{item.Value.Tag}\", \"{item.Value.Content}\"}},");
                    }
                }

                writer.WriteLine("            \r\n        }\r\n    }\r\n}");

            }

        }
    }
}
