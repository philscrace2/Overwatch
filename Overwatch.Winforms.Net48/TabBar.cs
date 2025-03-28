using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Overwatch.Winforms.Net48.Properties;
using static DevExpress.Utils.HashCodeHelper.Primitives;
using System.IO;

namespace Overwatch.Winforms.Net48
{
    public partial class TabBar: Control
    {
        private class Tab
        {
            const int MinWidth = 60;
            const int TextMargin = 20;
            public const int IconMargin = 20;

            readonly TabBar parent;
            string text;
            float textWidth;

            public Tab(IDocument document, TabBar parent)
            {
                this.Document = document;
                this.parent = parent;
                document.Renamed += document_Renamed;
                text = document.Name;
                textWidth = MeasureWidth(text);
            }

            private void document_Renamed(object sender, EventArgs e)
            {
                Text = Document.Name;
            }

            public IDocument Document { get; }

            public string Text
            {
                get => text;
                private set
                {
                    if (text == value) return;

                    text = value;
                    textWidth = MeasureWidth(text);
                    parent.Invalidate();
                }
            }

            public float TextWidth => textWidth;
            public int Width => Math.Max(MinWidth, (int)TextWidth + TextMargin + IconMargin);
            public bool IsActive => (Document == parent.docManager.ActiveDocument);

            public void Detached()
            {
                Document.Renamed -= document_Renamed;
            }

            private float MeasureWidth(string textToMeasure)
            {
                var g = parent.CreateGraphics();

                var textSize = g.MeasureString(textToMeasure, parent.activeTabFont,
                    parent.MaxTabWidth, parent.stringFormat);
                g.Dispose();

                return textSize.Width;
            }

            public override string ToString()
            {
                return text;
            }

            public Rectangle Bounds { get; private set; }

            public bool IsClosingSignActive { get; private set; }

            public void Draw(Graphics g, Rectangle tabRectangle, Brush activeTabBrush, Brush inactiveTabBrush,
                Pen borderPen, Brush textBrush, StringFormat stringFormat, Font activeTabFont, Font inactiveTabFont)
            {
                var top = (this.IsActive ? TopMargin : TopMargin + 2);

                var margin = (tabRectangle.Height - ClosingSignSize) / 2;
                var closingSignLeft = tabRectangle.Left + tabRectangle.Width - 4 - ClosingSignSize;
                var tabBrush = (this.IsActive ? activeTabBrush : inactiveTabBrush);
                var imageRectangle = new Rectangle(tabRectangle.Left + 2, top + 2, 16, 16);
                var tabTextRectangle = new Rectangle(tabRectangle.Left + Tab.IconMargin, top, closingSignLeft - tabRectangle.Left - IconMargin, tabRectangle.Height);
                var icon = Resources.Open;

                // To display bottom line for inactive tabs
                if (!IsActive)
                {
                    tabRectangle.Height--;
                    tabTextRectangle.Height--;
                    imageRectangle.Height--;
                }

                this.Bounds = tabRectangle;

                g.FillRectangle(tabBrush, tabRectangle); // Draw background
                g.DrawRectangle(borderPen, tabRectangle); // Draw border

                var font = (IsActive) ? activeTabFont : inactiveTabFont;

                MemoryStream ms  = new MemoryStream(icon);
                Bitmap bitmap = new Bitmap(ms);
                g.DrawImage(bitmap, imageRectangle);
                g.DrawString(Text, font, textBrush, tabTextRectangle, stringFormat);

                Color lineColor = IsClosingSignActive ? SystemColors.ControlText : SystemColors.ControlDark;
                Pen linePen = new Pen(lineColor, 2);

                g.DrawLine(linePen, closingSignLeft, tabRectangle.Top + margin, closingSignLeft + ClosingSignSize, tabRectangle.Top + margin + ClosingSignSize);
                g.DrawLine(linePen, closingSignLeft, tabRectangle.Top + margin + ClosingSignSize, closingSignLeft + ClosingSignSize, tabRectangle.Top + margin);
                linePen.Dispose();
            }

            private bool IsOverClosingSign(Point location)
            {
                var margin = (Bounds.Height - ClosingSignSize) / 2;
                int closingSignLeft = Bounds.Left + Bounds.Width - 4 - ClosingSignSize;

                return (
                    location.X >= closingSignLeft && location.X <= closingSignLeft + ClosingSignSize &&
                    location.Y >= margin && location.Y <= margin + ClosingSignSize
                );
            }

            public void OnMouseMove(MouseEventArgs args)
            {
                IsClosingSignActive = IsOverClosingSign(args.Location);
                this.parent.Invalidate(Bounds);
            }
        }


        DocumentManager docManager = null;
        private readonly List<Tab> tabs = new List<Tab>();
        private Tab activeTab = null;
        private Tab grabbedTab = null;
        private int originalPosition = 0;
        private bool activeCloseButton = false;

        private readonly StringFormat stringFormat;
        private Font activeTabFont;
        private int maxTabWidth = 200;

        const int LeftMargin = 3;
        const int TopMargin = 3;
        const int ClosingSignSize = 8;
        public TabBar()
        {
            InitializeComponent();
        }

        public DocumentManager DocumentManager { get; internal set; }


        [DefaultValue(typeof(Color), "Control")]
        public override Color BackColor
        {
            get
            {
                if (Parent != null && !DesignMode &&
                    (docManager == null || !docManager.HasDocument))
                {
                    return Parent.BackColor;
                }
                else
                {
                    return base.BackColor;
                }
            }
            set => base.BackColor = value;
        }

        [DefaultValue(typeof(Color), "ControlDark")]
        public Color BorderColor { get; set; } = SystemColors.ControlDark;

        [DefaultValue(typeof(Color), "White")]
        public Color ActiveTabColor { get; set; } = Color.White;

        [DefaultValue(typeof(Color), "ControlLight")]
        public Color InactiveTabColor { get; set; } = SystemColors.ControlLight;


        [DefaultValue(200)]
        public int MaxTabWidth
        {
            get => maxTabWidth;
            set
            {
                maxTabWidth = value;
                if (maxTabWidth < 50)
                    maxTabWidth = 50;
            }
        }
    }
}
