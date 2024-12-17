using UnityEngine;
using System.Collections;

public class AnxietyReducer : MonoBehaviour
{
    public AnxietyBar anxietyBar; 
    public float reduceAmount = 20f;
    public GameObject showText;

    void Start()
    {
        if (anxietyBar == null)
        {
            Debug.LogError("¡No se ha asignado la referencia a AnxietyBar en AnxietyReducer!");
        }
    }

    public void ReduceAnxiety()
    {
        if (anxietyBar != null)
        {
            anxietyBar.DecreaseAnxiety(reduceAmount);
            showText.SetActive(true);
            StartCoroutine(HideShowTextAfterDelay());
        }
    }
    private IEnumerator HideShowTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);

        showText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item")) 
        {
            ReduceAnxiety();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("objective"))
        {
            Destroy(other.gameObject);
        }
    }
}
