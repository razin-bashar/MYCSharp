using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Windows.Forms;

namespace KioskSampleApp
{
    class InputLanguageHelper
    {
        InputLanguage _InputLanguage;
        List<string> languageTagList = null ; 

        public InputLanguageHelper()
        {
            languageTagList = new List<string>();
            languageTagList.Add("ar-sa");
            languageTagList.Add("bn-bn");
            languageTagList.Add("zh-cn");
            languageTagList.Add("en-au");
            languageTagList.Add("en-gb");
            languageTagList.Add("en-us");
            languageTagList.Add("fr-fr");
            languageTagList.Add("de-de");
            languageTagList.Add("ja-jp");
            languageTagList.Add("ko-kr");
            languageTagList.Add("ru-ru");
            languageTagList.Add("es-es");
         

        }

        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }


        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }


        public void LoadKeyboardLayout(string languageName)
        {
            _InputLanguage = GetInputLanguageByName(languageName);
            if (_InputLanguage != null)
            {
                InputLanguage.CurrentInputLanguage = _InputLanguage;
                KeyboardManager.LaunchOnScreenKeyboard();

            }

            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }


        public void InstallLanguage()
        {
            List<string> toBeInstalled = new List<string>(languageTagList);
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                string tag = lang.Culture.IetfLanguageTag.ToLower();
                if (toBeInstalled.Contains(tag))
                {
                    int index = toBeInstalled.IndexOf(tag);
                    toBeInstalled.RemoveAt(index);
                }
            }
            if (toBeInstalled.Count == 0) return;

            string script = "";
            foreach( string tag in toBeInstalled){
                script += "$OldList.Add(\"" + tag + "\");";
            }
            script += "Set-WinUserLanguageList $OldList -Force:$true -Confirm:$false;";
            Console.WriteLine(script);
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(" $OldList = Get-WinUserLanguageList;"+
                                                script +
                                                "$OldList;get-service;");
                PowerShellInstance.Invoke();

            }

        }
    }
}
