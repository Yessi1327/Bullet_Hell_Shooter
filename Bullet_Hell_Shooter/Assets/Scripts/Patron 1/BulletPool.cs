using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{

    //Acceder al pool desde cualquier script para reutilizarlo
    private static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
                // Mensaje de error si es que no esta en escena
                Debug.LogError("BulletPool Instance Missing.");
            return _instance;
        }
    }

    // Prefab de la bala del juego con UI image
    [SerializeField] private BulletY _bulletPrefabY;
    // Cuántas balas precarga el pool
    [SerializeField] private int _initialPoolSize = 10;

    //Lista de las balas clonadas
    private List<BulletY> _bulletPool = new List<BulletY>();

    //Contador  de balas activas, cualquier script puede acceder a este valor
    public int ActiveBullets { get; private set; } = 0;


    //Instancia una sola Bullet Pool 
    void Awake()
    {
        //Evita clones de Balas Duplicadas
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this; // Se guarda
        }

        // Precarga las Balas
        AddBulletsToPool(_initialPoolSize);
    }

    //Metodo Para ir añadiendo cada Bala al Pool
    void AddBulletsToPool(int x)
    {
        for (int i = 0; i < x; i++)
        {
            //Es importante poner transforme, false para evitar 
            //Que BulletY se transforme ya que es un onjeto UI
            BulletY bullet = Instantiate(_bulletPrefabY, transform, false);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
            // bullet.transform.parent = transform;
        }
    }


    //Consulta una bala desactivada para volverla activar en la Pool
    public BulletY RequestBullet()
    {
        for (int i = 0; i < _bulletPool.Count; i++)
        {
            if (!_bulletPool[i].gameObject.activeSelf)
            {
                _bulletPool[i].gameObject.SetActive(true);
                ActiveBullets++; //Suma al contador
                return _bulletPool[i];
            }
        }

        //Si no hay ninguna Bala disponible crea 1 más
        //Esto de ser requerido si se baja el espacio de espameo entre balas
        AddBulletsToPool(1);
        _bulletPool[_bulletPool.Count - 1].gameObject.SetActive(true);
        ActiveBullets++; // Suma al activar
        return _bulletPool[_bulletPool.Count - 1];
    }
    
    // Llamado por la bala cuando se apaga
    public void DiscountBullets()
    {
        ActiveBullets--; // Restar al desactivar
    }

}
