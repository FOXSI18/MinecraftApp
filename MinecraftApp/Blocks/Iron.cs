namespace MinecraftApp.Blocks;

/// <summary>
/// Derived Class from Basisblock
/// </summary>
public class Iron : Basisblock
{
    public bool IsHard { get; set; }

    /// <summary>
    /// Calling the base class constructor for Iron
    /// </summary>
    public Iron() : base("Iron", "gray", 6)
    {
        IsHard = true;
    }
    
    /// <summary>
    /// Override method, that calculate break time for Iron.
    /// </summary>
    /// <param name="tool">from enum tools list</param>
    /// <returns>BreakTime</returns>
     public override int CalculateBreakTime(Tool tool)
    {
        if (tool == Tool.Pickaxe)
            return BreakTime - 4;

        return BreakTime;
    }
}