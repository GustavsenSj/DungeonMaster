// See https://aka.ms/new-console-template for more information

using DungeonMaster;
Hero player = new HeroFactory().CreatArcher("Sjur");

Console.WriteLine("Hello, World!");
player.PrintHeroDetails();