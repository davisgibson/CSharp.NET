using System;

namespace superheroRedo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
        }
    }

    public class Person
    {
        public string name;
        public string nickname;
        public Person(string name, string nickname)
        {
            this.name = name;
            this.nickname = nickname;
        }
        public override string ToString()
        {
            return name;
        }
        public void printGreeting()
        {
            Console.WriteLine($"Hi! My name is {name}, but you can call me {nickname}");
        }
    }

    public class SuperHero : Person
    {
        public string realName;
        public string superPower;
        public SuperHero(string name, string realName, string superPower):base(name,null)
        {
            this.realName = realName;
            this.superPower = superPower;
        }
        public void printGreeting()
        {
            Console.WriteLine($"My name is {realName}, but when I'm {name} my super power is {superPower}");
        }
    }
    public class Villain : Person
    {
        public string nemesis;
        public Villain(string name, string nemesis) : base(name, null)
        {
            this.nemesis = nemesis;
        }
        public void printGreeting()
        {
            Console.WriteLine($"I am {name}, have you seen {nemesis}?");
        }
    } 
}
