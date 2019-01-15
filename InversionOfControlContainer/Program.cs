using System;
using System.Linq;

namespace InversionOfControlContainer
{
    public interface IWeapon
    {
        void Kill();
        void GetCharacteristik();
    }
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder container = new ContainerBuilder();
            container.Register<IWeapon, Weapon>()
                     .AddConstructionArgument("name", "qwerty")
                     .AddConstructionArgument("bulka", true)
                     .AddConstructionArgument("lenght", 15);

            IWeapon weaponOne = container.GetService<IWeapon>();
            IWeapon weaponTwo = container.GetService<IWeapon>();

            weaponOne.GetCharacteristik();
        }
    }

    public class Weapon : IWeapon
    {
        int lenght;
        string name;
        bool bulka;
        public Weapon(int lenght, string name, bool bulka)
        {
            this.name = name;
            this.lenght = lenght;
            this.bulka = bulka;
        }

        public void Kill()
        {
            Console.WriteLine("Killed");
        }
        public void GetCharacteristik()
        {
            Console.WriteLine($"Lenght {lenght}, name {name}, bulka {bulka}");
        }
    }
    class Warrior
    {
        private readonly IWeapon weapon;

        public Warrior(IWeapon weapon)
        {
            this.weapon = weapon;
        }

    }
}
