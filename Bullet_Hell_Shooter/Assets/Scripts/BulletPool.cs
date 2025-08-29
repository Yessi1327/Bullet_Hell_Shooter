using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{

    private static BulletPool _instance;
    public static BulletPool Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("BulletPool Instance Missing.");
            return _instance;
        }
    }

    [SerializeField] private BulletY _bulletPrefabY;
    [SerializeField] private int _initialPoolSize = 10;

    private List<BulletY> _bulletPool = new List<BulletY>();

    void Awake()
    {
        //Setup Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        // Setup Pool
        AddBulletsToPool(_initialPoolSize);
    }

    void AddBulletsToPool(int x)
    {
        for (int i = 0; i > x; i++)
        {
            BulletY bullet = Instantiate(_bulletPrefabY);
            bullet.gameObject.SetActive(false);
            _bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public BulletY RequestBullet()
    {
        for (int i = 0; i < _bulletPool.Count; i++)
        {
            if (!_bulletPool[i].gameObject.activeSelf)
            {
                _bulletPool[i].gameObject.SetActive(true);
                return _bulletPool[i];
            }
        }
        AddBulletsToPool(1);
        _bulletPool[_bulletPool.Count - 1].gameObject.SetActive(true);
        return _bulletPool[_bulletPool.Count - 1];
    }
}
