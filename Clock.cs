using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lucrarea6
{
 public partial class Form1 : Form
 {
 public Form1()
 {
   InitializeComponent();
 }
 System.Drawing.Graphics Desen;
 System.Drawing.Pen Pen_Blue, Pen_Red,Pen_Black,Pen_Fade;
 System.Drawing.SolidBrush Brush_Black;
 int x0,y0,x,y,d,i,nr_de_pcte=12;
 int ok=-1;
 double unghi;
 int[,] puncte; 
 static int[] centru; 
 
 private void Form1_Load(object sender, EventArgs e)
 {
 //timer1.Enabled = false;
 x0 = this.Width / 8;
 y0 = this.Height / 8;
 d = this.Width / 2;
 centru = new int[2];
 for(int i=0; i<2; i++)
 {
 if(i==0) centru[i] = x0 + d / 2;
 else centru[i] = y0 + d / 2;
 }
 puncte = new int[nr_de_pcte,2];
 Desen = this.CreateGraphics();
 Pen_Blue = new System.Drawing.Pen(System.Drawing.Color.Blue,2);
 Pen_Red = new System.Drawing.Pen(System.Drawing.Color.Red,4);
 Pen_Black = new System.Drawing.Pen(System.Drawing.Color.Black, 2);
 Brush_Black = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
 Pen_Fade = new System.Drawing.Pen(BackColor, 2);
 if (checkBox1.Checked == true && checkBox2.Checked == false)
 {
 ok=1;
 }
 if (checkBox2.Checked == true && checkBox1.Checked == false)
 {
 ok=0;
 }
 }
 
private void Form1_Paint(object sender, PaintEventArgs e)
 {
 Desen.Clear(this.BackColor);
 Desen.DrawEllipse(Pen_Blue, x0, y0, d, d);
 Desen.DrawEllipse(Pen_Black, centru[0], centru[1], 5, 5);
 Desen.FillEllipse(Brush_Black, centru[0], centru[1], 5, 5);
 i = 0;
 for (unghi = 0; unghi < 360; unghi += 360 / nr_de_pcte)
 {
 x = System.Convert.ToInt16(centru[0] + (d+20) / 2 * System.Math.Cos(2 * 
System.Math.PI * unghi / 360));
 y = System.Convert.ToInt16(centru[1] - (d+20) / 2 * System.Math.Sin(2 * 
System.Math.PI * unghi / 360));
 puncte[i,0] = x;
 puncte[i,1] = y;
 x = System.Convert.ToInt16(centru[0] + (d + 40) / 2 * System.Math.Cos(2 * 
System.Math.PI * unghi / 360));
 y = System.Convert.ToInt16(centru[1] - (d + 40) / 2 * System.Math.Sin(2 * 
System.Math.PI * unghi / 360));
 Desen.DrawLine(Pen_Red, x, y, puncte[i, 0], puncte[i, 1]);
 i++;
 }
 }
 
 private void timer1_Tick(object sender, EventArgs e)
 {
 if(ok==0)
 for (int i = 0; i < 12; i++)
 {
 Desen.DrawLine(Pen_Black, centru[0], centru[1], puncte[i, 0], puncte[i, 1]);
System.Threading.Thread.Sleep(1000);
Desen.DrawLine(Pen_Fade, centru[0], centru[1], puncte[i, 0], puncte[i, 1]);
Desen.FillEllipse(Brush_Black, centru[0], centru[1], 8, 8);
 }
 if(ok==1)
 for (int i = 11; i >= 0; i--)
 {
 Desen.DrawLine(Pen_Black, centru[0], centru[1], puncte[i, 0], puncte[i, 1]);
System.Threading.Thread.Sleep(1000);
Desen.DrawLine(Pen_Fade, centru[0], centru[1], puncte[i, 0], puncte[i, 1]);
Desen.FillEllipse(Brush_Black, centru[0], centru[1], 8, 8);
 }
 }
 }
}
