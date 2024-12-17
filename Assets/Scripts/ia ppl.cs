using UnityEngine;

public class NPCFollowPlayer : MonoBehaviour
{
    public float detectionRange = 10f;  // Rango de detecci�n del jugador
    public float moveSpeed = 3f;        // Velocidad de movimiento del PNJ
    public float stopRange = 2f;        // Distancia m�nima al jugador antes de detenerse

    private Transform playerTransform;  // Referencia al transform del jugador

    void Start()
    {
        // Encontrar al jugador por su etiqueta
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'Player'.");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Calcular la distancia entre el PNJ y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Si el jugador est� dentro del rango de detecci�n pero fuera del rango de parada
        if (distanceToPlayer <= detectionRange && distanceToPlayer > stopRange)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // Mover el PNJ hacia el jugador
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Opcional: Hacer que el PNJ mire hacia el jugador
            transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        }
    }
}

