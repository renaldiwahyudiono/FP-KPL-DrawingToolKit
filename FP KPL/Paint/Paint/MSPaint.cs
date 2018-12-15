using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    /*myPaint Class*/
    public partial class myPaint : Form
    {
        /*Variable*/
        /*Start position of mouse on the canvas*/
        private int mouseStartX = 0;
        private int mouseStartY = 0;
        /*Current position of the mouse on the canvas*/
        private int mouseCurrentX = 0;
        private int mouseCurrentY = 0;
        /*Start position of rectangle on the canvas*/
        private int recStartPositionX = 0;
        private int recStartPositionY = 0;
        /*Size of the rectangle on the canvas*/
        private int recSizeX = 0;
        private int recSizeY = 0;
        /*Check if mouse is down*/
        private bool mouseDown = false;
        /*Bitmap objec*/
        private Bitmap bm;
        /*Determine what shape is selected*/
        private int shapeSelected = 0;
        /*Color of the line of the shape*/
        private Color linePaintColor;
        /*Color of the fill line of the shape*/
        private Color lineFillPaintColor;

        /*Initialize the components for the paint application*/
        public myPaint()
        {
            InitializeComponent();
            bm = new Bitmap(Paint_Canvas.Width, Paint_Canvas.Height);
            /*The default color can be any color of choice*/
            linePaintColor = Color.Black;
            lineFillPaintColor = Color.Violet;
        }

        /*This is the canvas paint area for the shapes*/
        private void Paint_Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics msPaint = e.Graphics;
            if (mouseDown == true)
            {
                /*Set the thickness of the line or boarder of the shapes*/
                Pen size = new Pen(linePaintColor, float.Parse(lineSize.Text));
                if (shapeSelected == 1)
                {
                    /*Draw line*/
                    msPaint.DrawLine(size, new Point(mouseStartX, mouseStartY), new Point(mouseCurrentX + mouseStartX, mouseCurrentY + mouseStartY));
                }
                else if (shapeSelected == 2)
                {
                    /*Draws ellipse border*/
                    msPaint.DrawEllipse(size, mouseStartX, mouseStartY, mouseCurrentX, mouseCurrentY);
                }
                else if (shapeSelected == 3)
                {
                    /*Draws rectangle*/
                    msPaint.DrawRectangle(size, recStartPositionX, recStartPositionY, recSizeX, recSizeY);
                }
            }
            /*Paint to bitmap*/
            msPaint.DrawImage(bm, new Point(0, 0));
            /*End of canvas block*/
        }

        /*This section determin what happens when the mouse is up*/
        private void Paint_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*This is the size of the line of the border of the shaoe*/
                Pen size = new Pen(linePaintColor, float.Parse(lineSize.Text));

                mouseDown = false;
                Graphics msPaint = Graphics.FromImage(bm);

                if (shapeSelected == 1)
                {
                    /*This syntax draws the line*/
                    msPaint.DrawLine(size, new Point(mouseStartX, mouseStartY), new Point(mouseCurrentX + mouseStartX, mouseCurrentY + mouseStartY));
                }
                else if (shapeSelected == 2)
                {
                    /*This syntax draws the ellipse*/
                    msPaint.DrawEllipse(size, mouseStartX, mouseStartY, mouseCurrentX, mouseCurrentY);
                    msPaint.FillEllipse(new SolidBrush(lineFillPaintColor), mouseStartX, mouseStartY, mouseCurrentX, mouseCurrentY);
                }
                else if (shapeSelected == 3)
                {
                    /*This syntax draws the ellipse*/
                    msPaint.DrawRectangle(size, recStartPositionX, recStartPositionY, recSizeX, recSizeY);
                    msPaint.FillRectangle(new SolidBrush(lineFillPaintColor), recStartPositionX, recStartPositionY, recSizeX, recSizeY);
                }
            }
        }

        private void Paint_Canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
