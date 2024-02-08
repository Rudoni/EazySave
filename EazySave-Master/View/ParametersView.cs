using EazySave_Master.Model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.View
{
    internal class ParametersView
    {
        public string lang { get; set; }

        ModelView.ModelView mv = new ModelView.ModelView();
        public ParametersView() { }

        enum Parameters
        {
            ChangeLanguage = 1,
            Return = 2
        }

        // Enum Languages
        enum LanguageOption
        {
            French = 1,
            English = 2
        }

      

        public void update(string lang)
        {
            
        }
    }
}
