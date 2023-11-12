using Rayzin;

var canvas = new RCanvas(256, 256);
for (var y = 0; y < 256; y++)
    for (var x = 0; x < 256; x++)
        canvas[x, y] = new RColor(x / 255.0, y / 255.0, 128);
        
canvas.Save(@"D:\Temp\test.ppm", RCanvasFileFormat.PPM8);