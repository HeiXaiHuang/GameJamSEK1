using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithOption : MonoBehaviour
{
    public string targetTag = "Player"; // Tag del objeto que activa la acci車n
    public string sceneName = "NextScene"; // Nombre de la escena a cargar
    public bool useTrigger = true; // Cambiar a true para usar Trigger o false para usar un bot車n
    public KeyCode actionKey = KeyCode.E; // Tecla para cambiar de escena si no es Trigger

    private bool isPlayerInTrigger = false; // Controla si el jugador est芍 en el Trigger

    private void Update()
    {
        // Si no usamos Trigger, se permite usar un bot車n para cambiar de escena
        if (!useTrigger && isPlayerInTrigger && Input.GetKeyDown(actionKey))
        {
            ChangeScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (useTrigger && other.CompareTag(targetTag))
        {
            // Cambiar de escena directamente si est芍 configurado para usar Trigger
            ChangeScene();
        }
        else if (!useTrigger && other.CompareTag(targetTag))
        {
            // Si no es Trigger, marcamos que el jugador est芍 en el Trigger
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!useTrigger && other.CompareTag(targetTag))
        {
            // Si el jugador sale del Trigger, ya no puede usar el bot車n
            isPlayerInTrigger = false;
        }
    }

    private void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
}
