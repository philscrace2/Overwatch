using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch.Winforms.Net48
{
    public partial class MainForm: Form
    {
        DocumentManager docManager = new DocumentManager();
        bool showModelExplorer = true;
        bool showNavigator = true;
        public MainForm()
        {
            InitializeComponent();

            tabbedWindow.DocumentManager = docManager;
            //Workspace.Default.ActiveProjectChanged += delegate { UpdateTitleBar(); };
            //Workspace.Default.ActiveProjectStateChanged += delegate { UpdateTitleBar(); };
            Workspace.Default.ProjectAdded += delegate { ShowModelExplorer = true; };
            docManager.ActiveDocumentChanged += docManager_ActiveDocumentChanged;
            modelExplorer.Workspace = Workspace.Default;
        }

        private void docManager_ActiveDocumentChanged(object sender, DocumentEventArgs e)
        {
            if (docManager.HasDocument)
            {
                Workspace.Default.ActiveProject = docManager.ActiveDocument.Project;
                //docManager.ActiveDocument.Modified += ActiveDocument_Modified;
                //docManager.ActiveDocument.StatusChanged += ActiveDocument_StatusChanged;
                //docManager.ActiveDocument.ClipboardAvailabilityChanged +=
                //    ActiveDocument_ClipboardAvailabilityChanged;
                //docManager.ActiveDocument.UndoRedoChanged += ActiveDocument_UndoRedoChanged;
                //this.tabbedWindow.Canvas.Focus();
            }
            else
            {
                Workspace.Default.ActiveProject = null;
            }

            IDocument oldDocument = e.Document;
            //if (oldDocument != null)
            //{
            //    oldDocument.Modified -= ActiveDocument_Modified;
            //    oldDocument.StatusChanged -= ActiveDocument_StatusChanged;
            //    oldDocument.ClipboardAvailabilityChanged -=
            //        ActiveDocument_ClipboardAvailabilityChanged;
            //    oldDocument.UndoRedoChanged -= ActiveDocument_UndoRedoChanged;
            //}


        }

        private bool ShowModelExplorer
        {
            get
            {
                return showModelExplorer;
            }
            set
            {
                showModelExplorer = value;

                //if (!showModelExplorer)
                //{
                //    if (showNavigator)
                //        toolsPanel.Panel1Collapsed = true;
                //    else
                //        windowClient.Panel2Collapsed = true;
                //    showModelExplorer = false;
                //}
                //else
                //{
                //    toolsPanel.Panel1Collapsed = false;
                //    windowClient.Panel2Collapsed = false;
                //    if (!showNavigator)
                //        toolsPanel.Panel2Collapsed = true;
                //}
            }
        }
    }
}
