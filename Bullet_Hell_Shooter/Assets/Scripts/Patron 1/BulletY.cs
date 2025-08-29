using UnityEngine;

//Crear nuestra clase de la bala prefabricada 
public class BulletY : MonoBehaviour
{

    //Vida maxima que tendra la bala
    private const float MaxLife = 3f;

    //Contador de tiempo de vida
    private float timeToMove = 0f;

    // Velocidad/ direccion actual de la bala
    public Vector2 Velocity;

    void OnEnable()
    {
        //resetea el contador  por si se reusa
        timeToMove = 0f;
    }


    void Update()
    {
        //Mueve la bala con la dirreccion y velocidad que asignemos en el inspector
        transform.position += (Vector3)Velocity * -Time.deltaTime;
        // Le suma el frame a el contador de vida
        timeToMove += Time.deltaTime;

        //Si el contador de vida es mayor a la vida maxima el objeto se desactiva
        if (timeToMove > MaxLife)
            Disable();
    }

    //Metodo para desactivar las balas y no destruir el objeto
    //Asi solo reutilizamos las balas que ya estan creadas
    // y solo las activamos y desactivamos conforme se necesitan
    private void Disable()
    {
        timeToMove = 0;
        // Notifica al pool que una bala se desactiva
        if (BulletPool.Instance != null)
        {
            BulletPool.Instance.DiscountBullets();
        }

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
