namespace Overwatch.Winforms.Net48
{
    public delegate void PopupWindowEventHandler(object sender, PopupWindowEventArgs e);

    public class PopupWindowEventArgs
    {
        PopupWindow window;

        public PopupWindowEventArgs(PopupWindow window)
        {
            this.window = window;
        }

        public PopupWindow Window
        {
            get { return window; }
        }
    }
}