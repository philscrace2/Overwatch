﻿// NClass - Free class diagram editor
// Copyright (C) 2006-2009 Balazs Tihanyi
// Copyright (C) 2016-2017 Georgi Baychev
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
using DevExpress.XtraEditors.Filtering;

namespace Overwatch.Winforms.Net48.ModelExplorer
{
    public sealed class ProjectNode : ModelNode
    {
        Project project;
        private readonly ModelView modelView;
        static ContextMenuStrip contextMenu = new ContextMenuStrip();

        public void BuildProjectNode()
        {
            contextMenu.Items.AddRange(new ToolStripItem[] {
                new ToolStripMenuItem(Strings.MenuAddNew, Resources.NewDocument,
                    new ToolStripMenuItem(Strings.MnuNModelProject, null, newNModelDiagram_Click)
                ),
                new ToolStripSeparator(),
                new ToolStripMenuItem(Strings.MenuSave, Resources.Save, save_Click),
                new ToolStripMenuItem(Strings.MenuSaveAs, null, saveAs_Click),
                new ToolStripMenuItem(Strings.MenuRename, null, rename_Click, Keys.F2),
                new ToolStripSeparator(),
                new ToolStripMenuItem(Strings.MenuCloseProject, null, close_Click)
            });
        }

        /// <exception cref="ArgumentNullException">
        /// <paramref name="project"/> is null.
        /// </exception>
        public ProjectNode(Project project, ModelView modelView)
        {
            BuildProjectNode();

            if (project == null)
                throw new ArgumentNullException("project");

            this.project = project;
            this.modelView = modelView;
            this.Text = project.Name;
            this.ImageKey = "project";
            this.SelectedImageKey = "project";
            this.ToolTipText = project.FilePath;

            AddProjectItemNodes(project);
            project.Renamed += new EventHandler(project_Renamed);
            project.ItemAdded += new ProjectItemEventHandler(project_ItemAdded);
            project.ItemRemoved += new ProjectItemEventHandler(project_ItemRemoved);
        }

        public Project Project
        {
            get { return project; }
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

        private void AddProjectItemNodes(Project project)
        {
            if (project.IsEmpty)
            {
            //    ModelNode node = new EmptyProjectNode(project);
            //    Nodes.Add(node);
            //    if (TreeView != null)
            //        node.AfterInitialized();
            }
            else
            {
                foreach (IProjectItem projectItem in project.Items)
                {
                    AddProjectItemNode(projectItem);
                }
            }
        }

        private void AddProjectItemNode(IProjectItem projectItem)
        {
            ModelNode node = null;

            if (projectItem is IDiagram)
            {
                IDiagram diagram = (IDiagram) projectItem;
                //node = new DiagramNode(diagram);
                //if (TreeView != null)
                    //ModelView.OnDocumentOpening(new DocumentEventArgs(diagram));
            }
            // More kind of items might be possible later...

            if (node != null)
            {
                Nodes.Add(node);
                if (TreeView != null)
                {
                    node.AfterInitialized();
                    TreeView.SelectedNode = node;
                }
                if (projectItem.IsUntitled)
                {
                    node.EditLabel();
                }
            }
        }

        private void RemoveProjectItemNode(IProjectItem projectItem)
        {
            foreach (ProjectItemNode node in Nodes)
            {
                if (node.ProjectItem == projectItem)
                {
                    node.Delete();
                    return;
                }
            }
        }

        public override void LabelModified(NodeLabelEditEventArgs e)
        {
            project.Name = e.Label;

            if (project.Name != e.Label)
                e.CancelEdit = true;
        }

        private void project_Renamed(object sender, EventArgs e)
        {
            Text = project.Name;
        }

        private void project_ItemAdded(object sender, ProjectItemEventArgs e)
        {
            AddProjectItemNode(e.ProjectItem);
        }

        private void project_ItemRemoved(object sender, ProjectItemEventArgs e)
        {
            RemoveProjectItemNode(e.ProjectItem);
            if (project.IsEmpty)
            {
                ModelNode node = new EmptyProjectNode(project);
                Nodes.Add(node);
                if (TreeView != null)
                    node.AfterInitialized();
            }
        }

        public override void BeforeDelete()
        {
            project.Renamed -= new EventHandler(project_Renamed);
            project.ItemAdded -= new ProjectItemEventHandler(project_ItemAdded);
            project.ItemRemoved -= new ProjectItemEventHandler(project_ItemRemoved);
            base.BeforeDelete();
        }

        private void newNModelDiagram_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem)sender;

            // Open the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*"; // Filter for DLL files
                openFileDialog.Title = "Select a DLL File";

                TreeNode node = ModelView.SelectedNode;
                TreeNode newNode = new TreeNode("New Diagram");
                ModelView.Nodes.Add(newNode);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Extract the file name without extension
                    string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(selectedFile);

                    // Rename the existing node to the file name (without extension)
                    newNode.Text = fileNameWithoutExtension;

                    // Optionally, you can update other properties or trigger additional actions
                    // If the DiagramNode has an associated diagram or data that needs to be updated:
                    newNode.Name = fileNameWithoutExtension;

                    // Ensure the model view reflects this change
                    this.ModelView.Refresh(); // Refresh the view to update the node display if necessary
                }
            }

            this.modelView.OnDocumentOpening(new DocumentEventArgs(new Document("things")));
        }

        private static void newJavaDiagram_Click(object sender, EventArgs e)
        {
            //ToolStripItem menuItem = (ToolStripItem) sender;
            //Project project = ((ProjectNode) menuItem.OwnerItem.Owner.Tag).Project;

            //IDiagram diagram = new ClassDiagram(JavaLanguage.Instance);
            //Settings.Default.DefaultLanguageName = JavaLanguage.Instance.AssemblyName;
            //project.Add(diagram);
        }

        private static void newUseCaseDiagram_Click(object sender, EventArgs e)
        {
            //ToolStripItem menuItem = (ToolStripItem)sender;
            //Project project = ((ProjectNode)menuItem.OwnerItem.Owner.Tag).Project;

            //IDiagram diagram = new UseCaseDiagram();
            //project.Add(diagram);
        }

        private static void rename_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            ProjectNode node = (ProjectNode) menuItem.Owner.Tag;

            node.EditLabel();
        }

        private static void save_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            Project project = ((ProjectNode) menuItem.Owner.Tag).Project;

            //Workspace.Default.SaveProject(project);
        }

        private static void saveAs_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            Project project = ((ProjectNode) menuItem.Owner.Tag).Project;

            //Workspace.Default.SaveProjectAs(project);
        }

        private static void close_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = (ToolStripItem) sender;
            Project project = ((ProjectNode) menuItem.Owner.Tag).Project;

            //sWorkspace.Default.RemoveProject(project);
        }
    }
}
