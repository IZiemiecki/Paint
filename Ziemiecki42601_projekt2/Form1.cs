using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;

namespace Ziemiecki_42601_projekt7
{



    public partial class Form1 : Form
    {
        static Graphics iz_Rysownica;
        static Color iz_BackColor;
        Graphics iz_Rysownica_temp;
        Point iz_Punkt = Point.Empty;
        Pen iz_penPioro;
        SolidBrush iz_drawBrush = new SolidBrush(Color.Black);
        Brush iz_brushPedzel = Brushes.Brown;
        Random iz_Random = new Random();
        List<iz_Point> iz_PointList = new List<iz_Point>();
        static int iz_RandomDistracter; // podobnie jak ostatnio potrzebuje poprawki do RNG

        public Form1()
        {
            InitializeComponent();
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            this.MaximizeBox = false;
            iz_penPioro = new Pen(iz_lblKolorPdst.BackColor, 1);

            iz_rbOlowek.Checked = true;
            iz_imgRysownica.BackColor = iz_lblKolorTla.BackColor = Color.White;
            iz_lblKolorPdst.BackColor = iz_penPioro.Color = iz_lblKolorWypel.BackColor = Color.Black;
            iz_imgRysownica.BorderStyle = BorderStyle.Fixed3D;
            iz_imgRysownica.Image = new Bitmap(iz_imgRysownica.Width, iz_imgRysownica.Height);
            iz_Rysownica = Graphics.FromImage(iz_imgRysownica.Image);
            iz_BackColor = iz_lblKolorTla.BackColor;
            iz_Rysownica_temp = iz_imgRysownica.CreateGraphics();
            iz_cmbStylLinii.SelectedIndex = 4;
            iz_lblKolorWypel.BackColor = Color.Brown;
            iz_penPioro.EndCap = LineCap.Round;
            iz_penPioro.StartCap = LineCap.Round;


        }
        private DashStyle iz_WybranyStylLinii(int iz_i)
        {
            switch (iz_i)
            {
                case 0:
                    return System.Drawing.Drawing2D.DashStyle.Dash;
                case 1:
                    return System.Drawing.Drawing2D.DashStyle.DashDot;
                case 2:
                    return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                case 3:
                    return System.Drawing.Drawing2D.DashStyle.Dot;
                case 4:
                    return System.Drawing.Drawing2D.DashStyle.Solid;
                default:
                    MessageBox.Show("ERROR: Nie ma takiego rodzaju linii!");
                    return System.Drawing.Drawing2D.DashStyle.Solid;
            }

        }
        public enum TYPEID : uint  // bez iz_ gdyz iz_ uzywam w klasach
        {
            POINT = 0,
            CIRCLE = 1,
            FILLED_CIRCLE = 2,
            ELLIPSE = 3,
            FILLED_ELLIPSE = 4,
            SQUARE = 5,
            FILLED_SQUARE = 6,
            RECTANGLE = 7,
            FILLED_RECTANGLE = 8,
            LINE = 9,
            DRAWING = 10
        };


        /*
         * 
         * start klas
         * 
         * */
        public class iz_Point
        {
            public bool iz_Visible = false;
            public int iz_X = 0, iz_Y = 0;
            public TYPEID iz_typeid = TYPEID.POINT;
            public iz_Point() { }
            public iz_Point(int iz_x, int iz_y)
            {
                iz_X = iz_x;
                iz_Y = iz_y;
            }

            public virtual void iz_SetPosition(int iz_x, int iz_y)
            {
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public virtual void iz_Move(int iz_x, int iz_y)
            {
                iz_SetPosition(iz_x, iz_y);
            }
            public virtual void iz_Draw() { iz_Visible = true; }
            public virtual void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2) { iz_Visible = true; }
            public virtual void iz_Remove() { iz_Visible = true; }

        }

