namespace Text_Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] rooms = new int[8, 8];

            int health = 100;
            int damage = 10;
            int potions = 0;
            int maxHealth = 100;


            for (int i = rooms.GetLength(0) - 1; i > -1; i--)
            {
                for (int j = rooms.GetLength(1) - 1; j > rooms.GetLength(0) - i + 1; j--)
                {
                    rooms[i, j] = 1;
                }
            }
            int roomRow = 0;
            int roomCol = 0;
            typeEffect
                ("You have entered the dungeon\n" +
                "Slay the dragon to escape!!!");
            Console.ReadKey();
            Console.Clear();
            while (roomRow != 11) // unused condition for now  
            {
                typeEffect
                        ("Choose an action: \n" +
                        "M: Move \n" +
                        "S: Search room \n" +
                        "I: Check health, damage and potions \n" +
                        "H: Heal \n" +
                        "E: Quit game");
                Console.Write("> ");
                string choice = Console.ReadKey();
                Console.Clear();
                if (choice != null)
                {
                    choice = choice.ToUpper();
                }
                switch (choice)
                {
                    case "S":   //search function
                        int searchResult = Search(roomCol, roomRow);
                        if (searchResult % 4 == 1)
                        {
                            potions += 1;
                            typeEffect($"You found a potion\n" +
                                $"You now have {potions} potions");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else if (searchResult % 4 == 2)
                        {
                            typeEffect("placeholder.weapon");
                        }
                        else if (searchResult % 16 == 0)
                        {
                            health -= 20;
                            typeEffect("You fall onto a set of spikes in the corner\n" +
                                "You take 20 damage \n" +
                                $"Your health is now {health}");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            typeEffect("You dont find anything");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "I": // stats function
                        typeEffect($"Your health is {health}\n" +
                            $"Your attack damage is {damage}\n" +
                            $"You have {potions} potions\n" +
                            $"You are in room {roomRow}, {roomCol}");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    case "H":  // heal function

                        if (potions > 0)
                        {
                            if (health == maxHealth)
                            {
                                typeEffect("You are already at full health");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                potions -= 1;
                                health += 50;
                                health = clamp(health, 0, maxHealth);
                            }
                        }
                        else
                        {
                            typeEffect("You have no potions left");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "E":  //exit function
                        Environment.Exit(0);
                        break;

                }
            }

        }



        public static int Search(int RowR, int columbR) //search random number
        {
            Random rand = new Random();
            int found = rand.Next(1, 65);
            return (found);
        }

        public static int[] Combat(int hp, int damage, double room)
        {


            int[] returnArray = [hp, damage];
            return (returnArray);
        }

        public static int clamp(int value, int min, int max) //clamp function
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
        public static void typeEffect(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(8);
            }
            Console.WriteLine();
        }


        public static void Save()
        {

        }
    }
}
