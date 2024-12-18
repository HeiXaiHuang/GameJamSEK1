using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas


    // Método para cambiar a una escena específica por su nombre
    


public class AnxietyBar : MonoBehaviour
{
    public Slider anxietySlider;
    public float fillSpeed = 10f;
    public float maxAnxiety = 100f;
    private float currentAnxiety = 0f;
    public GameObject showText;

    private bool isFilling = false;
    public void ChangeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para cambiar a una escena específica por su índice en el Build Settings
    public void ChangeSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // Post-processing variables
    public Volume globalVolume; // Arrastra aquí el Global Volume desde el Inspector
    private ChromaticAberration chromaticAberration;
    private FilmGrain filmGrain;
    private Vignette vignette;

    void Start()
    {
        // Configuración del Slider
        if (anxietySlider != null)
        {
            anxietySlider.maxValue = maxAnxiety;
            anxietySlider.value = currentAnxiety;
        }

        // Acceder a los overrides del Global Volume
        if (globalVolume != null)
        {
            globalVolume.profile.TryGet(out chromaticAberration);
            globalVolume.profile.TryGet(out filmGrain);
            globalVolume.profile.TryGet(out vignette);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("people"))
        {
            isFilling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("people"))
        {
            showText.SetActive(false);
            isFilling = false;
        }
    }

    void Update()
    {
        if (isFilling)
        {
            currentAnxiety += fillSpeed * Time.deltaTime;
            anxietySlider.value = currentAnxiety;
            showText.SetActive(true);

            // Aumentar efectos de postprocesamiento según la ansiedad
            UpdatePostProcessingEffects();
        }

        if (currentAnxiety >= maxAnxiety)
        {
            isFilling = false;
            Debug.Log("¡La ansiedad está al máximo!");












        }
    }

    public void DecreaseAnxiety(float amount)
    {
        currentAnxiety -= amount;
        if (currentAnxiety < 0) currentAnxiety = 0;
        anxietySlider.value = currentAnxiety;

        // Actualizar efectos al disminuir ansiedad
        UpdatePostProcessingEffects();
    }

    private void UpdatePostProcessingEffects()
    {
        // Normalizar ansiedad a un rango de 0 a 1
        float anxietyNormalized = currentAnxiety / maxAnxiety;

        // Ajustar Chromatic Aberration
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.Lerp(0f, 1f, anxietyNormalized); // 0 a 1
        }

        // Ajustar Film Grain
        if (filmGrain != null)
        {
            filmGrain.intensity.value = Mathf.Lerp(0f, 1f, anxietyNormalized); // 0 a 1
        }

        // Ajustar Vignette
        if (vignette != null)
        {
            vignette.intensity.value = Mathf.Lerp(0.2f, 0.8f, anxietyNormalized); // 0.2 a 0.8
        }
    }

}
