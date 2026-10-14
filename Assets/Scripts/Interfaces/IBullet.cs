using System;

public interface IBullet
{
    public float BulletSpeed
    {
        get => throw new InvalidOperationException();
    }
    
    public float BulletRange
    {
        get => throw new InvalidOperationException();
    }
    
    public float BulletReloadSpeed
    {
        get => throw new InvalidOperationException();
    }
    
    public int BulletMagSize
    {
        get => throw new InvalidOperationException();
    }

    public int BulletDamage
    {
        get => throw new InvalidOperationException();
    }
}
