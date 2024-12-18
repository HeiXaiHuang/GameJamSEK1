using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AnxietyBar : MonoBehaviour
{
    public Slider anxietySlider;
    public float fillSpeed = 10f;
    public float maxAnxiety = 100f;
    private float currentAnxiety = 0f;
    public GameObject showText;

    private bool isFilling = false;

    // Post-processing variables
    public Volume globalVolume; // Arrastra aquí el Global Volume desde el Inspector
    private ChromaticAberration chromaticAberration;
    private FilmGrain filmGrain;
    private Vignette vignette;

    // Efectos iniciales (para mantener y añadir sobre ellos)
    private float initialChromaticAberration = 0f;
    private float initialFilmGrain = 0f;
    private float initialVignette = 0f;

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
            if (globalVolume.profile.TryGet(out chromaticAberration))
            {
                initialChromaticAberration = chromaticAberration.intensity.value;
            }

            if (globalVolume.profile.TryGet(out filmGrain))
            {
                initialFilmGrain = filmGrain.intensity.value;
            }

            if (globalVolume.profile.TryGet(out vignette))
            {
                initialVignette = vignette.intensity.value;
            }
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

        // Ajustar Chromatic Aberration sin reiniciar los valores iniciales
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.Clamp(
                initialChromaticAberration + Mathf.Lerp(0f, 1f, anxietyNormalized * 2f), // Incremento más agresivo
                0f,
                1f
            );
        }

        // Ajustar Film Grain sin reiniciar los valores iniciales
        if (filmGrain != null)
        {
            filmGrain.intensity.value = Mathf.Clamp(
                initialFilmGrain + Mathf.Lerp(0f, 1f, anxietyNormalized * 2f),
                0f,
                1f
            );
        }

        // Ajustar Vignette sin reiniciar los valores iniciales
        if (vignette != null)
        {
            vignette.intensity.value = Mathf.Clamp(
                initialVignette + Mathf.Lerp(0f, 0.8f, anxietyNormalized * 1.5f),
                0f,
                1f
            );
        }
    }
}
