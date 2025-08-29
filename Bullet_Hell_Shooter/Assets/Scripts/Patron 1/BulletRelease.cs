using UnityEngine;

//Metodo estatico para liberar una bala desde un punto 
//con una velocidad y dirección especificas
public static class BulletRelease
{

    public static void Shot(Vector2 origin, Vector2 velocity)
    {
        //Llama al metodo que consulta una bala del pool para activarla
        BulletY bullet = BulletPool.Instance.RequestBullet(); 
        //Posiciona la bala en el punto de salida
        bullet.transform.position = origin;
        //Asigna direccion y velocidad
        bullet.Velocity = velocity;

    }

}
