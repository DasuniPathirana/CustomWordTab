using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace CustomWordTab.TaskPane
{

    /// Custom task pane user control.
    /// Provides a text input area and a button to insert plain text
    /// at the current cursor position in Word.
 
    public partial class TextInsertTaskPaneControl : UserControl
    {
        public TextInsertTaskPaneControl()
        {
            InitializeComponent();
        }

 
        /// Inserts the entered text at the current cursor position.
        /// If text is selected in Word, replaces the selection.
        /// No style is applied — plain text insertion only.

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter some text to insert.",
                    "Insert Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Microsoft.Office.Interop.Word.Application app = Globals.ThisAddIn.Application;
                Microsoft.Office.Interop.Word.Selection selection = app.Selection;


                // TypeText replaces selected text or inserts at cursor position
                selection.TypeText(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting text: " + ex.Message,
                    "Insert Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
