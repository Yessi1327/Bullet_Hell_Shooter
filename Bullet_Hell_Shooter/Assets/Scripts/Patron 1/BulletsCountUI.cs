using UnityEngine;
using TMPro;

public class BulletsCountUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    void Update()
    {
        if (BulletPool.Instance != null)
        {
            counterText.text = $"Bullets Boss: {BulletPool.Instance.ActiveBullets}";
        }
        else
        {
            counterText.text = "Bullets Boss: 0";
        }
    }
}
