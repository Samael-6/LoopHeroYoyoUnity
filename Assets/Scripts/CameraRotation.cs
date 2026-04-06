using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraLook : MonoBehaviour
{
    [Header("Paramètres de la caméra")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // Verrouille le curseur au centre de l'écran
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation verticale (haut/bas) — on limite pour ne pas se retourner
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Applique la rotation verticale à la caméra
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotation horizontale (gauche/droite) — on tourne tout le joueur
        playerBody.Rotate(Vector3.up * mouseX);
        
        if(SceneManager.GetActiveScene().name == "LoopHeroMap")
        {
            Cursor.lockState = CursorLockMode.None; // Libère le curseur
        }
        if(SceneManager.GetActiveScene().name == "Labyrinthe")
        {
            Cursor.lockState = CursorLockMode.Locked; // Verrouille le curseur
        }

    }
}