using System.Collections;
using UnityEngine;

public class FirstPatterns : MonoBehaviour
{
    //Tiempo de espameo y velocidad
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _bulletSpeed;

    //Angulo para el patron
    [SerializeField, Range(0f, 90f)] //Angulo para la separacion de los dos disparos extras
    private float BulletAngle = 30f; //Angulo de eparacion de las lineas de disparo 
  

    private Coroutine loop;

    void OnEnable()
    {
        // Arranca el loop del patrón cuando el objeto se activa
        if (loop == null) // evita arrancar dos veces
        {
        loop = StartCoroutine(FireLoop());
        }                    
    }

    void OnDisable()
    {
        // Detiene el loop si el objeto se desactiva
        if (loop != null) StopCoroutine(loop);
    }

    IEnumerator FireLoop()
    {
        yield return null;

        float _shootCooldownTimer = 0f;
        // Vector base
        Vector2 baseDir = Vector2.up;

        while (true)
        {
            //En cada frame, reducimos el temporizador
            _shootCooldownTimer -= Time.deltaTime;

            ////Si el el contador llega a 0 se dispara otra bala
            if (_shootCooldownTimer <= 0f)
            {

                // Centro disparo recto
                Vector2 BCenter = baseDir * _bulletSpeed;

                // Direcciones rotadas usando Quaternion.Euler(0,0,angulo) * vector
                Vector2 BLeft = (Vector2)(Quaternion.Euler(0f, 0f, +BulletAngle) * baseDir) * _bulletSpeed;
                Vector2 BRight = (Vector2)(Quaternion.Euler(0f, 0f, -BulletAngle) * baseDir) * _bulletSpeed;

                // Origen de disparo
                Vector2 origin = (Vector2)transform.position;

                // Dispara las tres balas
                BulletRelease.Shot(origin, BCenter);
                BulletRelease.Shot(origin, BLeft);
                BulletRelease.Shot(origin, BRight);

                //Reinicia  contador para la siguiente bala
                _shootCooldownTimer = _shootCooldown;

            }
            
            // proximo frame
            yield return null;
        }
    }
}
