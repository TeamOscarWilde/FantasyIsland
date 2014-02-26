namespace FantasyIsland.Classes.Items
{
    public class Hammer : HandWeapon
    {
        public Hammer()
            : base(Weapon.Hammer.WeaponStats.AttackPower, Weapon.Hammer.WeaponStats.Accuracy, Weapon.Hammer.WeaponStats.Defence, Weapon.Hammer.Weight, Weapon.Hammer.Strength)
        {
        }
    }
}
