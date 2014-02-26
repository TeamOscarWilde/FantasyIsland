namespace FantasyIsland.Classes.Items
{
    public abstract class HandWeapon : Weapon
    {
        protected HandWeapon(int attackPower, int accuracy, int defence, int weight, int strength)
            : base(attackPower, accuracy, defence, weight, strength, WeaponType.Hand)
        {
        }
    }
}
