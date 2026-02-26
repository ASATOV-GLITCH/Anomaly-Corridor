using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [Header("Settings")]
    public bool isOn = false;
    public float batteryLife = 100f;
    public float drainRate = 0.5f;
    public float flickerThreshold = 20f; // Порог мерцания

    [Header("References")]
    public Light flashlightLight; // Сюда перетащи свет фонарика в Unity
    public AudioSource switchSound; // Сюда перетащи звук клика

    void Update()
    {
        // Включение/Выключение на кнопку F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;

            if (switchSound != null)
            {
                switchSound.Play();
            }
        }

        // Логика работы батареи
        if (isOn && batteryLife > 0)
        {
            batteryLife -= drainRate * Time.deltaTime;
            
            // ЛОГИКА МЕРЦАНИЯ
            if (batteryLife < flickerThreshold)
            {
                // Если заряд низкий, свет включается случайно (мерцает)
                flashlightLight.enabled = Random.value > 0.1f;
            }
            else
            {
                flashlightLight.enabled = true;
            }
        }
        else
        {
            // Если выключен или села батарея
            batteryLife = Mathf.Max(batteryLife, 0);
            isOn = false;
            flashlightLight.enabled = false;
        }
    }
}