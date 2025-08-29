using UnityEngine;

public static class BulletRelease
{

     public static void Shot(Vector2 origin, Vector2 velocity)
    {
        BulletY bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.Velocity = velocity;

    }

}
