using UnityEngine;
using UnityEngine.UI;

public class AnxietyBar : MonoBehaviour
{
    public Slider anxietySlider; 
    public float fillSpeed = 10f; 
    public float maxAnxiety = 100f; 
    private float currentAnxiety = 0f; 

    private bool isFilling = false; 

    void Start()
    {
        if (anxietySlider != null)
        {
            anxietySlider.maxValue = maxAnxiety;
            anxietySlider.value = currentAnxiety;
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
            Debug.Log("GameObject with tag 'YourTagHere' exited the trigger!");
            isFilling = false;
        }
    }
    void Update()
    {
        if (isFilling == true)
        {
            currentAnxiety += fillSpeed * Time.deltaTime;
            anxietySlider.value = currentAnxiety;
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
    }
}