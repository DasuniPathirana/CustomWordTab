using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace CustomWordTab.TaskPane
{

    /// Custom task pane user control.
    /// Provides a text input area and a button to insert plain text
    /// at the current cursor position in Word.
 
    public partial class TextInsertTaskPaneControl : UserControl
    {
        // Theme colors
        private Color _backColor;
        private Color _foreColor;
        private Color _textBoxBackColor;
        private Color _textBoxForeColor;
        private Color _buttonBackColor;
        private Color _buttonForeColor;
        private Color _borderColor;
        private Color _iconColor;

        public TextInsertTaskPaneControl()
        {
            DetectThemeColors();
            InitializeComponent();
            ApplyThemeColors();
        }

        /// <summary>
        /// Detects the current Office theme and sets color palette accordingly.
        /// Uses the Word Application's ActiveWindow.View background to infer theme.
        /// </summary>
        private void DetectThemeColors()
        {
            bool isDarkTheme = false;

            try
            {
                // Office 2013+ stores theme in registry; 
                // We can also check the background color of the application
                Microsoft.Office.Interop.Word.Application app = Globals.ThisAddIn.Application;

                // Read the Office theme from registry for reliable detection
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Office\16.0\Common"))
                {
                    if (key != null)
                    {
                        object themeValue = key.GetValue("UI Theme");
                        if (themeValue != null)
                        {
                            int theme = Convert.ToInt32(themeValue);
                            // 0 = Colorful, 3 = White, 4 = Dark Gray, 5 = Black (Dark)
                            // 6 = Use system setting
                            isDarkTheme = (theme == 4 || theme == 5);

                            if (theme == 6)
                            {
                                // Check Windows system dark mode
                                using (var appsKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                                {
                                    if (appsKey != null)
                                    {
                                        object lightValue = appsKey.GetValue("AppsUseLightTheme");
                                        if (lightValue != null)
                                        {
                                            isDarkTheme = Convert.ToInt32(lightValue) == 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Fallback: default to light theme if detection fails
                isDarkTheme = false;
            }

            if (isDarkTheme)
            {
                // Dark theme colors (matches Office dark mode)
                _backColor = Color.FromArgb(37, 37, 38);        // Dark background
                _foreColor = Color.FromArgb(220, 220, 220);     // Light text
                _textBoxBackColor = Color.FromArgb(51, 51, 51); // Slightly lighter input area
                _textBoxForeColor = Color.FromArgb(230, 230, 230);
                _buttonBackColor = Color.FromArgb(0, 103, 192); // Accent blue
                _buttonForeColor = Color.White;
                _borderColor = Color.FromArgb(70, 70, 70);      // Subtle border
                _iconColor = Color.FromArgb(0, 120, 212);       // Accent icon color
            }
            else
            {
                // Light theme colors (matches Office light/colorful mode)
                _backColor = Color.FromArgb(245, 246, 247);     // Light background
                _foreColor = Color.FromArgb(33, 33, 33);        // Dark text
                _textBoxBackColor = Color.White;                 // White input area
                _textBoxForeColor = Color.FromArgb(33, 33, 33);
                _buttonBackColor = Color.FromArgb(0, 120, 212); // Accent blue
                _buttonForeColor = Color.White;
                _borderColor = Color.FromArgb(200, 200, 200);   // Subtle border
                _iconColor = Color.FromArgb(0, 120, 212);       // Accent icon color
            }
        }

        /// <summary>
        /// Applies the detected theme colors to all controls.
        /// </summary>
        private void ApplyThemeColors()
        {
            // Main control
            this.BackColor = _backColor;
            this.ForeColor = _foreColor;

            // Header panel (icon + title)
            if (pnlHeader != null)
            {
                pnlHeader.BackColor = _backColor;
                pnlHeader.ForeColor = _foreColor;
            }

            // Icon
            if (picIcon != null)
            {
                picIcon.BackColor = _backColor;
                picIcon.Image = CreateTextInsertIcon(32, _iconColor);
            }

            // Title label
            if (lblTitle != null)
            {
                lblTitle.BackColor = _backColor;
                lblTitle.ForeColor = _foreColor;
            }

            // Separator
            if (pnlSeparator != null)
            {
                pnlSeparator.BackColor = _borderColor;
            }

            // Instruction label
            if (lblInstruction != null)
            {
                lblInstruction.BackColor = _backColor;
                lblInstruction.ForeColor = _foreColor;
            }

            // Text input
            if (txtInput != null)
            {
                txtInput.BackColor = _textBoxBackColor;
                txtInput.ForeColor = _textBoxForeColor;
                txtInput.BorderStyle = BorderStyle.FixedSingle;
            }

            // Insert button
            if (btnInsert != null)
            {
                btnInsert.BackColor = _buttonBackColor;
                btnInsert.ForeColor = _buttonForeColor;
                btnInsert.FlatStyle = FlatStyle.Flat;
                btnInsert.FlatAppearance.BorderSize = 0;
            }
        }

        /// <summary>
        /// Creates a text insert icon programmatically using GDI+.
        /// Draws a document with text lines and a cursor — matches the
        /// "TextBoxInsert" imageMso concept used by Insert Heading ribbon button.
        /// </summary>
        private Image CreateTextInsertIcon(int size, Color accentColor)
        {
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);

                int pad = (int)(size * 0.12);
                int docW = (int)(size * 0.6);
                int docH = (int)(size * 0.7);
                int docX = pad;
                int docY = pad;

                // Document shadow
                using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                {
                    g.FillRectangle(shadowBrush, docX + 2, docY + 2, docW, docH);
                }

                // Document body
                using (var docBrush = new SolidBrush(Color.FromArgb(255, 255, 255)))
                using (var docPen = new Pen(Color.FromArgb(160, 160, 160), 1f))
                {
                    g.FillRectangle(docBrush, docX, docY, docW, docH);
                    g.DrawRectangle(docPen, docX, docY, docW, docH);
                }

                // Text lines inside the document
                int lineY = docY + (int)(docH * 0.2);
                int lineX = docX + (int)(docW * 0.15);
                int lineW = (int)(docW * 0.7);
                using (var linePen = new Pen(Color.FromArgb(180, 180, 180), 1.5f))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int w = (i == 2) ? (int)(lineW * 0.6) : lineW;
                        g.DrawLine(linePen, lineX, lineY, lineX + w, lineY);
                        lineY += (int)(docH * 0.18);
                    }
                }

                // Text cursor / "T" icon in accent color (bottom-right)
                int cursorSize = (int)(size * 0.45);
                int cursorX = size - cursorSize - pad / 2;
                int cursorY = size - cursorSize - pad / 2;

                // Background circle for the T icon
                using (var circleBrush = new SolidBrush(accentColor))
                {
                    g.FillEllipse(circleBrush, cursorX, cursorY, cursorSize, cursorSize);
                }

                // "T" letter
                using (var textFont = new System.Drawing.Font("Segoe UI", cursorSize * 0.45f, FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF textRect = new RectangleF(cursorX, cursorY, cursorSize, cursorSize);
                    g.DrawString("T", textFont, textBrush, textRect, sf);
                }
            }
            return bmp;
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
