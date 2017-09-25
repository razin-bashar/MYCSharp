using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace KioskSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region event handlers

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
           // new InputLanguageHelper().LoadArabicKeyboardLayout();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.


                /*PowerShellInstance.AddScript("param($param1) $OldList = Get-WinUserLanguageList; $s = 'test string value'; " +
                        "$OldList; $s; $param1;");

                // use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                PowerShellInstance.AddParameter("param1", "parameter 1 value!");*/

                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                foreach (PSObject outputItem in PSOutput)
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        //TODO: do something with the output item 
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    }
                }

            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           // KeyboardManager.KillOnScreenKeyboard();
            new InputLanguageHelper().InstallLanguage();
            new InputLanguageHelper().LoadKeyboardLayout("arabic");
        }

        #endregion
    }
}
