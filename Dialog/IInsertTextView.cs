using System;

namespace CustomWordTab.Dialog
{


    public interface IInsertTextView
    {

        string InputText { get; }


        event EventHandler InsertButtonClicked;

        void CloseView();

        void ShowMessage(string message);
    }
}
