using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    private int amount;
    
    private const int obstacleCount = 20;
    public string PropertyName;
   
    public ParticleSystem ObstacleParticle;
    public SnakeTails SnakeTail;
    public Snake Snake;
    public TextMeshProUGUI AmountText;

    private Renderer obstacleRenderer;
       
    private void Awake()
    {
        SetAmount();

        obstacleRenderer = GetComponent<Renderer>();
        obstacleRenderer.material.SetFloat(PropertyName, amount * 0.05f);
        
    }

    private void Update()
    {
        obstacleRenderer.material.SetFloat(PropertyName, amount * 0.05f);
    }

    private void SetAmount()
    {
        amount = Random.Range(1, obstacleCount);

        SetAmountText();
       
    }

    private void SetAmountText()
    {
        AmountText.text = amount.ToString();
    }
        
    IEnumerator Damage()
    {
        while(amount > 0)
        {
            yield return new WaitForSeconds(0.05f);

            if (SnakeTail.GetCircleCount() > 1 && amount > 0)
            {
                amount--;
                SetAmountText();
                SnakeTail.RemoveCircle();
            }

            if (SnakeTail.GetCircleCount() >= 1 && amount < 1)
            {
                ObstacleParticle.Play();
                Destroy(gameObject);
            }

            if (SnakeTail.GetCircleCount() == 1 && amount > 0)
                Snake.Die();
                        
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.TryGetComponent(out Snake snake)) return;

        StartCoroutine(Damage());
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.collider.TryGetComponent(out Snake snake)) return;

        StopAllCoroutines();
    }
}
