using System.Windows;
using System.Windows.Media.Media3D;
using System;
using System.Reflection;

namespace Zylinder
{
    public partial class MainWindow : Window
    {
        const int N = 128;
        public MainWindow()
        {
            InitializeComponent();
            // added
            diskTop.Geometry = Disk(1);
            diskBottom.Geometry = Disk(0);
            diskSide.Geometry = Body(0, 1);

        }
        // Replace square geometry by a disk
        static MeshGeometry3D Disk(double height)
        {
            MeshGeometry3D disk = new MeshGeometry3D();
            disk.Positions = Circle(height);
            // Center of disk has index N
            disk.Positions.Add(new Point3D(0, height, 0));
            if (height != 0)

                for (int i = 0; i < N; i++)
                {
                    disk.TriangleIndices.Add(N);
                    disk.TriangleIndices.Add((i + 1) % N);
                    disk.TriangleIndices.Add(i);
                }

            else
                for (int i = 0; i < N; i++)
                {
                    disk.TriangleIndices.Add(N);
                    disk.TriangleIndices.Add(i);
                    disk.TriangleIndices.Add((i + 1) % N);
                }

            return disk;
        }

        static MeshGeometry3D Body(double bottom, double height)
        {
            MeshGeometry3D body = new MeshGeometry3D();
            body.Positions = Circle(bottom, height);

            for (int i = 0; i < N; i++)
            {
                body.TriangleIndices.Add(i + 1);
                body.TriangleIndices.Add(i);
                body.TriangleIndices.Add(i + N);
            }

            for (int i = 0; i < N; i++)
            {
                body.TriangleIndices.Add(i + 1);
                body.TriangleIndices.Add(N + i);
                body.TriangleIndices.Add(N + i + 1);
            }

            return body;
        }

        static Point3DCollection Circle(double bottom, double height)
        {
            Point3DCollection positions = new Point3DCollection();
            for (int i = 0; i < N; i++)
            {
                double x = Math.Cos(i * 2 * Math.PI / N);
                double z = Math.Sin(i * 2 * Math.PI / N);
                positions.Add(new Point3D(x, bottom, z));
            }
            for (int i = 0; i < N; i++)
            {
                double x = Math.Cos(i * 2 * Math.PI / N);
                double z = Math.Sin(i * 2 * Math.PI / N);
                positions.Add(new Point3D(x, height, z));
            }
            return positions;
        }
        static Point3DCollection Circle(double height)
        {
            Point3DCollection positions = new Point3DCollection();
            for (int i = 0; i < N; i++)
            {
                double x = Math.Cos(i * 2 * Math.PI / N);
                double z = Math.Sin(i * 2 * Math.PI / N);
                positions.Add(new Point3D(x, height, z));
            }
            return positions;
        }
    }
}
