using UnityEngine;

public class BulletY : MonoBehaviour
{

    private const float MaxLife = 5f;
    private float timeToMove = 0f;


    public Vector2 Velocity;


    void Start()
    {

    }

    void Update()
    {
        transform.position += (Vector3)Velocity * -Time.deltaTime;
        timeToMove += Time.deltaTime;

        if (timeToMove > MaxLife)
            Disable();
    }

    private void Disable()
    {
        timeToMove = 0;
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
