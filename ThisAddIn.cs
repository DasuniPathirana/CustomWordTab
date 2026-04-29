using System;
using Microsoft.Office.Core;
using Microsoft.Office.Tools;
using CustomWordTab.Ribbon;
using CustomWordTab.TaskPane;

namespace CustomWordTab
{
    public partial class ThisAddIn
    {
        private Microsoft.Office.Tools.CustomTaskPane _taskPane;

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            // Create and configure the custom task pane
            var taskPaneControl = new TextInsertTaskPaneControl();
            _taskPane = this.CustomTaskPanes.Add(taskPaneControl, "Text Insert");
            _taskPane.Width = 300;
            _taskPane.Visible = false;
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }


        public void ToggleTaskPane()
        {
            if (_taskPane != null)
            {
                _taskPane.Visible = !_taskPane.Visible;
            }
        }

        // Returns the custom ribbon extensibility object.
        // This tells Word to use our custom ribbon XML.
        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new CustomRibbon();
        }

        #region VSTO generated code


        private void InternalStartup()
        {
            this.Startup += new EventHandler(ThisAddIn_Startup);
            this.Shutdown += new EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
