using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Overwatch.Winforms.Net48
{
    public class DocumentManager
    {
        List<IDocument> documents = new List<IDocument>();
        private IDocument _activeDocument;
        //OrderedList<IDocument> documentHistory = new OrderedList<IDocument>();
        LinkedListNode<IDocument> switchingNode = null;

        public event DocumentEventHandler ActiveDocumentChanged;
        public event DocumentEventHandler DocumentAdded;
        public event DocumentEventHandler DocumentRemoved;
        //public event DocumentMovedEventHandler DocumentMoved;

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

        public void AddOrActivate(IDocument document)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            //EndSwitching();

            IDocument oldDocument = _activeDocument;
            if (documents.Contains(document))
            {
                if (_activeDocument != document)
                {
                    _activeDocument = document;
                    //documentHistory.ShiftToFirstPlace(document);
                    OnActiveDocumentChanged(new DocumentEventArgs(oldDocument));
                }
            }
            else
            {
                documents.Add(document);
                _activeDocument = document;
                //documentHistory.AddFirst(document);
                //document.Closing += new EventHandler(document_Closing);
                OnDocumentAdded(new DocumentEventArgs(document));
                OnActiveDocumentChanged(new DocumentEventArgs(oldDocument));
            }
        }

        public bool HasDocument
        {
            get { return (documents.Count > 0); }
        }

        protected virtual void OnDocumentAdded(DocumentEventArgs e)
        {
            if (DocumentAdded != null)
                DocumentAdded(this, e);
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