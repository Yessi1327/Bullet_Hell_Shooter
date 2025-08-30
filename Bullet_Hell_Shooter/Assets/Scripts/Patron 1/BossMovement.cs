using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{

    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    //Estará validando que cada 15 segundos se mueva
    private void TimeCheck()
    {
        if (TimeManager.Minute == 4)
        {
            StartCoroutine(MoveBoss());
        }

        else if (TimeManager.Minute == 10)
        {
            StartCoroutine(MoveBoss1());
        }

        else if (TimeManager.Minute  == 15)
        {
            StartCoroutine(MoveBoss2());
        }

        else if (TimeManager.Minute == 20)
        {
            StartCoroutine(MoveBoss3());
        }


    }

    //Actualizará nuestro cuadrado de posición
    private IEnumerator MoveBoss()
    {
        transform.position = new Vector3(0f, 10f, 0);
        Vector3 targetPos = new Vector3(10f, -5f, 0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 4;

        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    private IEnumerator MoveBoss1()
    {
        transform.position = new Vector3(10f, -5f, 0);
        Vector3 targetPos = new Vector3(0f, 10f, 0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 4;

        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    
    private IEnumerator MoveBoss2()
    {
        transform.position = new Vector3(0f, 10f, 0);
        Vector3 targetPos = new Vector3(-10f, -5f, 0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 4;

        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

    private IEnumerator MoveBoss3()
    {
        transform.position = new Vector3(-10f, -5f, 0);
        Vector3 targetPos = new Vector3(0f, 10f, 0);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 4;

        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed / timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }

}