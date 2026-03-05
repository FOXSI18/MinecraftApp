using System.Text.Json;

namespace MinecraftApp.SlotMachine
{
    public class SlotMachine
    {
        /// <summary>
        /// Enum with slot chars
        /// </summary>
        public enum SlotChars
        {
            Null,
            Dirt,
            Apple,
            Diamond,
        }

        /// <summary>
        /// Constructor for Player statistic
        /// </summary>
        public class PlayerStats
        {
            public int Won { get; set; }
            public int Lose { get; set; }
            public int Jackpot { get; set; }
        }

        private const string JsonFilePath = "playerStats.json";

        /// <summary>
        /// Method choose random slots and write player statistic in json file.
        /// </summary>
        public void ChooseRandomSlots()
        {
            PlayerStats plStats;
            if (File.Exists(JsonFilePath))
            {
                string existingJson = File.ReadAllText(JsonFilePath);
                plStats = JsonSerializer.Deserialize<PlayerStats>(existingJson) ?? new PlayerStats();
            }
            else
            {
                plStats = new PlayerStats();
            }
            
            int[] slots = new int[3];
            Random r = new Random();
            int totalScore = 0;

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = r.Next(1, 4);
                totalScore += slots[i];

                SlotChars item = (SlotChars)slots[i];

                Console.ForegroundColor = item switch
                {
                    SlotChars.Dirt => ConsoleColor.DarkYellow,
                    SlotChars.Apple => ConsoleColor.Red,
                    SlotChars.Diamond => ConsoleColor.Cyan,
                    _ => ConsoleColor.White
                };

                Console.Write($"{item} ");
                Console.ResetColor();
            }
            
            if (totalScore == 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nJACKPOT!!! | Scores: {totalScore}");
                plStats.Jackpot++;
            }
            else if (totalScore >= 7)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nYou won! | Scores: {totalScore}");
                plStats.Won++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\nYou lose! | Scores: {totalScore}");
                plStats.Lose++;
            }
            Console.ResetColor();
            
            string updatedJson = JsonSerializer.Serialize(plStats, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, updatedJson);

            Console.WriteLine($"Stats -> Won: {plStats.Won}, Lose: {plStats.Lose}, Jackpots: {plStats.Jackpot}");
        }
    }
}
