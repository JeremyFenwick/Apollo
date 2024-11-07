using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting.DrawCircle;

public class DrawCircle
{
    // [Test]
    // public void DrawCircleToPpm()
    // {
    //     var sphere = new Sphere();
    //     sphere.Transform = Matrix.Shear(1, 0, 0, 0, 0, 0) * Matrix.Scaling(0.5f, 1, 1);
    //     var wallZ = 10f;
    //     var origin = new Point(0, 0, -5);
    //     var wallSize = 7f;
    //     var canvasPixels = 1000;
    //     var pixelSize = wallSize / canvasPixels;
    //     var half = wallSize / 2;
    //     var canvas = new Canvas(canvasPixels, canvasPixels);
    //
    //     Parallel.For(0, canvasPixels, y =>
    //     {
    //         var worldY = half - pixelSize * y;
    //         for (int x = 0; x < canvasPixels; x++)
    //         {
    //             var worldX = -half + (pixelSize * x);
    //             var position = new Point(worldX, worldY, wallZ);
    //             var ray = new Ray(origin, new Vector((position - origin).Normalize()));
    //             var intersects = ray.Intersect(sphere);
    //             if (Ray.Hit(intersects) != null)
    //             {
    //                 canvas.Set(x, y, new Red());
    //             }
    //         }
    //     });
    //     
    //     string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //     File.WriteAllText(Path.Combine(docPath, "Circle.ppm"), canvas.ExportAsPpm());
    // }
}