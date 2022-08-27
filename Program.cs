class Weapon
{
    private uint _bullets;

    public bool CanShoot() => _bullets > 0;

    public void Shoot()
    {
        if (CanShoot())
            _bullets -= 1;
    }
}