namespace FantasyIsland.Classes.Items
{
    public class CrossBow : RangeWeapon
    {
        public CrossBow()
            : base(Weapon.CrossBow.WeaponStats.AttackPower, Weapon.CrossBow.WeaponStats.Accuracy, Weapon.CrossBow.WeaponStats.Defence, Weapon.CrossBow.Weight, Weapon.CrossBow.Strength)
        {
        }
    }
}
