using DiagramToolkit.Shapes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class RedBorderColor : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObj;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public RedBorderColor()
        {
            this.Name = "Red Border Color";
            this.ToolTipText = "Red Border Color";
            this.Image = IconSet.Artboard_1_copy_8;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedObj = canvas.GetObjectAt(e.X, e.Y);
                if (selectedObj is Rectangles)
                {
                    selectedObj.pen.Color = Color.Red;
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
