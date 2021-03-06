using System.Windows.Forms;

namespace GrafPack
{
    public class DoubleBufferedPanel : Panel
    {
        //https://gregback.net/double-buffered-panels-in-c.html
        public DoubleBufferedPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint, true);
        }
    }
}
