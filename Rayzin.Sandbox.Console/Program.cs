using System.Drawing;

using Rayzin;

var canvas = new RCanvas(1024, 1024);
RPoint p = (0, -480, 0);
RMatrix rotate = RTransform.RotateZ(Math.PI * 2 / 12);

for (var index = 0; index < 12; index++)
{
    for (var dx = -5; dx <= 5; dx++)
    {
        for (var dy = -5; dy <= 5; dy++)
        {
            canvas[512 + (int)p.X + dx, 512 + (int)p.Y + dy] = RColor.Red;
        }
    }

    p = rotate * p;
}

canvas.Save(@"D:\Temp\test.ppm");