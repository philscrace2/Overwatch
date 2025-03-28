// NClass - Free class diagram editor
// Copyright (C) 2006-2009 Balazs Tihanyi
// Copyright (C) 2020 Georgi Baychev
//
// This program is free software; you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation; either version 3 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with
// this program; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Windows.Forms;
using TranslationsNET48;
using Overwatch.Winforms.Net48.Properties;
using System.Resources;
using System.Drawing;

namespace Overwatch.Winforms.Net48.ModelExplorer
{
    public sealed class DiagramNode : ProjectItemNode
    {
        IDiagram diagram;

        static ContextMenuStrip contextMenu = new ContextMenuStrip();

        static DiagramNode()
        {
            ResourceManager resourceManager = new ResourceManager(typeof(Strings));
            contextMenu.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem(Strings.MenuOpen, resourceManager.GetObject("Open") as Image, open_Click),
                new ToolStripMenuItem(Strings.MenuRename, null, renameItem_Click, Keys.F2),
                new ToolStripSeparator(),
                new ToolStripMenuItem(Strings.MenuDeleteProjectItem, resourceManager.GetObject("Delete") as Image,
                    deleteProjectItem_Click)
            });
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="diagram"/> is null.
        /// </exception>
        public DiagramNode(IDiagram diagram)
        {
            if (diagram == null)
                throw new ArgumentNullException("diagram");

            var imageKey = ImageKeyForDiagram(diagram);
            this.diagram = diagram;
            this.Text = diagram.Name;
            this.ImageKey = imageKey;
            this.SelectedImageKey = imageKey;

            diagram.Renamed += new EventHandler(diagram_Renamed);
        }

        private string ImageKeyForDiagram(IDiagram diagram)
        {
            //switch (diagram.DiagramType)
            //{
            //    case DiagramType.ClassDiagram:
            //        var doc = (ClassDiagram) diagram;
            //        if (doc.Language == CSharpLanguage.Instance)
            //            return "csharp";
            //        else if (doc.Language == JavaLanguage.Instance)
            //            return "java";
            //        break;
            //    case DiagramType.UseCaseDiagram:
            //        return "usecase";
            //    default:
            //        return "diagram";
            //}

            return "diagram";
        }

        public IDiagram Diagram
        {
            get { return diagram; }
        }

        public override IProjectItem ProjectItem
        {
            get { return diagram; }
        }

        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                contextMenu.Tag = this;
                return contextMenu;
            }
            set
            {
                base.ContextMenuStrip = value;
            }
        }

        public static object Resources { get; }

        public override void BeforeDelete()
        {
            diagram.Renamed -= new EventHandler(diagram_Renamed);
            base.BeforeDelete();
        }

        public override void LabelModified(NodeLabelEditEventArgs e)
        {
            diagram.Name = e.Label;
        }

        public override void DoubleClick()
        {
            this.ModelView.OnDocumentOpening(new DocumentEventArgs(diagram));
        }

        public override void EnterPressed()
        {
            if (ModelView != null)
                ModelView.OnDocumentOpening(new DocumentEventArgs(diagram));
        }

        private void diagram_Renamed(object sender, EventArgs e)
        {
            Text = diagram.Name;
        }

        private static void open_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;
            ModelView modelView = (ModelView)((ContextMenuStrip)menuItem.Owner).SourceControl;
            DiagramNode node = (DiagramNode)menuItem.Owner.Tag;

            // Open the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*"; // Filter for DLL files
                openFileDialog.Title = "Select a DLL File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Extract the file name without extension
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(selectedFile);

                    // Rename the existing node to the file name (without extension)
                    node.Text = fileNameWithoutExtension;

                    // Optionally, you can update other properties or trigger additional actions
                    // If the DiagramNode has an associated diagram or data that needs to be updated:
                    node.Diagram.Name = fileNameWithoutExtension;

                    // Ensure the model view reflects this change
                    modelView.Refresh(); // Refresh the view to update the node display if necessary
                }
            }

            // The tabbed document will now be opened but this time the ModelProgramGraphView will be used
            modelView.OnDocumentOpening(new DocumentEventArgs(node.Diagram));
        }

        private static void CreateNodeInModelView(ModelView modelView, string nodeName)
        {
            // Assuming a method exists that adds a new node to the ModelView
            // If you're using a TreeView or another collection of nodes in your model view:
            TreeNode newNode = new TreeNode(nodeName);

            // You can add more logic to customize the node further if needed.
            modelView.Nodes.Add(newNode);
            newNode.Expand(); // Optional: Expand the node if needed
        }

        private static void renameItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            DiagramNode node = (DiagramNode) menuItem.Owner.Tag;

            node.EditLabel();
        }

        private static void deleteProjectItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            IDiagram diagram = ((DiagramNode) menuItem.Owner.Tag).Diagram;
            Project project = diagram.Project;

            DialogResult result = MessageBox.Show(
                string.Format(Strings.DeleteProjectItemConfirmation, diagram.Name),
                Strings.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                project.Remove(diagram);
            }
        }
    }
}
