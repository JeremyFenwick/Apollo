using Apollo.Geometry;
using Apollo.Lighting;
using Apollo.Math;

namespace Apollo.Display;

public class Camera
{
    public int HSize { get; }
    public int VSize { get; }
    public double FOV { get; }
    public Matrix Transform { get; set; }
    public float PixelSize { get; }
    public float HalfWidth { get; }
    public float HalfHeight { get; }

    public Camera(int hSize, int vSize, double fov)
    {
        (HSize, VSize, FOV) = (hSize, vSize, fov);
        Transform = Matrix.Identity();
        
        var halfView = (float) System.Math.Tan(FOV / 2);
        var aspect = (float) HSize / VSize;
        if (aspect >= 1)
        {
            HalfWidth = halfView;
            HalfHeight = halfView / aspect;
        }
        else
        {
            HalfWidth = halfView * aspect;
            HalfHeight = halfView;
        }
        PixelSize = (HalfWidth * 2) / HSize;
    }

    public Ray RayForPixel(float px, float py)
    {
        var xOffset = (float) (px + 0.5) * PixelSize;
        var yOffset = (float) (py + 0.5) * PixelSize;
        var worldX = HalfWidth - xOffset;
        var worldY = HalfHeight - yOffset;
        var pixel = Transform.Inverse() * new Point(worldX, worldY, -1);
        var origin = Transform.Inverse() * new Point(0, 0, 0);
        var direction = (pixel - origin).Normalize();
        return new Ray(origin, direction);
    }

    public Canvas Render(World world)
    {
        var image = new Canvas(HSize, VSize);
        Parallel.For(0, VSize - 1, y =>
        {
            for (int x = 0; x < HSize - 1; x++)
            {
                var ray = RayForPixel(x, y);
                var color = ray.ColourAt(world);
                image.Set(x, y, color);
            }
        });
        return image;
    }
}