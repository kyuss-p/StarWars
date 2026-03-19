namespace StarWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jedi luke = new Jedi(60, 80, 35, 20, "Luke Skywalker");
            Console.WriteLine(luke);

        }
    }
}
