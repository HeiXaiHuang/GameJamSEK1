using UnityEngine;

public class AnxietyReducer : MonoBehaviour
{
    public AnxietyBar anxietyBar; 
    public float reduceAmount = 20f; 

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
            Debug.Log("Ansiedad reducida en: " + reduceAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item")) 
        {
            ReduceAnxiety();
            Destroy(other.gameObject);
            Debug.Log("El jugador ha interactuado y la ansiedad ha bajado.");
        }
        if (other.CompareTag("objective"))
        {
            
            Destroy(other.gameObject);
        }
    }
}
