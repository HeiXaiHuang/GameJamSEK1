using UnityEngine;
using UnityEngine.UI;

public class AnxietyBar : MonoBehaviour
{
    public Slider anxietySlider; // Referencia a la barra de ansiedad (Slider)
    public float fillSpeed = 10f; // Velocidad a la que la barra se llena
    public float maxAnxiety = 100f; // Nivel m�ximo de ansiedad
    private float currentAnxiety = 0f; // Nivel actual de ansiedad

    private bool isFilling = false; // Controla si la barra debe llenarse

    void Start()
    {
        // Inicializa el Slider
        if (anxietySlider != null)
        {
            anxietySlider.maxValue = maxAnxiety;
            anxietySlider.value = currentAnxiety;
        }
    }

    void Update()
    {
        // L�gica para llenar la barra lentamente
        
        currentAnxiety += fillSpeed * Time.deltaTime;
        anxietySlider.value = currentAnxiety;
        

        // Si la barra est� llena, det�n el llenado
        if (currentAnxiety >= maxAnxiety)
        {
            isFilling = false;
            Debug.Log("�La ansiedad est� al m�ximo!");
        }
    }

    // Llamar a este m�todo para iniciar el llenado de la barra
    public void StartFilling()
    {
        isFilling = true;
    }
        // Llamar a este m�todo para reducir ansiedad (opcional)
    public void DecreaseAnxiety(float amount)
    {
        currentAnxiety -= amount;
        if (currentAnxiety < 0) currentAnxiety = 0;
        anxietySlider.value = currentAnxiety;
    }
}
