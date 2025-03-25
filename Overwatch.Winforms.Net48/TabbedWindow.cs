using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Overwatch.Winforms.Net48
{
    public partial class TabbedWindow : UserControl
    {
        DocumentManager docManager = null;

        public TabbedWindow()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public DocumentManager DocumentManager
        {
            get
            {
                return docManager;
            }
            set
            {
                if (docManager != value)
                {
                    docManager = value;

                    if (docManager != null)
                        docManager.ActiveDocumentChanged -= docManager_ActiveDocumentChanged;
                    docManager = value;

                    if (docManager != null)
                    {
                        docManager.ActiveDocumentChanged += docManager_ActiveDocumentChanged;
                        canvas.Document = docManager.ActiveDocument;
                    }
                    else
                    {
                        canvas.Document = null;
                    }
                    tabBar.DocumentManager = value;
                }
            }
        }

        [Browsable(false)]
        public TabBar TabBar
        {
            get { return tabBar; }
        }

        [Browsable(false)]
        public Canvas Canvas
        {
            get { return canvas; }
        }

        private void docManager_ActiveDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            canvas.Document = docManager.ActiveDocument;
        }
    }
}
