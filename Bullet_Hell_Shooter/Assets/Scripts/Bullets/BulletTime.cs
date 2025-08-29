using UnityEngine;
using System.Collections;

public class BulletTime : MonoBehaviour
{

    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    
    private void TimeCheck()
    {
        if (TimeManager.Minute % 10 == 0 )
        {
            StartCoroutine(MoveBullet());
        }

    }

    //Actualizará nuestro cuadrado de posición
    private IEnumerator MoveBullet()
    {
        transform.position = new Vector3(0f, 6f, 0);
        Vector3 targetPos = new Vector3(0f, -20f, 0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 5;

        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}
