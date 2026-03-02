using MinecraftApp.Blocks;

namespace MinecraftApp
{
    class Program
    {
        static void Main()
        {
            Basisblock block;
            
            var exit = false;
            ConsoleKeyInfo userChoice;
            
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("If you want to see actions click 'Space'");
            Console.WriteLine("You can always press any NaN key to exit.");
            Console.ResetColor();
            
            do
            {
                userChoice = Console.ReadKey();
                
                switch (userChoice.Key)
                {
                    case ConsoleKey.D1:
                        FuncKey1();
                        break;
                    case ConsoleKey.D2:
                        FuncKey2();
                        break;
                    case ConsoleKey.D3:
                        FuncKey3();
                        break;
                    case ConsoleKey.D4:
                        FuncKey4();
                        break;
                    case ConsoleKey.Spacebar:
                        ShowActions();
                        break;
                    default:
                        ExitProgram();
                        break;
                }
            } while (exit == false);

            void FuncKey1()
            {
                Console.Clear();
                Console.WriteLine("Hand");
            }
            
            void FuncKey2()
            {
                Console.Clear();
                Console.WriteLine("Pickaxe");
            }
            
            void FuncKey3()
            {
                Console.Clear();
                Console.WriteLine("Shovel");
            }
            
            void FuncKey4()
            {
                Console.Clear();
                Console.WriteLine("Axe");
            }
            
            void ShowActions()
            {
                Console.Clear();
                Console.WriteLine("[1:Hand] | [2:Pickaxe] | [3:Shovel] | [4:Axe]"); 
            }
            
            void ExitProgram()
            {
                Console.Clear();

                Console.WriteLine("Are you sure that you exit want? Y/N");
                ConsoleKeyInfo exitChoice = Console.ReadKey();

                switch (exitChoice.Key)
                {
                    case ConsoleKey.Y:
                        exit = true;
                        break;
                    case ConsoleKey.N:
                        exit = false;
                        Console.Clear();
                        Main();
                        break;
                    default:
                        ExitProgram();
                        break;
                }
                // ! Потрібно читатати клавішу яку нажав юзер через світч, якщо дефолт, то повторити функцію

                /*if (exitChoice == "Y")
                    exit = true;
                else if  (exitChoice == "N")
                    exit = false;
                else
                    ExitProgram();*/
            }
        }
        
        /*public virtual void Abbauen()
        {
            Console.WriteLine("Abbauen");
        }*/
    }
}