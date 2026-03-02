namespace MinecraftApp.Blocks
{
    public abstract class Basisblock
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
    
        public Basisblock(string name, string color, int speed)
        {
            Name = name;
            Color = color;
            Speed = speed;
        }
        
        /*public Info()
        {
            Console.WriteLine("");
        }*/
        
        /*public virtual void Abbauen()
        {
            Console.WriteLine("Abbauen");
        }*/
    } 
}