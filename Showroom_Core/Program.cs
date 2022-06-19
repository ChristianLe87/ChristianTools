using Showroom_Shared;

namespace Showroom_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
}