using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Lighting.DrawSphere;

public class DrawSphere
{
    // [Test]
    // public void DrawSphereToPpm()
    // {
    //     var sphere = new Sphere();
    //     sphere.Material = new Material(new Colour(0.4f, 0.4f, 0.6f));
    //     var light = new PointLight(new Point(-10, 10, -10), new White());
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
    //                 var intersect = Ray.Hit(intersects);
    //                 var point = ray.Position(intersect!.Time);
    //                 var normal = intersect.Object.NormalAt(point);
    //                 var eye = -ray.Direction;
    //                 var colour = Shading.Lighting(intersect.Object.Material, light, point, eye, normal);
    //                 canvas.Set(x, y, colour);
    //             }
    //         }
    //     });
    //     
    //     string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //     Console.Write(canvas.ExportAsPpm());
    //     File.WriteAllText(Path.Combine(docPath, "Sphere.ppm"), canvas.ExportAsPpm());
    // }
}