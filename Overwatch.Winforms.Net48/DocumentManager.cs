using System;
using System.Xml.Linq;

namespace Overwatch.Winforms.Net48
{
    public class DocumentManager
    {
        public event EventHandler<DocumentChangedEventArgs> ActiveDocumentChanged;
        private Document _activeDocument;

        public DocumentManager()
        {
        }

        public Document ActiveDocument
        {
            get => _activeDocument;
            set
            {
                if (_activeDocument != value)
                {
                    // Set the new active document
                    _activeDocument = value;

                    // Trigger the ActiveDocumentChanged event
                    OnActiveDocumentChanged(new DocumentChangedEventArgs(value));
                }
            }
        }

        // Protected method to raise the event
        protected virtual void OnActiveDocumentChanged(DocumentChangedEventArgs e)
        {
            ActiveDocumentChanged?.Invoke(this, e);
        }


    }

    public class Document
    {
        public string Name { get; set; }

        public Document(string name)
        {
            Name = name;
        }
    }

    public class DocumentChangedEventArgs : EventArgs
    {
        public Document NewDocument { get; }

        public DocumentChangedEventArgs(Document newDocument)
        {
            NewDocument = newDocument;
        }
    }
}