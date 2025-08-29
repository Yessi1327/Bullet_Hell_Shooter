using UnityEngine;

public class TestBullets : MonoBehaviour
{
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _bulletSpeed;

    private float _shootCooldownTimer = 0f;

    void Update()
    {
        _shootCooldownTimer -= Time.deltaTime;

        if (_shootCooldownTimer <= 0f)
        {
            BulletRelease.Shot(transform.position, transform.up * _bulletSpeed);
            _shootCooldownTimer += _shootCooldown;
        }
    }
}
