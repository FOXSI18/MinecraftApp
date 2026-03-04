namespace MinecraftApp.SlotMachine;

public class SlotMachine
{
    public enum Nums
    {
        Null,
        Dirt,
        Apple,
        Diamond,
    }
    
    public void ChooseRandomNumber()
    {
        int[] slots = new int[3];
        Random r = new Random();
        int totalScore = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = r.Next(1, 4);
            totalScore += slots[i];

            Nums item = (Nums)slots[i];
            
            if (item == Nums.Dirt)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (item == Nums.Apple)
                Console.ForegroundColor = ConsoleColor.Red;
            if (item == Nums.Diamond)
                Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.Write($"{item} ");
            
            Console.ResetColor();
        }
        
        if (totalScore == 9)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nJACKPOT!!! | Scores: {totalScore}");
            Console.ResetColor();
        }
        else if (totalScore >= 7)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nYou won! | Scores: {totalScore}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nYou lose! | Scores: {totalScore}");
            Console.ResetColor();
        }
    }
}
