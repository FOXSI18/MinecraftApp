namespace MinecraftApp.Blocks;

/// <summary>
/// Template class for all others blocks
/// </summary>
public abstract class Basisblock
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int BreakTime { get; set; }

    /// <summary>
    /// Constructor for Basisblock
    /// </summary>
    /// <param name="name">Name of block</param>
    /// <param name="color">Color of block</param>
    /// <param name="breakTime">Base break time of block</param>
    protected Basisblock(string name, string color, int breakTime)
    {
        Name = name;
        Color = color;
        BreakTime = breakTime;
    }
    
    /// <summary>
    /// Method, that show information about blocks: name, color and base break time.
    /// </summary>
    public virtual void ShowInfo()
    {
        if (Color == "yellow")
            Console.ForegroundColor = ConsoleColor.Yellow;
        if (Color == "brown")
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (Color == "gray")
            Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("===========================");
        Console.WriteLine($"Block: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Basic break time: {BreakTime} Seconds");
        Console.WriteLine("===========================");
    }

    /// <summary>
    /// Virtual part of method: calculate break time.
    /// There are also override methods available for blocks: Sand, Wood, and Iron.
    /// </summary>
    /// <param name="tool">from enum tools list</param>
    /// <returns>BreakTime</returns>
    public virtual int CalculateBreakTime(Tool tool)
    {
        return BreakTime;
    }

    /// <summary>
    /// Method that handles and displays the block-breaking process
    /// </summary>
    /// <param name="tool">from enum tools list</param>
     public void Break(Tool tool)
    {
        int time = CalculateBreakTime(tool);

        Console.WriteLine($"\nBreaking {Name} with {tool}...");

        for (int i = 1; i <= time; i++)
        {
            Console.WriteLine($"Time: {i} seconds");
            Thread.Sleep(1000);
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"> {Name} was broken!\n");
        Console.ResetColor();
    }
}