using System;
using System.Windows.Forms;

namespace CustomWordTab.Dialog
{
    /// <summary>
    /// Modal dialog form implementing IInsertTextView for the MVP pattern.
    /// Provides a text input area and insert button.
    /// </summary>
    public partial class InsertTextForm : Form, IInsertTextView
    {
        public InsertTextForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the text entered by the user.
        /// </summary>
        public string InputText
        {
            get { return txtInput.Text; }
        }

        /// <summary>
        /// Event raised when the insert button is clicked.
        /// The presenter subscribes to this event.
        /// </summary>
        public event EventHandler InsertButtonClicked;

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Insert Heading Text",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
