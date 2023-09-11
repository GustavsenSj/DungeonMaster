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