using NModel.Visualization;

namespace Overwatch.Winforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            NModel.Visualization.ModelProgramGraphViewer viewer = new ModelProgramGraphViewer();
        }
    }
}
