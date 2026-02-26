using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float mouseSensitivity = 100f;

    // --- НОВАЯ ПЕРЕМЕННАЯ ДЛЯ ЗВУКА ---
    [Header("Звуковые эффекты")]
    public AudioSource stepsSound; 
    // ----------------------------------

    // Параметры физики
    public float gravity = -19.81f; 
    Vector3 velocity;               
    bool isGrounded;                

    float xRotation = 0f;
    Transform playerCamera;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 60; // Устанавливает лимит в 60 FPS
        playerCamera = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. ПРОВЕРКА ЗЕМЛИ
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        // 2. ПОВОРОТ КАМЕРЫ (МЫШЬ)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // 3. ДВИЖЕНИЕ (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // --- ЛОГИКА ЗВУКА ШАГОВ ---
        // Если мы двигаемся и стоим на земле
        if (isGrounded && (x != 0 || z != 0))
        {
            if (stepsSound != null && !stepsSound.isPlaying)
            {
                stepsSound.Play();
            }
        }
        else
        {
            if (stepsSound != null && stepsSound.isPlaying)
            {
                stepsSound.Stop();
            }
        }
        // --------------------------

        // 4. ПРИМЕНЕНИЕ ГРАВИТАЦИИ
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}


