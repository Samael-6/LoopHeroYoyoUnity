using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Paramètres de déplacement")]
    public float speed = 5f;
    public Transform cameraTransform;

    [Header("Paramètres de sprint")]
    public float sprintSpeed = 10f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 20f;   // Par seconde en sprintant
    public float staminaRegenRate = 10f;   // Par seconde au repos
    public float staminaRegenDelay = 1.5f; // Délai avant que la stamina se recharge

    private Rigidbody rb;
    private Vector3 movement;
    private float currentStamina;
    private float regenDelayTimer = 0f;
    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        HandleMovementInput();
        HandleStamina();
    }

    void HandleMovementInput()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.Z)) vertical += 1f;
        if (Input.GetKey(KeyCode.S)) vertical -= 1f;
        if (Input.GetKey(KeyCode.Q)) horizontal -= 1f;
        if (Input.GetKey(KeyCode.D)) horizontal += 1f;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        movement = (forward * vertical + right * horizontal).normalized;
    }

    void HandleStamina()
    {
        bool wantsSprint = Input.GetKey(KeyCode.LeftShift);
        bool isMoving = movement.magnitude > 0f;

        // Sprint actif seulement si on bouge, on appuie sur Shift, et on a de la stamina
        isSprinting = wantsSprint && isMoving && currentStamina > 0f;

        if (isSprinting)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Max(currentStamina, 0f);
            regenDelayTimer = staminaRegenDelay; // Réinitialise le délai
        }
        else
        {
            if (regenDelayTimer > 0f)
            {
                regenDelayTimer -= Time.deltaTime;
            }
            else
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
                currentStamina = Mathf.Min(currentStamina, maxStamina);
            }
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = isSprinting ? sprintSpeed : speed;
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    // Utile pour afficher la stamina dans une UI
    public float GetStaminaPercent() => currentStamina / maxStamina;
}