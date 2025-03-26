

namespace Overwatch.Winforms.Net48
{
    public delegate void DocumentEventHandler(object sender, DocumentEventArgs e);

    public class DocumentEventArgs
    {
        IDocument document;

        public DocumentEventArgs(IDocument document)
        {
            this.document = document;
        }

        public IDocument Document
        {
            get { return document; }
        }
    }
}