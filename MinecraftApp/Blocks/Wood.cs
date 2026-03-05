namespace MinecraftApp.Blocks;

/// <summary>
/// Derived Class from Basisblock
/// </summary>
public class Wood : Basisblock
{
     public bool IsFlammable { get; set; }
     
     /// <summary>
     /// Calling the base class constructor for Wood
     /// </summary>
        public Wood() : base("Wood", "brown", 4)
    {
        IsFlammable = true;
    }
    
    /// <summary>
    /// Override method, that calculate break time for Wood.
    /// </summary>
    /// <param name="tool">from enum tools list</param>
    /// <returns>BreakTime</returns>
     public override int CalculateBreakTime(Tool tool)
    {
        if (tool == Tool.Axe)
            return BreakTime - 3;

        return BreakTime;
    }
}