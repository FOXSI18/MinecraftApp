using MinecraftApp.Blocks;

namespace MinecraftApp;

class Program
{
    static void Main()
    {
        Console.Clear();
        
        SlotMachine.SlotMachine myMachine = new SlotMachine.SlotMachine();
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Welcome to Mini Minecraft!");
        Console.WriteLine("[BONUS] Slot machine: '5'");
        Console.WriteLine("If you want exit enter: '9'\n");
        
        while (true)
        {
            List<Basisblock> world = new List<Basisblock>
            {
                new Sand(),
                new Wood(),
                new Iron(),
            };
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You can choose your tool:");
            Console.WriteLine("1 = Hand");
            Console.WriteLine("2 = Pickaxe");
            Console.WriteLine("3 = Shovel");
            Console.WriteLine("4 = Axe");
            Console.ResetColor();

            Tool selectedTool;

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int toolNumber)) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid number.");
                Console.ResetColor();
                continue;
            }

            selectedTool = (Tool)toolNumber;
            Console.Clear();

            if (selectedTool == Tool.Exit)
                break;

            if (selectedTool == Tool.SlotM)
            {
                while (true)
                {
                    Console.WriteLine("\n1 = Rules\n2 = Play\n3 = Break\n");
                    
                    string slotInput = Console.ReadLine();
                    if (!int.TryParse(slotInput, out int userChoice) || userChoice < 1 || userChoice > 3) 
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please enter a number (1, 2 or 3).");
                        Console.ResetColor();
                        continue;
                    }

                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("=====RULES=====");
                        Console.WriteLine("Jackpot == 9 Scores");
                        Console.WriteLine("Win >= 7 Scores");
                        Console.WriteLine("Lose <= 6 Scores");
                        Console.WriteLine("\n=====VALUES=====");
                        Console.WriteLine("Dirt = 1\nApple = 2\nDiamond = 3\n");
                        Console.ResetColor();
                        continue;
                    }

                    if (userChoice == 2)
                    {
                        Console.Clear();
                        myMachine.ChooseRandomSlots();
                        continue;
                    }

                    if (userChoice == 3)
                    {
                        Console.Clear();
                        break;
                    }
                }
                continue;
            }

            if (selectedTool != Tool.Hand &&
                selectedTool != Tool.Pickaxe &&
                selectedTool != Tool.Shovel &&
                selectedTool != Tool.Axe)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You cannot choose an unknown tool!");
                Console.ResetColor();
                continue;
            }
            
            foreach (var block in world)
            {
                block.ShowInfo();
                block.Break(selectedTool);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All blocks have been destroyed!\n");
            Console.ResetColor();
        }

        Console.WriteLine("Program was finished!");
    }
}