using UnityEngine;

// Этот скрипт гарантирует, что правила твоего мира не будут искажать ГГ
public class FixScale : MonoBehaviour
{
    void Update()
    {
        // Vector3.one — это сокращение для (1, 1, 1)
        if (transform.localScale != Vector3.one)
        {
            transform.localScale = Vector3.one;
            
            // Если ты хочешь видеть в консоли, когда мир пытается тебя "сломать"
            // Debug.Log("Попытка искажения масштаба предотвращена!");
        }
    }
}