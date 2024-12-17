using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform startPoint; // Posici��n inicial
    public Transform endPoint;   // Posici��n final
    public float moveSpeed = 2f; // Velocidad del movimiento
    public GameObject Tuto;


    private bool isMoving = false; // Controla si el objeto est�� movi��ndose
    private bool moveToEnd = true; // Alterna entre la posici��n inicial y final
    private float t = 0;           // Par��metro del Lerp

    void Update()
    {
        // Detecta si se presiona la tecla 'M'
        if (Input.GetKeyDown(KeyCode.M) && !isMoving)
        {
            Tuto.SetActive(false);
            isMoving = true; // Iniciar el movimiento
            t = 0;           // Reiniciar el progreso del movimiento
        }

        // Si el movimiento est�� activo
        if (isMoving)
        {
            // Determinar la posici��n de inicio y fin seg��n la direcci��n
            Transform targetStart = moveToEnd ? startPoint : endPoint;
            Transform targetEnd = moveToEnd ? endPoint : startPoint;

            // Interpolaci��n lineal entre las posiciones
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(targetStart.position, targetEnd.position, t);

            // Si el movimiento ha terminado
            if (t >= 1)
            {
                isMoving = false;      // Detener el movimiento
                moveToEnd = !moveToEnd; // Alternar la direcci��n del movimiento
                t = 0;                 // Reiniciar el valor de Lerp
            }
        }
    }
}
