namespace StarWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jedi lukeSkywalker = new Jedi(75, 60, "Luke Skywalker", 50);
            Sith darthVader = new Sith(85, 75, "Darth Vader", 60);

            darthVader.Attack(lukeSkywalker);
            lukeSkywalker.Attack(darthVader);
            darthVader.ForceAbility(lukeSkywalker);
            darthVader.Attack(lukeSkywalker);

            Console.WriteLine();

            Console.WriteLine(lukeSkywalker);
            Console.WriteLine(darthVader);

        }
    }
}
