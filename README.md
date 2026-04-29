# CustomWordTab — Word VSTO Add-in

A Microsoft Word VSTO Add-in built with C# that adds a custom ribbon tab with two buttons: one to toggle a custom task pane for plain text insertion, and another to open a modal dialog that inserts text with Heading 1 style using the MVP pattern.

## Prerequisites

- **Visual Studio 2022** with the **"Office/SharePoint development"** workload installed
- **Microsoft Word** installed locally (not Word for the web)
- **.NET Framework 4.7.2** or higher

## How to Build and Run

1. Open `CustomWordTab.sln` in Visual Studio 2022.
2. Build the solution (**Ctrl+Shift+B**).
3. Press **F5** to debug — Word will launch with the add-in loaded.
4. Look for the **"Text Tools"** tab in the ribbon.

> **Note:** If the project doesn't load correctly from the `.sln`, create a new **Word VSTO Add-in** project in Visual Studio using `File > New > Project > Word VSTO Add-in`, then copy the source files from this repo into the project structure.

## Features

### Custom Ribbon Tab — "Text Tools"
- **Task Pane** button: Toggles the custom task pane visibility.
- **Insert Heading** button: Opens a modal dialog for text insertion with Heading 1 style.

### Custom Task Pane
- Contains a multiline text input area and an "Insert Text" button.
- Clicking the button inserts the entered text at the current cursor position.
- If text is selected in Word, replaces the selection with the entered text.
- Plain text insertion only (no style applied).

### Dialog Box (MVP Pattern)
- Modal dialog that blocks interaction with Word while open.
- Contains a multiline text input area and an "Insert Text" button.
- Clicking the button inserts the entered text at the current cursor position.
- If text is selected in Word, replaces the selection.
- Applies **Heading 1** style to the inserted text.

## MVP Pattern Structure

The dialog box uses a simple **Model-View-Presenter** pattern:

```
Dialog/
├── IInsertTextView.cs      # View interface
├── InsertTextForm.cs        # View implementation (Windows Form)
├── InsertTextForm.Designer.cs
├── InsertTextModel.cs       # Model (Word document interaction logic)
└── InsertTextPresenter.cs   # Presenter (coordinates View and Model)
```

### How it works:

1. **IInsertTextView** (Interface): Defines the contract for the view — exposes `InputText` property, `InsertButtonClicked` event, and methods like `CloseView()` and `ShowMessage()`.

2. **InsertTextForm** (View): A Windows Form that implements `IInsertTextView`. It contains the UI controls (text box, button) but has no business logic. The button click simply raises the `InsertButtonClicked` event.

3. **InsertTextModel** (Model): Handles the actual Word document interaction — inserting text at the cursor position and applying the Heading 1 style using the Word interop API.

4. **InsertTextPresenter** (Presenter): Created with references to the view (via interface) and model. Subscribes to the view's `InsertButtonClicked` event, validates input, calls the model to insert text, and instructs the view to close or show error messages.

This separation means:
- The **View** knows nothing about Word — it just raises events and displays data.
- The **Model** knows nothing about the UI — it just operates on the Word document.
- The **Presenter** is the glue — it could be unit tested with a mock `IInsertTextView`.

## Project Structure

```
CustomWordTab/
├── CustomWordTab.sln
├── README.md
├── .gitignore
└── CustomWordTab/
    ├── CustomWordTab.csproj
    ├── ThisAddIn.cs              # Add-in entry point, manages task pane
    ├── Dialog/
    │   ├── IInsertTextView.cs    # MVP - View interface
    │   ├── InsertTextForm.cs     # MVP - View implementation
    │   ├── InsertTextForm.Designer.cs
    │   ├── InsertTextModel.cs    # MVP - Model
    │   └── InsertTextPresenter.cs# MVP - Presenter
    ├── Ribbon/
    │   ├── CustomRibbon.cs       # Ribbon callbacks
    │   └── CustomRibbon.xml      # Ribbon UI definition
    ├── TaskPane/
    │   ├── TextInsertTaskPaneControl.cs
    │   └── TextInsertTaskPaneControl.Designer.cs
    └── Properties/
        └── AssemblyInfo.cs
```

## Challenges

- **Ribbon XML vs Ribbon Designer**: Chose the Ribbon XML (`IRibbonExtensibility`) approach over the visual Ribbon Designer. It keeps the ribbon definition clean and explicit in XML, and the callback methods are straightforward C# methods.
- **Applying Heading 1 after insertion**: After using `Selection.TypeText()`, the cursor moves to the end of the inserted text. To apply the style, a `Range` object is created from the start position (captured before insertion) to the end position (cursor location after insertion), then the style is applied to that range.

## Improvements with More Time

- Add unit tests for the `InsertTextPresenter` using a mock `IInsertTextView`.
- Apply the MVP pattern to the task pane as well for consistency.
- Add undo support so the text insertion can be undone with Ctrl+Z as a single action.
- Add ribbon button state toggling (pressed/unpressed appearance) to reflect task pane visibility.
- Add more text formatting options in the dialog (font, size, other styles).
