namespace FantasyIsland.Classes.Items
{
    public class Sword : HandWeapon
    {
        public Sword()
            : base(Weapon.Sword.WeaponStats.AttackPower, Weapon.Sword.WeaponStats.Accuracy, Weapon.Sword.WeaponStats.Defence, Weapon.Sword.Weight, Weapon.Sword.Strength)
        {
        }
    }
}
