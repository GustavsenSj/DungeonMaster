using DungeonMaster.equipments;
using DungeonMaster.Hero;

namespace DungeonMaster;

public static class HeroExtensions
{
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
        int damage = 0;

        IEquipment? equipment = hero.Equipments[EquipmentSlot.Weapon];

        if (equipment is Weapon weapon)
        {
            damage = weapon.GetDamage();
        }

        return damage;
    }
}