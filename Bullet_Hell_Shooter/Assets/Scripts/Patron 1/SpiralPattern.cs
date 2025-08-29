using UnityEngine;

public class SpiralPattern : MonoBehaviour
{

    //Cada cuántos se dispara una Bala
    [SerializeField] private float _shootCooldown;
    //Velocidad
    [SerializeField] private float _bulletSpeed;

    // Variables de grados 
    [SerializeField, Range(-180f, 180f)]
    private float angleStepDeg; // grados que avanza la dirección cada disparo
  
    //Temporizador para saber cuando volver a lanzar la bala
    private float _shootCooldownTimer = 0f;      
    private float angleDeg = 0f;   // ángulo actual de cada disparo

    void Update()
    {
        // Resta tiempo de cooldown
        _shootCooldownTimer -= Time.deltaTime;

        //Si el el contador llega a 0 se dispara otra bala
        if (_shootCooldownTimer <= 0f)
        {
            // Dirección 
            Vector2 baseDir = Vector2.up;

            // Rotamos la dirección base por el ángulo actual 
            Vector2 dir = (Vector2)(Quaternion.Euler(0f, 0f, angleDeg) * baseDir);

            // Dispara la bala desde la posición del objeto, en la direccion y por la velocidad
            BulletRelease.Shot(transform.position, dir * _bulletSpeed);

            // Avanza el ángulo para el siguiente disparo para ir rotando
            angleDeg += angleStepDeg;

            // Reinicia el cooldown
            _shootCooldownTimer += _shootCooldown;
        }
    }
}
