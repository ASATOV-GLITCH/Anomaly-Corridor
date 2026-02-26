using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    [Header("Настройки")]
    public Transform playerTransform; // Перетащим сюда игрока вручную
    public float interactionDistance = 5f;
    public float autoCloseDelay = 5f;

    [Header("Вращение")]
    public float openAngle = 90f;
    public float smooth = 3f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private AudioSource audioSource;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
        audioSource = GetComponent<AudioSource>();
        
        // Если забыл перетащить игрока, скрипт попробует найти его сам
        if (playerTransform == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) playerTransform = p.transform;
        }
    }

    void Update()
    {
        // Плавное вращение
        Quaternion target = isOpen ? openRotation : closedRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Если игрок назначен — проверяем расстояние
            if (playerTransform != null)
            {
                float dist = Vector3.Distance(playerTransform.position, transform.position);
                if (dist <= interactionDistance)
                {
                    ToggleDoor();
                }
            }
            else
            {
                // Если игрока НЕТ, просто пишем ошибку в консоль, чтобы ты знал
                Debug.LogError("Ойбек, ты забыл перетащить Игрока в поле Player Transform на двери!");
            }
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (audioSource != null) audioSource.Play();

        if (isOpen) StartCoroutine(AutoCloseTimer());
    }

    IEnumerator AutoCloseTimer()
    {
        yield return new WaitForSeconds(autoCloseDelay);
        if (isOpen) // Закрываем, только если она всё еще открыта
        {
            isOpen = false;
            if (audioSource != null) audioSource.Play();
        }
    }
}