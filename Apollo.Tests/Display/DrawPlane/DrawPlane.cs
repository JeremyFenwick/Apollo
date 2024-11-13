using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Display.DrawPlane;

public class DrawPlane
{
    // [Test]
    // public void DrawPlaneTest()
    // {
    //     // Setup wall
    //     var wall = new Plane();
    //     wall.Material = new Material();
    //     wall.Transform =  Matrix.Translation(0, 10, 0);
    //     wall.Material.Colour = new Colour(0f, 0.4f, 0.8f);
    //     wall.Material.Specular = 0;
    //     // Setup floor
    //     var floor = new Plane();
    //     floor.Material = new Material();
    //     floor.Material.Colour = new Colour(.6f, 0.8f, 0f);
    //     floor.Material.Specular = 0;
    //     // Setup middle sphere
    //     var middle = new Sphere();
    //     middle.Transform = Matrix.Translation(0, .5, 0) * Matrix.Scaling(0.5, 0.5, 0.5);
    //     middle.Material = new Material();
    //     middle.Material.Colour = new Colour(1f, 1f, .6f);
    //     middle.Material.Diffuse = 0.7f;
    //     middle.Material.Specular = 0.7f;
    //     // Setup world
    //     var spheres = new List<IShape>() { middle, floor, wall };
    //     var light = new PointLight(new Point(-6, 5, -10), new White());
    //     var world = new World(spheres, light);
    //     // Setup camera
    //     var camera = new Camera(1200, 600, System.Math.PI / 3);
    //     camera.Transform = Matrix.ViewTransform(new Point(0, 1.5f, -5), new Point(0, 1, 0), new Vector(0, 1, 0));
    //     // Render the result
    //     var photo = camera.Render(world);
    //     string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //     File.WriteAllText(Path.Combine(docPath, "World.ppm"), photo.ExportAsPpm());
    // }
}