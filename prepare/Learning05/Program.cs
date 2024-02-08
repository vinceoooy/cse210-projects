using System;


class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        // Create instances of each shape and add them to the list
        shapes.Add(new Square("Red", 5.0));
        shapes.Add(new Rectangle("Blue", 4.0, 6.0));
        shapes.Add(new Circle("Green", 3.0));

        // Iterate through the list and display color and area for each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
