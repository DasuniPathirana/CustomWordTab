using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        /// <summary>
        /// Callback for the Task Pane button icon.
        /// Returns a custom-drawn bitmap icon showing a document
        /// with text lines and a blue "T" accent badge.
        /// </summary>
        public Bitmap GetTaskPaneImage(IRibbonControl control)
        {
            int size = 32;
            Bitmap bmp = new Bitmap(size, size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);

                Color accentColor = Color.FromArgb(0, 120, 212);

                int pad = 2;
                int docW = 20;
                int docH = 24;
                int docX = pad;
                int docY = pad;

                // Document shadow
                using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                {
                    g.FillRectangle(shadowBrush, docX + 2, docY + 2, docW, docH);
                }

                // Document body (white page)
                using (var docBrush = new SolidBrush(Color.White))
                using (var docPen = new Pen(Color.FromArgb(140, 140, 140), 1f))
                {
                    g.FillRectangle(docBrush, docX, docY, docW, docH);
                    g.DrawRectangle(docPen, docX, docY, docW, docH);
                }

                // Text lines inside the document
                using (var linePen = new Pen(Color.FromArgb(170, 170, 170), 1.5f))
                {
                    g.DrawLine(linePen, docX + 4, docY + 6, docX + 16, docY + 6);
                    g.DrawLine(linePen, docX + 4, docY + 10, docX + 14, docY + 10);
                    g.DrawLine(linePen, docX + 4, docY + 14, docX + 12, docY + 14);
                }

                // Blue "T" badge (bottom-right corner)
                int badgeSize = 16;
                int badgeX = size - badgeSize - 1;
                int badgeY = size - badgeSize - 1;

                using (var circleBrush = new SolidBrush(accentColor))
                {
                    g.FillEllipse(circleBrush, badgeX, badgeY, badgeSize, badgeSize);
                }

                // "T" letter in the badge
                using (var textFont = new Font("Segoe UI", 8f, FontStyle.Bold))
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    RectangleF textRect = new RectangleF(badgeX, badgeY, badgeSize, badgeSize);
                    g.DrawString("T", textFont, textBrush, textRect, sf);
                }
            }
            return bmp;
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
