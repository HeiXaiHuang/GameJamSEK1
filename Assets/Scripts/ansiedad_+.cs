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
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject has the desired tag
        if (other.gameObject.CompareTag("people"))
        {
            isFilling = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("people"))
        {
            Debug.Log("GameObject with tag 'YourTagHere' exited the trigger!");
            // Perform any action when the GameObject leaves the trigger
            isFilling = false;
        }
    }
    void Update()
    {
        // L�gica para llenar la barra lentamente
        if (isFilling == true)
        {
            currentAnxiety += fillSpeed * Time.deltaTime;
            anxietySlider.value = currentAnxiety;
        }
        
        

        // Si la barra est� llena, det�n el llenado
        if (currentAnxiety >= maxAnxiety)
        {
            isFilling = false;
            Debug.Log("�La ansiedad est� al m�ximo!");
        }
    }
}



    // Llamar a este m�todo para iniciar el llenado de la barra
    
        // Llamar a este m�todo para reducir ansiedad (opcional)
    