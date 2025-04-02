using DevExpress.XtraPrinting;
using NModel.Algorithms;
using NModel;
using NModel.Execution;
using Overwatch.Winforms.Net48.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Overwatch.Winforms.Net48
{
    public class NModelDiagram : IDiagram
    {
        ProductModelProgram mp;
        public NModelDiagram()
        {
            this.Project = new Project();
            this.Name = "Add Model Program";
            this.IsUntitled = true;
        }
        public string Name { get; set; }
        public Point Offset { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Size Size => throw new NotImplementedException();

        public float Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Color BackColor => throw new NotImplementedException();

        public bool HasSelectedElement => throw new NotImplementedException();

        public Project Project { get; set; }

        public bool IsUntitled {get;set; }

        public Model Model => throw new NotImplementedException();

        public bool IsDirty => throw new NotImplementedException();

        public bool RaiseChangedEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UserControl PropertyEditorControl => throw new NotImplementedException();

        public bool CreatesIntersectedBricks => throw new NotImplementedException();

        public ProductModelProgram ProductModelProgram
        {
            get {
                return mp;
                //FSM fa = FsmTraversals.GenerateTestSequenceAutomaton(
                //    settings.startTestAction, testcases, GetActionSymbols(testcases));
                //ModelProgram famp = new FsmModelProgram(fa, settings.testSuite);
                //if (mp == null)
                //    mp = famp;
                //else
                //    mp = new ProductModelProgram(mp, famp);


            }

        }

        public event EventHandler OffsetChanged;
        public event EventHandler SizeChanged;
        public event EventHandler ZoomChanged;
        public event EventHandler StatusChanged;
        public event EventHandler NeedsRedraw;
        public event PopupWindowEventHandler ShowingWindow;
        public event PopupWindowEventHandler HidingWindow;
        public event EventHandler Renamed;
        public event EventHandler Closing;
        public event ModifiedEventHandler Modified;

        public void AcceptChanges()
        {
            throw new NotImplementedException();
        }

        public void Clean()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void CloseWindows()
        {
            throw new NotImplementedException();
        }

        public void CreateArea(string areaName, BrickGraphics brickGraphics)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public void Display(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void DoubleClick(AbsoluteMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Finalize(PrintingSystemBase ps, LinkBase link)
        {
            throw new NotImplementedException();
        }

        public ContextMenuStrip GetContextMenu(AbsoluteMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public ContextMenu GetContextMenu()
        {
            throw new NotImplementedException();
        }

        public DynamicMenu GetDynamicMenu()
        {
            throw new NotImplementedException();
        }

        public string GetSelectedElementName()
        {
            throw new NotImplementedException();
        }

        public string GetShortDescription()
        {
            throw new NotImplementedException();
        }

        public string GetStatus()
        {
            throw new NotImplementedException();
        }

        public bool HasPropertyEditor()
        {
            throw new NotImplementedException();
        }

        public void Initialize(PrintingSystemBase ps, LinkBase link)
        {
            throw new NotImplementedException();
        }

        public void KeyDown(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseDown(AbsoluteMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseMove(AbsoluteMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseUp(AbsoluteMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Redraw()
        {
            throw new NotImplementedException();
        }

        public void RejectChanges()
        {
            throw new NotImplementedException();
        }

        public void Serialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public void ShowHelp()
        {
            throw new NotImplementedException();
        }

        public bool SupportsHelp()
        {
            throw new NotImplementedException();
        }
    }
}
