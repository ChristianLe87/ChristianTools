using Showroom;

namespace CrossPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            using var game = new Showroom.Game1(new WK());
            game.Run();
        }
    }
}