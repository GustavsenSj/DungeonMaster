using DungeonMaster.Hero;

namespace DungeonMaster;
/// <summary>
/// The HeroFactory handles creation of different hero classes
/// </summary>
public class HeroFactory
{
    public IHero CreateWizard(string name)
    {
        return new Wizard(name);
    }

    public IHero CreateArcher(string name)
    {
        return new Archer(name);
    }

    public IHero CreateSwashbuckler(string name)
    {
        return new Swashbuckler(name);
    }

    public IHero CreateBarbarian(string name)
    {
        return new Barbarian(name);
    }
}