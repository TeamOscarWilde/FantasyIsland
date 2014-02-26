namespace FantasyIsland.Classes.Items
{
    public class Axe : HandWeapon
    {
        public Axe()
            : base(Weapon.Axe.WeaponStats.AttackPower, Weapon.Axe.WeaponStats.Accuracy, Weapon.Axe.WeaponStats.Defence, Weapon.Axe.Weight, Weapon.Axe.Strength)
        {
        }
    }
}
