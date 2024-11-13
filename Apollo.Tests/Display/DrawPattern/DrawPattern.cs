using Apollo.Display;
using Apollo.Display.ColourPresets;
using Apollo.Geometry;
using Apollo.Geometry.Interfaces;
using Apollo.Geometry.Patterns;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Tests.Display.DrawPattern;

public class DrawPattern
{
    [Test]
    public void DrawStripes()
    {
        // Setup floor
        var floor = new Plane();
        floor.Material = new Material();
        floor.Material.Colour = new Colour(.2f, 0.2f, .2f);
        floor.Material.Pattern = new Stripe(new White(), new Black());
        floor.Material.Specular = 0;
        // Setup middle sphere
        var middle = new Sphere();
        middle.Transform = Matrix.Translation(0, .5, 0) * Matrix.Scaling(0.5, 0.5, 0.5);
        middle.Material = new Material();
        middle.Material.Colour = new Colour(1f, 1f, .6f);
        middle.Material.Diffuse = 0.7f;
        middle.Material.Specular = 0.7f;
        middle.Material.Pattern = new Stripe(new Red(), new White());
        middle.Material.Pattern.Transform = Matrix.Scaling(0.2, 0.2, 0.2) * Matrix.YRotation(System.Math.PI / 3);
        // Setup world
        var spheres = new List<IShape>() { middle, floor };
        var light = new PointLight(new Point(-6, 5, -10), new White());
        var world = new World(spheres, light);
        // Setup camera
        var camera = new Camera(1200, 800, System.Math.PI / 3);
        camera.Transform = Matrix.ViewTransform(new Point(0, 1.5f, -5), new Point(0, 1, 0), new Vector(0, 1, 0));
        // Render the result
        var photo = camera.Render(world);
        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        File.WriteAllText(Path.Combine(docPath, "World.ppm"), photo.ExportAsPpm());
    }
    
    [Test]
    public void DrawGradient()
    {
        // Setup floor
        var floor = new Plane();
        floor.Material = new Material();
        floor.Material.Colour = new Colour(.2f, 0.2f, .2f);
        floor.Material.Pattern = new Stripe(new Green(), new White());
        floor.Material.Specular = 0;
        // Setup middle sphere
        var middle = new Sphere();
        middle.Transform = Matrix.Translation(0, .5, 0) * Matrix.Scaling(0.5, 0.5, 0.5);
        middle.Material = new Material();
        middle.Material.Colour = new Colour(1f, 1f, .6f);
        middle.Material.Diffuse = 0.7f;
        middle.Material.Specular = 0.7f;
        middle.Material.Pattern = new Gradient(new Red(), new Orange());
        middle.Material.Pattern.Transform = Matrix.YRotation(System.Math.PI / 3);
        // Setup world
        var spheres = new List<IShape>() { middle, floor };
        var light = new PointLight(new Point(-6, 5, -10), new White());
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