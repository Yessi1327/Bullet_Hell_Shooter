using UnityEngine;
//Para el uso del TextMeshPro,
using TMPro;

//Actualizar nuestro TextMeshPro
public class TimeUI : MonoBehaviour
{
    //Asignar nuestro TextMeshPro desde el Inspector.
    public TextMeshProUGUI timeText;

    //Decirle a nuestro TimeUI que registre los eventos de estas 2 variables
    private void OnEnable()
    {
        TimeManager.OnMinuteChanged += UpdateTime;
        TimeManager.OnHourChanged += UpdateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }

    //Recibamos la señal y en este caso ejecutemos la función UpdateTime()
    //Solo se encarga de pintar el texto de la interfaz, con los valores de la hora y minuto 
    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.Hour.ToString("00")}:{TimeManager.Minute:00}";
    }
}
