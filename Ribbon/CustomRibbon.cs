using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using CustomWordTab.Dialog;

namespace CustomWordTab.Ribbon
{

    [ComVisible(true)]
    public class CustomRibbon : IRibbonExtensibility
    {
        private IRibbonUI _ribbonUI;

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("CustomWordTab.Ribbon.CustomRibbon.xml");
        }

        public void Ribbon_Load(IRibbonUI ribbonUI)
        {
            _ribbonUI = ribbonUI;
        }


        public void OnToggleTaskPane(IRibbonControl control)
        {
            Globals.ThisAddIn.ToggleTaskPane();
        }


        public void OnOpenDialog(IRibbonControl control)
        {
            var model = new InsertTextModel();
            var form = new InsertTextForm();
            var presenter = new InsertTextPresenter(form, model);
            form.ShowDialog();
        }


        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream(resourceName);
            if (stream == null)
                return string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
