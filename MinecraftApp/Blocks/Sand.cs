namespace MinecraftApp.Blocks;

/// <summary>
/// Derived Class from Basisblock
/// </summary>
public class Sand : Basisblock
{
    public bool FallsDown { get; set; }

    /// <summary>
    /// Calling the base class constructor for Sand
    /// </summary>
    public Sand() : base("Sand", "yellow", 2)
    {
        FallsDown = true;
    }

    /// <summary>
    /// Override method, that calculate break time for Sand.
    /// </summary>
    /// <param name="tool">from enum tools list</param>
    /// <returns>BreakTime</returns>
    public override int CalculateBreakTime(Tool tool)
    {
        if (tool == Tool.Shovel)
            return BreakTime - 1;

        return BreakTime;
    }
}