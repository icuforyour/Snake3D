using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Eat : MonoBehaviour
{
    public TextMeshProUGUI FoodQualityText;
       
    private int FoodQuality;

    public SnakeTails snakeTail;
               
    public void Awake()
    {
        FoodQuality = Random.Range(1, 6);
        FoodQualityText.text = FoodQuality.ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeTails snakeTail))
        {            
            Destroy(gameObject);
            
            for (int i = 0; i <FoodQuality; i++)
                snakeTail.AddCircle();
        }
    }
}