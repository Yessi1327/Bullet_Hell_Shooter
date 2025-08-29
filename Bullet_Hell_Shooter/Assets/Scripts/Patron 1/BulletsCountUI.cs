using UnityEngine;
using TMPro;

public class BulletsCountUI : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    void Update()
    {
        if (BulletPool.Instance != null)
        {
            counterText.text = $"Boss Bullets: {BulletPool.Instance.ActiveBullets}";
        }
        else
        {
            counterText.text = "Boss Bullets: 0";
        }
    }
}
