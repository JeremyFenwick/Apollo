using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Geometry.Patterns;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Display.Reflections;

public class DrawReflections
{
    [Test]
    public void DrawReflectionsTest()
    {
        // Sphere one (floor)
        var floor = new Plane();
        floor.Transform = Matrix.Scaling(10, 0.01f, 10);
        floor.Material = new Material();
        floor.Material.Colour = new Colour(0f, 0.2f, 0.4f);
        floor.Material.Specular = 0;
        // // Sphere two (left wall)
        var leftWall = new Plane();
        leftWall.Transform = Matrix.Translation(0, 0, 5) * 
                             Matrix.YRotation(-System.Math.PI / 4) * 
                             Matrix.XRotation(System.Math.PI / 2) * 
                             Matrix.Scaling(10, 10f, 10);
        leftWall.Material = floor.Material;
        // Sphere three (right wall)
        var rightWall = new Plane();
        rightWall.Transform = Matrix.Translation(0, 0, 5) * 
                             Matrix.YRotation(System.Math.PI / 4) * 
                             Matrix.XRotation(System.Math.PI / 2) * 
                             Matrix.Scaling(10, 10f, 10);
        rightWall.Material = floor.Material;
        // // Sphere four (middle sphere)
        var middle = new Sphere();
        middle.Transform = Matrix.Translation(-0.5f, 1, 0.5f) * Matrix.Scaling(0.75, 0.75, 0.75);
        middle.Material = new Material();
        middle.Material.Colour = new Colour(1f, 1f, .6f);
        middle.Material.Diffuse = 0.7f;
        middle.Material.Specular = 0.7f;
        middle.Material.Reflectivity = 1;
        // Setup world
        var spheres = new List<IShape>() { floor, leftWall, rightWall, middle };
        var light = new PointLight(new Point(-10, 10, -10), new White());
        var world = new World(spheres, light);
        // Setup camera
        var camera = new Camera(800, 500, System.Math.PI / 3);
        camera.Transform = Matrix.ViewTransform(new Point(0, 1.5f, -5), new Point(0, 1, 0), new Vector(0, 1, 0));
        // Render the result
        var photo = camera.Render(world);
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        File.WriteAllText(Path.Combine(docPath, "World.ppm"), photo.ExportAsPpm());
    }
}