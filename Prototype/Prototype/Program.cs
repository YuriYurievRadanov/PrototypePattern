using System;
using System.Collections.Generic;

namespace Prototype
{
    // Prototype Class
    abstract class GameScenePrototype
    {
        public abstract GameScenePrototype Clone();
    }

    // Concrete Prototype Class A
    class Hero : GameScenePrototype
    {
        public int Width { get; set; }
        public int Heigth { get; set; }
        public string Name { get; set; }
        public HeroType Type { get; set; }

        public Hero(int width, int heigth, string name, HeroType heroType)
        {
            Width = width;
            Heigth = heigth;
            Name = name;
            Type = heroType;
        }

        public override GameScenePrototype Clone()
        {
            return this.MemberwiseClone() as GameScenePrototype;
        }
    }

    // Concrete Prototype class B
    class Mine : GameScenePrototype
    {
        public double Gravity { get; set; }
        public MineType Type { get; set; }

        public Mine(double gravity, MineType mineType)
        {
            Gravity = gravity;
            Type = mineType;
        }

        public override GameScenePrototype Clone()
        {
            return this.MemberwiseClone() as GameScenePrototype;
        }
    }

    // Prototype Manager class
    class GameSceneManager
    {
        public List<GameScenePrototype> GameObjects { get; set; }
        public GameSceneManager()
        {
            GameObjects = new List<GameScenePrototype>();
        }
    }

    #region Helper

    enum HeroType
    {
        Warrior,
        Employee,
        Archer
    }

    enum MineType
    {
        Gold,
        Silver,
        Bronze
    }

    #endregion

    internal class Program
    {
        static void Main()
        {
            var manager = new GameSceneManager();

            var hero1 = new Hero(10, 20, "Bıkanyus", HeroType.Archer);
            manager.GameObjects.Add(hero1);
            var hero2 = new Hero(15, 35, "Wah!tupus", HeroType.Employee);
            manager.GameObjects.Add(hero2);

            var mine1 = new Mine(3, MineType.Gold);
            manager.GameObjects.Add(mine1);
            var mine2 = new Mine(5, MineType.Silver);
            manager.GameObjects.Add(mine2);

            manager.GameObjects.Add(mine2.Clone() as Mine);
            manager.GameObjects.Add(hero1.Clone() as Hero);
        }
    }
}
