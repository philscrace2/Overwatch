using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overwatch.Winforms.Net48
{
    public partial class Canvas: UserControl
    {
        public Canvas()
        {
            InitializeComponent();
        }

        public object Document { get; internal set; }
    }
}
