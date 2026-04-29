using Microsoft.Office.Interop.Word;

namespace CustomWordTab.Dialog
{

    public class InsertTextModel
    {

        public void InsertTextWithHeading(string text)
        {
            Application app = Globals.ThisAddIn.Application;
            Selection selection = app.Selection;

            // Remember start position before inserting
            int startPos = selection.Start;

            // TypeText replaces selected text or inserts at cursor
            selection.TypeText(text);

            // Get end position after insertion
            int endPos = selection.Start;

            // Select the inserted text and apply Heading 1 style
            Range range = app.ActiveDocument.Range(startPos, endPos);
            range.set_Style(WdBuiltinStyle.wdStyleHeading1);

            // Move cursor to end of inserted text
            selection.SetRange(endPos, endPos);
        }
    }
}
