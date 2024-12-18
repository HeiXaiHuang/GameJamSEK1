using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnButton : MonoBehaviour
{
    public string sceneName = "NextScene"; // Nombre de la escena a cargar

    public void ChangeScene()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
