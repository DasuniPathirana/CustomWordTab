using System;

namespace CustomWordTab.Dialog
{

    public class InsertTextPresenter
    {
        private readonly IInsertTextView _view;
        private readonly InsertTextModel _model;

        public InsertTextPresenter(IInsertTextView view, InsertTextModel model)
        {
            _view = view;
            _model = model;

            // Subscribe to view events
            _view.InsertButtonClicked += OnInsertButtonClicked;
        }


        private void OnInsertButtonClicked(object sender, EventArgs e)
        {
            string text = _view.InputText;

            if (string.IsNullOrEmpty(text))
            {
                _view.ShowMessage("Please enter some text to insert.");
                return;
            }

            try
            {
                _model.InsertTextWithHeading(text);
                _view.CloseView();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Error inserting text: " + ex.Message);
            }
        }
    }
}
