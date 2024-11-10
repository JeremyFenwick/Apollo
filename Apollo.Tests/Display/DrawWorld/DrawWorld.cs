using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Display.DrawWorld;

public class DrawWorld
{
    [Test]
    public void DrawWorldTest()
    {
        // Sphere one (floor)
        var floor = new Sphere();
        floor.Transform = Matrix.Scaling(10, 0.01f, 10);
        floor.Material = new Material();
        floor.Material.Colour = new Colour(1f, 0.9f, 0.9f);
        floor.Material.Specular = 0;
        // // Sphere two (left wall)
        var leftWall = new Sphere();
        leftWall.Transform = Matrix.Translation(0, 0, 5) * 
                             Matrix.YRotation(-System.Math.PI / 4) * 
                             Matrix.XRotation(System.Math.PI / 2) * 
                             Matrix.Scaling(10, 0.01f, 10);
        leftWall.Material = floor.Material;
        // Sphere three (right wall)
        var rightWall = new Sphere();
        rightWall.Transform = Matrix.Translation(0, 0, 5) * 
                             Matrix.YRotation(System.Math.PI / 4) * 
                             Matrix.XRotation(System.Math.PI / 2) * 
                             Matrix.Scaling(10, 0.01f, 10);
        rightWall.Material = floor.Material;
        // // Sphere four (middle sphere)
        var middle = new Sphere();
        middle.Transform = Matrix.Translation(-0.5f, 1, 0.5f);
        middle.Material = new Material();
        middle.Material.Colour = new Colour(0.6f, 0.8f, 0);
        middle.Material.Diffuse = 0.7f;
        middle.Material.Specular = 0.3f;
        // Sphere five (right sphere)
        var right = new Sphere();
        right.Transform = Matrix.Translation(1.5f, 0.5f, -0.5f) * Matrix.Scaling(0.5f, 0.5f, 0.5f);
        right.Material = new Material();
        right.Material.Colour = new Colour(1, 0.4f, 0);
        right.Material.Diffuse = 0.7f;
        right.Material.Specular = 0.3f;
        // Sphere six (left sphere)
        var left = new Sphere();
        left.Transform = Matrix.Translation(-1.5f, 0.33f, -0.75f) * Matrix.Scaling(0.33f, 0.33f, 0.33f);
        left.Material = new Material();
        left.Material.Colour = new Colour(0.4f, 0.4f, 0.6f);
        left.Material.Diffuse = 0.7f;
        left.Material.Specular = 0.3f;
        // Setup world
        var spheres = new List<GeometricObject>() { floor, leftWall, rightWall, middle, right, left };
        var light = new PointLight(new Point(-10, 10, -10), new White());
        var world = new World(spheres, light);
        // Setup camera
        var camera = new Camera(1200, 800, System.Math.PI / 3);
        camera.Transform = Matrix.ViewTransform(new Point(0, 1.5f, -5), new Point(0, 1, 0), new Vector(0, 1, 0));
        // Render the result
        var photo = camera.Render(world);
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        File.WriteAllText(Path.Combine(docPath, "World.ppm"), photo.ExportAsPpm());
    }
}