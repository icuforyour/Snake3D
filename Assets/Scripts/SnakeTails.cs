using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeTails : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    public Snake Snake;
       
    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    public TextMeshProUGUI PointsCountText;

    public AudioSource eatSound;
    public AudioClip damageSound;
      
    private void Awake()
    {
        positions.Add(SnakeHead.position);
        AddCircle();
        eatSound = GetComponent<AudioSource>();
    }

    private void Update()
    {                
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {            
            Vector3 direction = ((Vector3)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }

        if(positions.Count < 1)
            GetComponent<SnakeTails>().enabled = false;
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        PointsCountText.text = positions.Count.ToString();
        eatSound.Play();
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);
        PointsCountText.text = positions.Count.ToString();
        eatSound.PlayOneShot(damageSound);
    }

    public int GetCircleCount()
    {
        return positions.Count;
    }
}
