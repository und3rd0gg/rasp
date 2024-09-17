class Weapon
{
    public Weapon(uint damage, uint bullets)
    {
        Damage = damage;
        Bullets = bullets;
    }
    
    public uint Damage { get; private set; }
    public uint Bullets { get; private set; }

    public void Fire(Player player)
    {
        if (Bullets <= 0)
            return;

        Bullets -= 1;
        player.TakeDamage(Damage);
    }
}

internal class Player
{
    public Player(uint healthValue)
    {
        Health = healthValue;
    }
    
    public uint Health { get; private set; }
    public bool IsDead { get; private set; } = false;
    
    public void TakeDamage(uint damage)
    {
        if (IsDead)
            return;

        Health -= damage;

        if (Health <= 0)
            IsDead = true;
    }
}

class Bot
{
    public Bot(Weapon weapon)
    {
        Weapon = weapon;
    }
    
    public Weapon Weapon { get; private set; }

    public void OnSeePlayer(Player player)
    {
        Weapon.Fire(player);
    }
}
