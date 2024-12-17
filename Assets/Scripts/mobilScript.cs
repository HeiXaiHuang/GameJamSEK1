using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform startPoint; // Posici車n inicial
    public Transform endPoint;   // Posici車n final
    public float moveSpeed = 2f; // Velocidad del movimiento
    public GameObject Tuto;


    private bool isMoving = false; // Controla si el objeto est芍 movi谷ndose
    private bool moveToEnd = true; // Alterna entre la posici車n inicial y final
    private float t = 0;           // Par芍metro del Lerp

    void Update()
    {
        // Detecta si se presiona la tecla 'M'
        if (Input.GetKeyDown(KeyCode.M) && !isMoving)
        {
            Tuto.SetActive(false);
            isMoving = true; // Iniciar el movimiento
            t = 0;           // Reiniciar el progreso del movimiento
        }

        // Si el movimiento est芍 activo
        if (isMoving)
        {
            // Determinar la posici車n de inicio y fin seg迆n la direcci車n
            Transform targetStart = moveToEnd ? startPoint : endPoint;
            Transform targetEnd = moveToEnd ? endPoint : startPoint;

            // Interpolaci車n lineal entre las posiciones
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(targetStart.position, targetEnd.position, t);

            // Si el movimiento ha terminado
            if (t >= 1)
            {
                isMoving = false;      // Detener el movimiento
                moveToEnd = !moveToEnd; // Alternar la direcci車n del movimiento
                t = 0;                 // Reiniciar el valor de Lerp
            }
        }
    }
}
