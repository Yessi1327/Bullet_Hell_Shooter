using System.Collections;
using UnityEngine;

public class FirstPatterns : MonoBehaviour
{
    //Tiempo de espameo y velocidad
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _bulletSpeed;

    //Angulo para el patron
    [SerializeField, Range(0f, 90f)]
    private float fanAngle = 30f; //Separacion de las lineas de disparo 

    //Hacia donde se dispara
    [SerializeField] private bool shootDown = false; 

  

    private Coroutine loop;

    void OnEnable()
    {
        // Arranca el loop del patrón cuando el objeto se activa
        loop = StartCoroutine(FireLoop());
    }

    void OnDisable()
    {
        // Detiene el loop si el objeto se desactiva
        if (loop != null) StopCoroutine(loop);
    }

    void Start()
    {
        loop = StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
    {
        yield return null; 

        // Vector base: hacia abajo (0,-1) o hacia arriba (0,1)
        Vector2 baseDir = shootDown ? Vector2.down : Vector2.up;

        while (true)
        {
            // 1) Centro (sin rotación)
            Vector2 vCenter = baseDir * _bulletSpeed;

            // 2) Calcula las direcciones rotadas usando Quaternion.Euler(0,0,angulo) * vector
            //    Nota: en UI 2D, rotamos sobre Z.
            Vector2 vLeft = (Vector2)(Quaternion.Euler(0f, 0f, +fanAngle) * baseDir) * _bulletSpeed;
            Vector2 vRight = (Vector2)(Quaternion.Euler(0f, 0f, -fanAngle) * baseDir) * _bulletSpeed;

            // Origen de disparo
            Vector2 origin = (Vector2)transform.position;

            // Dispara las tres balas
            BulletRelease.Shot(origin, vCenter);
            BulletRelease.Shot(origin, vLeft);
            BulletRelease.Shot(origin, vRight);

            // Espera próxima ráfaga
            yield return new WaitForSeconds(_shootCooldown);
        }
    }
}
