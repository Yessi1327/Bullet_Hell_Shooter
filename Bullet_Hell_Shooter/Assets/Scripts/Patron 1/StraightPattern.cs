using UnityEngine;

//Clase para generar el patron de ataque
public class TestBullets : MonoBehaviour
{
    //Cada cuántos segundos se dispara una Bala
    [SerializeField] private float _shootCooldown;

    //Velocidad 
    [SerializeField] private float _bulletSpeed;

    //Temporizador para saber cuando volver a lanzar la bala
    private float _shootCooldownTimer = 0f;

    void Update()
    {
         // En cada frame, reducimos el temporizador por el tiempo de frames transcurrido.
        _shootCooldownTimer -= Time.deltaTime;

        //Si el el contador llega a 0 se dispara otra bala
        if (_shootCooldownTimer <= 0f)
        {
            //Llama al metodo shot de BulletRelease para liberar la bala
            BulletRelease.Shot(transform.position, transform.up * _bulletSpeed);

            //Reinicia  contador para la siguiente bala
            _shootCooldownTimer += _shootCooldown;
        }
    }
}
