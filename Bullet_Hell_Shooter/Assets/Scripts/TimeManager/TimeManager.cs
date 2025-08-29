using UnityEngine;
//Trabajar con las funciones Generales
using System;

public class TimeManager : MonoBehaviour
{
    
    //Variables globales
    // OnMinute y OnHour son variables de tipo accion 
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    //Podemos asignar y obtener los valores de las variables
    //Cualquier elemento externo puede acceder a los valores
    public static int Minute { get; private set; }
    public static int Hour{get;private set;}

    //Establece el intervalo de tiempo entre cuantos minutos
    //en el juego equivalen a tiempo real 1min=.5 segundos 
    private float minuteToRealTime = 0.5f;

    //El intervao de tiempo antes de actualizar los valores
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Inicializar nuestras variables 
        Minute = 0;
        Hour = 0;
        timer = minuteToRealTime;

    }

    // Update is called once per frame
    void Update()
    {
        //Identifica cuando pasa el medio segundo en el tiempo real
        timer -= Time.deltaTime;

        //Aumentaremos Minute 
        if (timer <= 0)
        {
            Minute++;

            //Permite lanzar un evento
            OnMinuteChanged?.Invoke();

            //Si exceden 60 se sumara una hora
            if (Minute >= 60)
            {
                //Si sumamos una hora restablecemos los minutos a 0
                Hour++;
                //Permite lanzar un evento
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            timer = minuteToRealTime;
        }

    }
}