using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NModel.Visualization;
using Overwatch.Winforms.Net48.Properties;

namespace Overwatch.Winforms.Net48
{
    public partial class Canvas: UserControl
    {
        ModelProgramGraphView mpgv;
        private IDocument document;
        public Canvas()
        {
            InitializeComponent();
            mpgv = new ModelProgramGraphView();
            mpgv.Dock = DockStyle.Fill;
            mpgv.Visible = false;
            this.Controls.Add(mpgv);
        }

        public IDocument Document
        {
            get { return document; }

            set {

                document = value;
                LoadModelProgram();
            }
        }

        private void LoadModelProgram()
        {
            if (document != null)
            {
                //mpgv.ModelProgram = document.ModelProgram;
                //mpgv.AcceptingStatesMarked = settings.acceptingStatesMarked;
                //mpgv.TransitionLabels = settings.transitionLabels;
                //mpgv.CombineActions = settings.combineActions;
                //mpgv.Direction = settings.direction;
                //mpgv.UnsafeStateColor = Color.FromName(settings.unsafeStateColor);
                //mpgv.HoverColor = Color.FromName(settings.hoverColor);
                //mpgv.InitialStateColor = Color.FromName(settings.initialStateColor);
                //mpgv.LoopsVisible = settings.loopsVisible;
                //mpgv.MaxTransitions = settings.maxTransitions;
                //mpgv.NodeLabelsVisible = settings.nodeLabelsVisible;
                //mpgv.SelectionColor = Color.FromName(settings.selectionColor);
                //mpgv.MergeLabels = settings.mergeLabels;
                //mpgv.StateShape = settings.stateShape;
                //mpgv.DeadStateColor = Color.FromName(settings.deadStateColor);
                //mpgv.InitialTransitions = settings.initialTransitions;
                //mpgv.LivenessCheckIsOn = settings.livenessCheckIsOn;
                //mpgv.ExcludeIsomorphicStates = settings.excludeIsomorphicStates;
                //mpgv.SafetyCheckIsOn = settings.safetyCheckIsOn;
                //mpgv.DeadstatesVisible = settings.deadStatesVisible;
                //mpgv.StateViewVisible = settings.stateViewVisible;

                //show the view of the product of all the model programs
                mpgv.SetModelProgram(document.ProductModelProgram);

                mpgv.Visible = true;
            }
            else
            {
                mpgv.Visible = false;
            }
        }

    }
}
