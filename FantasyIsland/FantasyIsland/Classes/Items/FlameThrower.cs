namespace FantasyIsland.Classes.Items
{
    public class Flamethrower : RangeWeapon
    {
        public Flamethrower()
            : base(Weapon.Flamethrower.WeaponStats.AttackPower, Weapon.Flamethrower.WeaponStats.Accuracy, Weapon.Flamethrower.WeaponStats.Defence, Weapon.Flamethrower.Weight, Weapon.Flamethrower.Strength)
        {
        }
    }
}
