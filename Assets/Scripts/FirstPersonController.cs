using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;
    public float verticalLookLimit = 80f;
    public float footstepInterval = 1.0f;

    private CharacterController controller;
    private float rotationX = 0f;
    private AudioSource footstepAudio;
    private float footstepTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepAudio = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Gravity
        controller.Move(Physics.gravity * Time.deltaTime);

        // Footstep sound with interval
        if ((Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f) && controller.isGrounded)
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer <= 0f)
            {
                footstepAudio.pitch = Random.Range(0.9f, 1.1f);
                footstepAudio.Play();
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            // Player stopped moving: cancel pending footstep
            if (footstepAudio.isPlaying)
                footstepAudio.Stop();

            footstepTimer = footstepInterval;
        }
    }
}
