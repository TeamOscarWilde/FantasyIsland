namespace FantasyIsland.Classes.Items
{
    public class Bow : RangeWeapon
    {
        public Bow()
            : base(Weapon.Bow.WeaponStats.AttackPower, Weapon.Bow.WeaponStats.Accuracy, Weapon.Bow.WeaponStats.Defence, Weapon.Bow.Weight, Weapon.Bow.Strength)
        {
        }
    }
}
