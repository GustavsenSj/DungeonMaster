namespace DungeonMaster;

public class HeroFactory
{
    public Hero CreateWizard(string name)
    {
        return new Wizard(name);
    }

    public Hero CreatArcher(string name)
    {
        return new Archer(name);
    }

    public Hero CreateSwashbuckler(string name)
    {
        return new Swashbuckler(name);
    }

    public Hero CreateBarbarian(string name)
    {
        return new Barbarian(name);
    }
}