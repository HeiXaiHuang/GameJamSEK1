using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento

    private void Update()
    {
        // Obtener la entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Mover el objeto directamente
        transform.Translate(new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime);
    }
}
