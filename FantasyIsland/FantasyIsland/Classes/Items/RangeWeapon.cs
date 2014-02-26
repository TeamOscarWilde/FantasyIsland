namespace FantasyIsland.Classes.Items
{
    public abstract class RangeWeapon : Weapon
    {
        protected RangeWeapon(int attackPower, int accuracy, int defence, int weight, int strength)
            : base(attackPower, accuracy, defence, weight, strength)
        {
        }
    }
}
