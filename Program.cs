namespace StarWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jedi anakinSkywalker = new Jedi(75, 70, "Anakin Skywalker", 60);
            Padawan ahsokaTano = new Padawan(60, 45, "Ahsoka Tano", 30, anakinSkywalker);
            Sith countDooku = new Sith(70, 80, "Count Dooku", 75);
            SithApprentice savageOpress = new SithApprentice(65, 55, "Savage Opress", 60, countDooku);
            Trooper captainRex = new Trooper(55, 45, "Captain Rex", "CT-7567");
            BountyHunter jangoFett = new BountyHunter(60, 50, "Jango Fett");

            ahsokaTano.ForceAbility(countDooku);
            anakinSkywalker.Attack(countDooku);
            countDooku.ForceAbility(anakinSkywalker);
            savageOpress.ForceAbility(ahsokaTano);
            captainRex.Attack(countDooku);
            captainRex.SpecialAbility(savageOpress);
            jangoFett.SpecialAbility(captainRex);
            jangoFett.Reload();
            jangoFett.Attack(captainRex);

            Console.WriteLine();

            Console.WriteLine(anakinSkywalker);
            Console.WriteLine(ahsokaTano);
            Console.WriteLine(countDooku);
            Console.WriteLine(savageOpress);
            Console.WriteLine(captainRex);
            Console.WriteLine(jangoFett);
        }
    }
}
