using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnxietyBar : MonoBehaviour
{
    public Slider anxietySlider; 
    public float fillSpeed = 10f; 
    public float maxAnxiety = 100f; 
    private float currentAnxiety = 0f;
    public GameObject showText;

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
            showText.SetActive(false);
            isFilling = false;

        }
    }
    void Update()
    {
        if (isFilling == true)
        {
            currentAnxiety += fillSpeed * Time.deltaTime;
            anxietySlider.value = currentAnxiety;
            showText.SetActive(true);
        }
        
        if (currentAnxiety >= maxAnxiety)
        {
            isFilling = false;
            Debug.Log("¡La ansiedad est?al máximo!");
        }
    }
    public void DecreaseAnxiety(float amount)
    {
        currentAnxiety -= amount;
        if (currentAnxiety < 0) currentAnxiety = 0;
        anxietySlider.value = currentAnxiety;
    }
}