using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Overwatch.Winforms.Net48
{
    public class DocumentManager
    {
        public event DocumentEventHandler ActiveDocumentChanged;
        List<IDocument> documents = new List<IDocument>();
        private IDocument _activeDocument;
        IDocument activeDocument = null;
        //OrderedList<IDocument> documentHistory = new OrderedList<IDocument>();
        LinkedListNode<IDocument> switchingNode = null;

        public DocumentManager()
        {
        }

        public IDocument ActiveDocument
        {
            get => _activeDocument;
            set
            {
                if (_activeDocument != value)
                {
                    // Set the new active document
                    _activeDocument = value;

                    // Trigger the ActiveDocumentChanged event
                    OnActiveDocumentChanged(new DocumentEventArgs(value));
                }
            }
        }

        // Protected method to raise the event
        protected virtual void OnActiveDocumentChanged(DocumentEventArgs e)
        {
            if (ActiveDocumentChanged != null)
                ActiveDocumentChanged(this, e);
        }

        public bool HasDocument
        {
            get { return (documents.Count > 0); }
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