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
        Console.WriteLine("Write '5' to Slot machine");
        Console.WriteLine("Write '9' to Exit\n");
        
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

            try
            {
                selectedTool = (Tool)Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (selectedTool == Tool.Exit)
                    break;

                if (selectedTool == Tool.SlotM)
                {
                    while (true)
                    {
                        Console.WriteLine("\n1 = Rules\n2 = Play\n3 = Break\n");
                        int userChoice = Convert.ToInt32(Console.ReadLine());

                        if (userChoice == 1)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("=====RULES=====");
                            Console.WriteLine("Jackpot == 9 Scores");
                            Console.WriteLine("Win >= 7 Scores");
                            Console.WriteLine("Lose <= 6  Scores");
                            Console.WriteLine("\n=====VALUES=====");
                            Console.WriteLine("Dirt = 1\nApple = 2\nDiamond = 3\n");
                            Console.ResetColor();
                            continue;
                        }
                        if (userChoice == 2)
                        {
                            Console.Clear();
                            myMachine.ChooseRandomNumber();
                            continue;
                        }
                        if (userChoice == 3)
                        {
                            Console.Clear();
                            break;
                        }
                        
                        Console.Clear();
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
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Too much! Overflow");
                Console.ResetColor();
                continue;  
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must enter a valid number!");
                Console.ResetColor();
                continue;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e);
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