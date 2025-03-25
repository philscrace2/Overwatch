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
    public partial class TabBar: UserControl
    {
        public TabBar()
        {
            InitializeComponent();
        }

        public DocumentManager DocumentManager { get; internal set; }
    }
}
