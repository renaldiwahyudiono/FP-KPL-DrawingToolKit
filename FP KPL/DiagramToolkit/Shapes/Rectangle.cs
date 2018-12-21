﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiagramToolkit.Shapes
{
    public class Rectangles : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private List<DrawingObject> drawingObjects;

        public Rectangles()
        {
            this.pen = new Pen(Color.Black);
            this.brush = Brushes.OrangeRed;
            this. pen.Width = 1.5f;
            drawingObjects = new List<DrawingObject>();
        }

        public Rectangles(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangles(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().FillRectangle(this.brush, X, Y, Width, Height);
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnStaticView();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().FillRectangle(this.brush, X, Y, Width, Height);
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
            }

        }

        public override void RenderOnPreview()
        {
            this.pen.DashStyle = DashStyle.DashDot;
            GetGraphics().FillRectangle(this.brush, X, Y, Width, Height);
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnPreview();
            }
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;

            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Translate(x, y, xAmount, yAmount);
            }
        }

        public override bool Add(DrawingObject obj)
        {
            drawingObjects.Add(obj);

            return true;
        }

        public override bool Remove(DrawingObject obj)
        {
            drawingObjects.Remove(obj);

            return true;
        }
    }
}
