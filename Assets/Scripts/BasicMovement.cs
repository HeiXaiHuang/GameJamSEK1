using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float crouchSpeed = 2.5f; // Velocidad de movimiento al agacharse
    public float crouchHeight = 1f; // Altura al agacharse

    private bool isCrouching = false; // Estado de agachado
    private CapsuleCollider capsuleCollider; // Referencia al colisionador del jugador
    private float originalHeight; // Altura original del colisionador
    private Vector3 originalCenter; // Centro original del colisionador

    private void Start()
    {
        // Inicializar el colisionador y guardar el tamaño original
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            originalHeight = capsuleCollider.height;
            originalCenter = capsuleCollider.center;
        }
    }

    private void Update()
    {
        // Obtener la entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Verificar si se presiona el botón de agacharse
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching; // Alternar el estado de agachado

            // Cambiar el tamaño del colisionador
            if (capsuleCollider != null)
            {
                if (isCrouching)
                {
                    capsuleCollider.height = crouchHeight;
                    capsuleCollider.center = new Vector3(0, crouchHeight / 2, 0);
                }
                else
                {
                    capsuleCollider.height = originalHeight;
                    capsuleCollider.center = originalCenter;
                }
            }
        }

        // Determinar la velocidad actual
        float currentSpeed = isCrouching ? crouchSpeed : moveSpeed;

        // Mover el objeto directamente
        transform.Translate(new Vector3(horizontal, 0f, vertical) * currentSpeed * Time.deltaTime);
    }
}
