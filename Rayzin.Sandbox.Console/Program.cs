using System.Drawing;

using Rayzin;

var canvas = new RCanvas(900, 550);
RPoint start = (0, 1, 0);
RVector velocity = new RVector(1, 1.8, 0).Normalized * 11.25;

RVector gravity = (0, -0.1, 0);
RVector wind = (-0.01, 0, 0);

while (start.Y >= 0)
{
    canvas[(int)start.X, canvas.Height - (int)start.Y] = RColor.Red;

    start = start + velocity;
    velocity += (gravity + wind);
}

canvas.Save(@"D:\Temp\test.ppm");