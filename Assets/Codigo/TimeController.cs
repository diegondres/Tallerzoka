using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI time;
    private float timer = 0;
    public Prota prota;
    public EnergiaController energiaController;
    private float multiplierSpeed = 0;
    public float multiplierFactor = 0.022f;
    void Update()
    {
        if (prota == null) return;
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (Mathf.FloorToInt(timer) > Mathf.FloorToInt(timer - Time.deltaTime))
        {
            energiaController.UpdateEnergy(-1);
        }
        if ((int)timer % 10 == 0)
        {
            multiplierSpeed++;
        }
    }

    public float GetMultiplier() => 1 + multiplierSpeed * multiplierFactor;
}