        public class iz_Circle : iz_Point
        {
            public int iz_Radius = 10;
            public Pen iz_Pen = new Pen(Color.Black, 1);
            public iz_Circle() { iz_typeid = TYPEID.CIRCLE; }
            public iz_Circle(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Circle(int iz_x, int iz_y, Pen iz_pen)
            {
                iz_typeid = TYPEID.CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }
            public iz_Circle(int iz_x, int iz_y, int iz_radius, Pen iz_pen)
            {
                iz_typeid = TYPEID.CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Radius = iz_radius;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }



            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Radius = (int)Math.Abs(iz_ObliczOdleglosc(iz_x2, iz_y2, iz_x, iz_y));

                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x - iz_Radius;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y - iz_Radius;

                iz_Rysownica.DrawEllipse(iz_Pen, (iz_x2 > iz_x) ? iz_x : iz_x - iz_Radius,
                             (iz_y2 > iz_y) ? iz_y : iz_y - iz_Radius,
                             iz_Radius,
                             iz_Radius);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Radius, iz_Radius);
            }

            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Pen.DashStyle = DashStyle.Solid;
                iz_Draw();
            }

        }

        public class iz_FilledCircle : iz_Circle
        {
            public Brush iz_Brush = new SolidBrush(Color.Black);

            public iz_FilledCircle() { iz_typeid = TYPEID.FILLED_CIRCLE; }

            public iz_FilledCircle(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.FILLED_CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_FilledCircle(int iz_x, int iz_y, Brush iz_brush)
            {

                iz_typeid = TYPEID.FILLED_CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }
            public iz_FilledCircle(int iz_x, int iz_y, int iz_radius, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_CIRCLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Radius = iz_radius;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }

            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Radius = (int)Math.Abs(iz_ObliczOdleglosc(iz_x2, iz_y2, iz_x, iz_y));

                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x - iz_Radius;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y - iz_Radius;
                iz_Rysownica.FillEllipse(iz_Brush, (iz_x2 > iz_x) ? iz_x : iz_x - iz_Radius,
                              (iz_y2 > iz_y) ? iz_y : iz_y - iz_Radius,
                              iz_Radius,
                              iz_Radius);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.FillEllipse(iz_Brush, iz_X, iz_Y, iz_Radius, iz_Radius);
            }

            public override void iz_Remove()
            {
                iz_Brush = new SolidBrush(iz_BackColor);
                iz_Draw();
            }
        }

        public class iz_Ellipse : iz_Circle
        {
            public int iz_Radius2 = 15;
            public iz_Ellipse() { iz_typeid = TYPEID.ELLIPSE; }
            public iz_Ellipse(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Ellipse(int iz_x, int iz_y, Pen iz_pen)
            {
                iz_typeid = TYPEID.ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }
            public iz_Ellipse(int iz_x, int iz_y, int iz_height, int iz_width, Pen iz_pen)
            {
                iz_typeid = TYPEID.ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Radius = iz_height;
                iz_Radius2 = iz_width;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }


            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Radius2 = Math.Abs(iz_x - iz_x2);
                iz_Radius = Math.Abs(iz_y - iz_y2);
                iz_X = (iz_x < iz_x2) ? iz_x : iz_x2;
                iz_Y = (iz_y < iz_y2) ? iz_y : iz_y2;

                iz_Rysownica.DrawEllipse(iz_Pen, iz_x, iz_y, iz_x2 - iz_x, iz_y2 - iz_y);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.DrawEllipse(iz_Pen, iz_X, iz_Y, iz_Radius2, iz_Radius);
            }

            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Pen.DashStyle = DashStyle.Solid;
                iz_Draw();
            }

        }
        public class iz_FilledEllipse : iz_Ellipse
        {
            public Brush iz_Brush = new SolidBrush(Color.Black);
            public iz_FilledEllipse() { iz_typeid = TYPEID.FILLED_ELLIPSE; }
            public iz_FilledEllipse(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.FILLED_ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_FilledEllipse(int iz_x, int iz_y, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }
            public iz_FilledEllipse(int iz_x, int iz_y, int iz_height, int iz_width, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_ELLIPSE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Radius = iz_height;
                iz_Radius2 = iz_width;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }


            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Radius2 = Math.Abs(iz_x - iz_x2);
                iz_Radius = Math.Abs(iz_y - iz_y2);
                iz_X = (iz_x < iz_x2) ? iz_x : iz_x2;
                iz_Y = (iz_y < iz_y2) ? iz_y : iz_y2;

                iz_Rysownica.FillEllipse(iz_Brush, iz_x, iz_y, iz_x2 - iz_x, iz_y2 - iz_y);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.FillEllipse(iz_Brush, iz_X, iz_Y, iz_Radius2, iz_Radius);
            }

            public override void iz_Remove()
            {
                iz_Brush = new SolidBrush(iz_BackColor);
                iz_Draw();
            }

        }

        public class iz_Square : iz_Point
        {
            public int iz_Dlugosc = 10;
            public Pen iz_Pen = new Pen(Color.Black, 1);
            public iz_Square() { iz_typeid = TYPEID.SQUARE; }
            public iz_Square(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Square(int iz_x, int iz_y, Pen iz_pen)
            {
                iz_typeid = TYPEID.SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }
            public iz_Square(int iz_x, int iz_y, int iz_dlugosc, Pen iz_pen)
            {
                iz_typeid = TYPEID.SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Dlugosc = iz_dlugosc;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }



            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Dlugosc = (int)Math.Abs(iz_ObliczOdleglosc(iz_x2, iz_y2, iz_x, iz_y));

                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x - iz_Dlugosc;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y - iz_Dlugosc;

                iz_Rysownica.DrawRectangle(iz_Pen, (iz_x2 > iz_x) ? iz_x : iz_x - iz_Dlugosc,
                             (iz_y2 > iz_y) ? iz_y : iz_y - iz_Dlugosc,
                             iz_Dlugosc,
                             iz_Dlugosc);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Dlugosc, iz_Dlugosc);
            }

            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Pen.DashStyle = DashStyle.Solid;
                iz_Draw();
            }

        }

        public class iz_FilledSquare : iz_Square
        {
            public Brush iz_Brush = new SolidBrush(Color.Black);
            public iz_FilledSquare() { iz_typeid = TYPEID.FILLED_SQUARE; }
            public iz_FilledSquare(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.FILLED_SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_FilledSquare(int iz_x, int iz_y, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }
            public iz_FilledSquare(int iz_x, int iz_y, int iz_dlugosc, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_SQUARE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Dlugosc = iz_dlugosc;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }



            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_Dlugosc = (int)Math.Abs(iz_ObliczOdleglosc(iz_x2, iz_y2, iz_x, iz_y));

                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x - iz_Dlugosc;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y - iz_Dlugosc;

                iz_Rysownica.FillRectangle(iz_Brush, (iz_x2 > iz_x) ? iz_x : iz_x - iz_Dlugosc,
                             (iz_y2 > iz_y) ? iz_y : iz_y - iz_Dlugosc,
                             iz_Dlugosc,
                             iz_Dlugosc);


            }
            public override void iz_Draw()
            {
                iz_Rysownica.FillRectangle(iz_Brush, iz_X, iz_Y, iz_Dlugosc, iz_Dlugosc);
            }

            public override void iz_Remove()
            {
                iz_Brush.Dispose();
                iz_Brush = new SolidBrush(iz_BackColor);
                iz_Draw();
            }

        }
        public class iz_Rectangle : iz_Square
        {
            public int iz_Szerokosc = 10;
            public iz_Rectangle() { iz_typeid = TYPEID.RECTANGLE; }
            public iz_Rectangle(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Rectangle(int iz_x, int iz_y, Pen iz_pen)
            {
                iz_typeid = TYPEID.RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }
            public iz_Rectangle(int iz_x, int iz_y, int iz_dlugosc, int iz_szerokosc, Pen iz_pen)
            {
                iz_typeid = TYPEID.RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Dlugosc = iz_dlugosc;
                iz_Szerokosc = iz_szerokosc;
                iz_Pen.Dispose();
                iz_Pen = (Pen)iz_pen.Clone();
            }



            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x2;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y2;
                iz_Dlugosc = Math.Abs(iz_X - ((iz_x2 < iz_x) ? iz_x : iz_x2));
                iz_Szerokosc = Math.Abs(iz_Y - ((iz_y2 < iz_y) ? iz_y : iz_y2));


                iz_Rysownica.DrawRectangle(iz_Pen, (iz_x2 > iz_x) ? iz_x : iz_x2, (iz_y2 > iz_y) ? iz_y : iz_y2,
                           ((iz_x2 > iz_x) ? iz_x2 : iz_x) - ((iz_x2 > iz_x) ? iz_x : iz_x2),
                           ((iz_y2 > iz_y) ? iz_y2 : iz_y) - ((iz_y2 > iz_y) ? iz_y : iz_y2));


            }
            public override void iz_Draw()
            {
                iz_Rysownica.DrawRectangle(iz_Pen, iz_X, iz_Y, iz_Dlugosc, iz_Szerokosc);
            }

            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Pen.DashStyle = DashStyle.Solid;
                iz_Draw();
            }

        }
        public class iz_FilledRectangle : iz_Rectangle
        {
            public Brush iz_Brush = new SolidBrush(Color.Black);
            public iz_FilledRectangle() { iz_typeid = TYPEID.FILLED_RECTANGLE; }
            public iz_FilledRectangle(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.FILLED_RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_FilledRectangle(int iz_x, int iz_y, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }
            public iz_FilledRectangle(int iz_x, int iz_y, int iz_dlugosc, int iz_szerokosc, Brush iz_brush)
            {
                iz_typeid = TYPEID.FILLED_RECTANGLE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Dlugosc = iz_dlugosc;
                iz_Szerokosc = iz_szerokosc;
                iz_Brush.Dispose();
                iz_Brush = (Brush)iz_brush.Clone();
            }



            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_X = (iz_x2 > iz_x) ? iz_x : iz_x2;
                iz_Y = (iz_y2 > iz_y) ? iz_y : iz_y2;
                iz_Dlugosc = Math.Abs(iz_X - ((iz_x2 < iz_x) ? iz_x : iz_x2));
                iz_Szerokosc = Math.Abs(iz_Y - ((iz_y2 < iz_y) ? iz_y : iz_y2));


                iz_Rysownica.FillRectangle(iz_Brush, (iz_x2 > iz_x) ? iz_x : iz_x2, (iz_y2 > iz_y) ? iz_y : iz_y2,
                           ((iz_x2 > iz_x) ? iz_x2 : iz_x) - ((iz_x2 > iz_x) ? iz_x : iz_x2),
                           ((iz_y2 > iz_y) ? iz_y2 : iz_y) - ((iz_y2 > iz_y) ? iz_y : iz_y2));


            }
            public override void iz_Draw()
            {
                iz_Rysownica.FillRectangle(iz_Brush, iz_X, iz_Y, iz_Dlugosc, iz_Szerokosc);
            }

            public override void iz_Remove()
            {
                iz_Brush.Dispose();
                iz_Brush = new SolidBrush(iz_BackColor);
                iz_Draw();
            }

        }

        public class iz_Line : iz_Point
        {
            public int iz_X2 = 0, iz_Y2 = 0;
            public Pen iz_Pen = new Pen(Color.Black, 1);

            public iz_Line() { iz_typeid = TYPEID.LINE; }
            public iz_Line(int iz_x, int iz_y)
            {
                iz_typeid = TYPEID.LINE;
                iz_X = iz_x;
                iz_Y = iz_y;
            }
            public iz_Line(int iz_x, int iz_y, Pen iz_pen)
            {
                iz_typeid = TYPEID.LINE;
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_Pen = (Pen)iz_pen.Clone();
            }

            public override void iz_Move(int iz_x, int iz_y)
            {
                int iz_temp = iz_X - iz_x;
                iz_X2 -= iz_temp;
                iz_temp = iz_Y - iz_y;
                iz_Y2 -= iz_temp;
                base.iz_Move(iz_x, iz_y);

            }
            public override void iz_Draw()
            {
                iz_Rysownica.DrawLine(iz_Pen, iz_X, iz_Y, iz_X2, iz_Y2);
            }
            public override void iz_Draw(int iz_x, int iz_y, int iz_x2, int iz_y2)
            {
                iz_X = iz_x;
                iz_Y = iz_y;
                iz_X2 = iz_x2;
                iz_Y2 = iz_y2;
                iz_Rysownica.DrawLine(iz_Pen, iz_x, iz_y, iz_x2, iz_y2);
            }
            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Draw();
            }
        }

        public class iz_Drawing : iz_Point // iz_Point bo z linii niekoniecznie potrzebuje punktu finiszu
        {
            public List<Point> iz_Points = new List<Point>();
            public Pen iz_Pen = new Pen(Color.Black, 1);

            public iz_Drawing() { iz_typeid = TYPEID.DRAWING; }
            public iz_Drawing(Pen iz_pen, Point iz_point)
            {
                iz_Pen = (Pen)iz_pen.Clone();
                iz_typeid = TYPEID.DRAWING;
                iz_AddPoint(iz_point);
            }
            public iz_Drawing(Point iz_point)
            {
                iz_typeid = TYPEID.DRAWING;
                iz_AddPoint(iz_point);
            }

            public void iz_AddPoint(Point iz_point)
            {
                iz_Points.Add(iz_point);
            }

            public override void iz_Move(int iz_x, int iz_y)
            {

                if (iz_Points.Count < 1)
                    return;


                int iz_tempX = iz_Points[0].X - iz_x;
                int iz_tempY = iz_Points[0].Y - iz_y;        // o ile się przesuwają X i Y

                for (int i = 0; i < iz_Points.Count; i++)
                    iz_Points[i] = new Point(iz_Points[i].X - iz_tempX, iz_Points[i].Y - iz_tempY); // kazdy punkt jest nadpisany nowym, z uwzglednieciem przesuniecia



            }
            public override void iz_Draw()
            {
                Point[] iz_PointTable = new Point[iz_Points.Count];
                for (int i = 0; i < iz_Points.Count; i++)
                    iz_PointTable[i] = iz_Points[i];

                iz_Rysownica.DrawLines(iz_Pen, iz_PointTable);
            }
            public override void iz_Remove()
            {
                iz_Pen.Color = iz_BackColor;
                iz_Draw();
            }

        }

        /*
         * 
         * 
         * koniec klas
         * 
         * 
         */




        static float iz_ObliczOdleglosc(int x, int y, int x2, int y2)
        {
            return (float)Math.Sqrt((double)Math.Pow(x2 - x, 2) + Math.Pow(y2 - y, 2));
        }

        private void iz_imgRysownica_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
                iz_Punkt = e.Location;
                if (iz_rbOlowek.Checked)
                {
                    iz_PointList.Add(new iz_Drawing(iz_penPioro, iz_Punkt));

                }
            }
        }

        private void iz_imgRysownica_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (iz_rbOlowek.Checked)
                {

                    ((iz_Drawing)(iz_PointList[iz_PointList.Count - 1])).iz_AddPoint(e.Location);
                    iz_Rysownica.DrawLine(iz_penPioro, iz_Punkt, e.Location); //rysuje od razu, nie ma potrzeby co milisekunde wywolywac wymazywania i mazania od poczatku obiektu, i tak bedzie identyczny
                    iz_Punkt = e.Location;
                }
                if (iz_rdbOkrąg.Checked)
                {
                    if (iz_chbWypelnij.CheckState == CheckState.Checked)
                    {
                        iz_PointList.Add(new iz_FilledCircle(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_brushPedzel)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);


                    }
                    else
                    {
                        iz_PointList.Add(new iz_Circle(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_penPioro)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }

                    iz_imgRysownica.Refresh();
                }

                if (iz_rdbElipsa.Checked)
                {
                    if (iz_chbWypelnij.CheckState == CheckState.Checked)
                    {
                        iz_PointList.Add(new iz_FilledEllipse(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_brushPedzel)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    else
                    {
                        iz_PointList.Add(new iz_Ellipse(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_penPioro)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    iz_imgRysownica.Refresh();

                }
                if (iz_rdbKwadrat.Checked)
                {
                    if (iz_chbWypelnij.CheckState == CheckState.Checked)
                    {
                        iz_PointList.Add(new iz_FilledSquare(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_brushPedzel)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    else
                    {
                        iz_PointList.Add(new iz_Square(
                                        (int)((e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))),  // iz_X
                                        (int)((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y))), // iz_Y
                                        iz_penPioro)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    iz_imgRysownica.Refresh();

                }
                if (iz_rdbProstokąt.Checked)
                {
                    if (iz_chbWypelnij.CheckState == CheckState.Checked)
                    {
                        iz_PointList.Add(new iz_FilledRectangle(
                                        (e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X,  // iz_X
                                        (e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y, // iz_Y
                                        iz_brushPedzel)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    else
                    {

                        iz_PointList.Add(new iz_Rectangle(
                                        (e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X,  // iz_X
                                        (e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y, // iz_Y
                                        iz_penPioro)); // iz_Pen
                        iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);
                    }
                    iz_imgRysownica.Refresh();



                }
                if (iz_rdbLiniaProsta.Checked)
                {


                    iz_PointList.Add(new iz_Line(iz_Punkt.X, iz_Punkt.Y, iz_penPioro));
                    iz_PointList[iz_PointList.Count - 1].iz_Draw(iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);

                    iz_imgRysownica.Refresh();

                }


            }
        }





        private void iz_btnZapisz_Click(object sender, EventArgs e)
        {
            {
                SaveFileDialog iz_ofDialogZapisz = new SaveFileDialog();
                iz_ofDialogZapisz.Filter = "Mapa bitowa: bmp|*.bmp";
                if (iz_ofDialogZapisz.ShowDialog() == DialogResult.OK)
                {
                    if (iz_ofDialogZapisz.FileName != "")
                        iz_imgRysownica.Image.Save(iz_ofDialogZapisz.FileName);

                }
            }
        }

        private void iz_btnWczytaj_Click(object sender, EventArgs e)
        {
            OpenFileDialog iz_ofDialogWczytaj = new OpenFileDialog();
            iz_ofDialogWczytaj.Filter = "Pliki mapy bitowej: bmp|*.bmp";
            if (iz_ofDialogWczytaj.ShowDialog() == DialogResult.OK)
            {
                Bitmap iz_WczytanaBitmapa = new Bitmap(iz_ofDialogWczytaj.FileName);
                iz_Rysownica.DrawImage(iz_WczytanaBitmapa, iz_imgRysownica.Left, iz_imgRysownica.Top);
                iz_imgRysownica.Refresh();
            }
        }



        private void label6_Click(object sender, EventArgs e)
        {
            ColorDialog iz_OknoKolorów = new ColorDialog();
            iz_OknoKolorów.Color = iz_lblKolorTla.BackColor;
            iz_lblKolorTla.BackColor = iz_lblKolorTla.BackColor;
            if (iz_OknoKolorów.ShowDialog() == DialogResult.OK)
            {
                iz_lblKolorTla.BackColor = iz_OknoKolorów.Color;
                iz_Rysownica.Clear(iz_OknoKolorów.Color);
                iz_imgRysownica.Refresh();
                iz_BackColor = iz_lblKolorTla.BackColor;
            }
            iz_PointList.Clear();
        }

        private void iz_lblKolorPdst_Click(object sender, EventArgs e)
        {
            ColorDialog iz_OknoKolorów = new ColorDialog();
            iz_OknoKolorów.Color = iz_lblKolorPdst.BackColor;
            if (iz_OknoKolorów.ShowDialog() == DialogResult.OK)
            {
                iz_penPioro.Color = iz_OknoKolorów.Color;
                iz_brushPedzel = new SolidBrush(iz_OknoKolorów.Color);
                iz_lblKolorPdst.BackColor = iz_OknoKolorów.Color;
            }
        }

        private void iz_lblKolorWypel_Click(object sender, EventArgs e)
        {
            ColorDialog iz_OknoKolorów = new ColorDialog();
            if (iz_OknoKolorów.ShowDialog() == DialogResult.OK)
            {
                iz_lblKolorWypel.BackColor = iz_OknoKolorów.Color;
                iz_brushPedzel = new SolidBrush(iz_OknoKolorów.Color);
            }
        }

        private void iz_imgRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            iz_lblWspolzednaX.Text = e.Location.X.ToString();
            iz_lblWspolzednaY.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {
                if (iz_rbOlowek.Checked)
                {

                    ((iz_Drawing)(iz_PointList[iz_PointList.Count - 1])).iz_AddPoint(e.Location);
                    iz_Rysownica.DrawLine(iz_penPioro, iz_Punkt, e.Location); //rysuje od razu, nie ma potrzeby co milisekunde wywolywac wymazywania i mazania od poczatku obiektu, i tak bedzie identyczny
                    iz_Punkt = e.Location;
                    iz_imgRysownica.Refresh();
                }
                else if (iz_rdbGumka.Checked)
                {
                    iz_penPioro.Color = iz_lblKolorTla.BackColor;
                    iz_Rysownica.DrawLine(iz_penPioro, iz_Punkt, e.Location);
                    iz_Punkt = e.Location;
                    iz_imgRysownica.Refresh();

                }
                else
                {
                    iz_Rysownica_temp = iz_imgRysownica.CreateGraphics();
                    if (iz_rdbLiniaProsta.Checked)
                    {
                        iz_imgRysownica.Refresh();
                        iz_Rysownica_temp.DrawLine(iz_penPioro, iz_Punkt.X, iz_Punkt.Y, e.X, e.Y);

                    }
                    if (iz_rdbOkrąg.Checked)
                    {
                        iz_imgRysownica.Refresh();
                        iz_Rysownica_temp.DrawEllipse(iz_penPioro, (e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y)),
                                                   (e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y)),
                                                   iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y),
                                                   iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y));
                    }
                    if (iz_rdbElipsa.Checked)
                    {
                        iz_imgRysownica.Refresh();
                        iz_Rysownica_temp.DrawEllipse(iz_penPioro, iz_Punkt.X, iz_Punkt.Y, e.X - iz_Punkt.X, e.Y - iz_Punkt.Y);
                    }


                    if (iz_rdbKwadrat.Checked)
                    {
                        iz_imgRysownica.Refresh();
                        iz_Rysownica_temp.DrawRectangle(iz_penPioro, (e.X > iz_Punkt.X) ? iz_Punkt.X : iz_Punkt.X - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y)),
                                                   (e.Y > iz_Punkt.Y) ? iz_Punkt.Y : iz_Punkt.Y - Math.Abs(iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y)),
                                                   iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y),
                                                   iz_ObliczOdleglosc(e.X, e.Y, iz_Punkt.X, iz_Punkt.Y));
                    }
                    if (iz_rdbProstokąt.Checked)
                    {
                        iz_imgRysownica.Refresh();
                        iz_Rysownica_temp.DrawRectangle(iz_penPioro, (e.X > iz_Punkt.X) ? iz_Punkt.X : e.X, (e.Y > iz_Punkt.Y) ? iz_Punkt.Y : e.Y,
                                                   ((e.X > iz_Punkt.X) ? e.X : iz_Punkt.X) - ((e.X > iz_Punkt.X) ? iz_Punkt.X : e.X),
                                                   ((e.Y > iz_Punkt.Y) ? e.Y : iz_Punkt.Y) - ((e.Y > iz_Punkt.Y) ? iz_Punkt.Y : e.Y));
                    }

                }
            }
        }

        private void iz_trbSuwakGrubościLinii_DragEnter(object sender, DragEventArgs e)
        {
            iz_penPioro.Width = 1 + iz_trbSuwakGrubościLinii.TabIndex;
        }

        private void iz_cmbStylLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (iz_cmbStylLinii.SelectedIndex)
            {
                case 0:
                    iz_penPioro.DashStyle = DashStyle.Dash; break;
                case 1:
                    iz_penPioro.DashStyle = DashStyle.DashDot; break;
                case 2:
                    iz_penPioro.DashStyle = DashStyle.DashDotDot; break;
                case 3:
                    iz_penPioro.DashStyle = DashStyle.Dot; break;
                case 4:
                    iz_penPioro.DashStyle = DashStyle.Solid; break;
                default:
                    iz_penPioro.DashStyle = DashStyle.Solid; break;
            }

        }



        private void iz_trbSuwakGrubościLinii_ValueChanged(object sender, EventArgs e)
        {
            switch (iz_trbSuwakGrubościLinii.Value)
            {
                case 0:
                    iz_penPioro.Width = 1; break;
                case 1:
                    iz_penPioro.Width = 2; break;
                case 2:
                    iz_penPioro.Width = 3; break;
                case 3:
                    iz_penPioro.Width = 4; break;
                case 4:
                    iz_penPioro.Width = 5; break;
                case 5:
                    iz_penPioro.Width = 6; break;
                case 6:
                    iz_penPioro.Width = 7; break;
                case 7:
                    iz_penPioro.Width = 8; break;
                case 8:
                    iz_penPioro.Width = 9; break;
                case 9:
                    iz_penPioro.Width = 10; break;
                default:
                    iz_penPioro.Width = 1; break;
            }
        }

        private void iz_btnRemove_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count == 0)
                return;

            if (iz_numDelete.Value > iz_PointList.Count - 1)
                return;

            iz_PointList[(int)iz_numDelete.Value].iz_Remove();
            iz_PointList.Remove(iz_PointList[(int)iz_numDelete.Value]);
            iz_imgRysownica.Refresh();

        }

        private void iz_rdbGumka_CheckedChanged(object sender, EventArgs e)
        {
            if (!iz_rdbGumka.Checked)
                iz_penPioro.Color = iz_lblKolorPdst.BackColor;
        }

        private void iz_btnMoveAll_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count == 0)
                return;
            Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
            iz_RandomDistracter = iz_Random.Next();


            iz_Rysownica.Clear(iz_BackColor);
            // Działa, ale nie pracujemy na warstwach, tylko metodą 'zagumkuj gdzie byłem', a to robi dziury w innych figurach :)
            // tak więc lepszy efekt będzie miało wyczyszczenie tablicy i narysowanie figur od początku

            foreach (iz_Point iz_moving in iz_PointList)
            {
                iz_moving.iz_Move(iz_Random.Next(0, iz_imgRysownica.Width), iz_Random.Next(0, iz_imgRysownica.Height));
                iz_moving.iz_Draw();
            }
            iz_imgRysownica.Refresh();
        }

        private void iz_btnRoll_Click(object sender, EventArgs e)
        {
            if (iz_PointList.Count == 0)
                return;
            Random iz_Random = new Random((int)DateTime.Now.Ticks * iz_RandomDistracter);
            iz_RandomDistracter = iz_Random.Next();


            iz_Rysownica.Clear(iz_BackColor);
            // Działa, ale nie pracujemy na warstwach, tylko metodą 'zagumkuj gdzie byłem', a to robi dziury w innych figurach :)
            // tak więc lepszy efekt będzie miało wyczyszczenie tablicy i narysowanie figur od początku

            foreach (iz_Point iz_moving in iz_PointList)
            {
                switch (iz_moving.iz_typeid)
                {
                    case TYPEID.DRAWING:
                        ((iz_Drawing)iz_moving).iz_Pen.DashStyle = (DashStyle)iz_Random.Next(0, 4);
                        ((iz_Drawing)iz_moving).iz_Pen.Width = iz_Random.Next(1, 20);
                        ((iz_Drawing)iz_moving).iz_Pen.Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        break;
                    case TYPEID.LINE:
                        ((iz_Line)iz_moving).iz_Pen.DashStyle = (DashStyle)iz_Random.Next(0, 4);
                        ((iz_Line)iz_moving).iz_Pen.Width = iz_Random.Next(1, 20);
                        ((iz_Line)iz_moving).iz_Pen.Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        break;
                    // hmm, mozna by tego pena wrzucic do iz_Point i wtedy wszystkie okoliczne rzeczy by byly zalatwione w jednym poleceniu,
                    // ale punkt sam w sobie nie jest rysowany, jest tylko punktem, wiec nie potrzebny mu Pen... :P 
                    // ale jesli potraktowac iz_Point jako klase stricte abstrakcyjna to mozna by to tam wladowac

                    case TYPEID.ELLIPSE:
                    case TYPEID.CIRCLE:
                        ((iz_Circle)iz_moving).iz_Pen.DashStyle = (DashStyle)iz_Random.Next(0, 4);
                        ((iz_Circle)iz_moving).iz_Pen.Width = iz_Random.Next(1, 20);
                        ((iz_Circle)iz_moving).iz_Pen.Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        break;


                    case TYPEID.RECTANGLE:
                    case TYPEID.SQUARE:
                        ((iz_Square)iz_moving).iz_Pen.DashStyle = (DashStyle)iz_Random.Next(0, 4);
                        ((iz_Square)iz_moving).iz_Pen.Width = iz_Random.Next(1, 20);
                        ((iz_Square)iz_moving).iz_Pen.Color = Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255));
                        break;


                    case TYPEID.FILLED_SQUARE:
                        ((iz_FilledSquare)iz_moving).iz_Brush = new SolidBrush(Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));
                        break;
                    case TYPEID.FILLED_RECTANGLE:
                        ((iz_FilledRectangle)iz_moving).iz_Brush = new SolidBrush(Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));
                        break;


                    case TYPEID.FILLED_ELLIPSE:
                        ((iz_FilledEllipse)iz_moving).iz_Brush = new SolidBrush(Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));
                        break;
                    case TYPEID.FILLED_CIRCLE:
                        ((iz_FilledCircle)iz_moving).iz_Brush = new SolidBrush(Color.FromArgb(iz_Random.Next(255), iz_Random.Next(255), iz_Random.Next(255)));
                        break;


                }
                iz_moving.iz_Draw();
            }
            iz_imgRysownica.Refresh();

        }

        private void iz_btnMoveAndRoll_Click(object sender, EventArgs e)
        {

            iz_btnMoveAll_Click(sender, e);
            iz_btnRoll_Click(sender, e);
        }







    }
}
