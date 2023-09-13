using DungeonMaster.equipments;

namespace DungeonMaster.Hero;
/// <summary>
/// Hero Extensions represents an extensions class for the IHero. It extends the functionality of th classes implementing IHero Interface 
/// </summary>
public static class HeroExtensions
{
    /// <summary>
    /// Sett all equipment slots to null so that no equipment is equipped 
    /// </summary>
    /// <param name="hero"> The hero to run the function on </param>
    public static void EquipNullEquipment(this IHero hero)
    {
        hero.Equipments.Add(EquipmentSlot.Body, null);
        hero.Equipments.Add(EquipmentSlot.Head, null);
        hero.Equipments.Add(EquipmentSlot.Legs, null);
        hero.Equipments.Add(EquipmentSlot.Weapon, null);
    }

    public static void RemoveWeapon(this IHero hero)
    {
        hero.Equipments[EquipmentSlot.Weapon] = null;
    }

    public static void RemoveHead(this IHero hero)
    {
        hero.Equipments[EquipmentSlot.Head] = null;
    }

    public static void RemoveLegs(this IHero hero)
    {
        hero.Equipments[EquipmentSlot.Legs] = null;
    }

    public static void RemoveBody(this IHero hero)
    {
        hero.Equipments[EquipmentSlot.Body] = null;
    }

    public static int GetDamageOfEquippedWeapon(this IHero hero)
    {
        int damage = 1;

        IEquipment? equipment = hero.Equipments[EquipmentSlot.Weapon];

        if (equipment is Weapon weapon)
        {
            damage = weapon.GetDamage();
        }

        return damage;
    }

    public static int GetDexFromEquippedArmor(this IHero hero)
    {
        return hero.CalculateDex();
    }

    public static int GetIntFromEquippedArmor(this IHero hero)
    {
        return hero.CalculateInt();
    }

    public static int GetStrengthFromEquippedArmor(this IHero hero)
    {
        return hero.CalculateStrength();
    }
}