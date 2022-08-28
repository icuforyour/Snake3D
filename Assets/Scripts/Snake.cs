using TMPro;
using UnityEngine;


public class Snake : MonoBehaviour
{
    public float Sensitivity;
    
    public GameField GameField;

    public GameLogic Logic;
                
    private Rigidbody snake;
                
    public float Speed;

    private void Start()
    {        
        snake = GetComponent<Rigidbody>();
    }
   
    private void FixedUpdate()
    {
        snake.velocity = new Vector3(0, 0, Speed);
        
        if (Input.GetKey(KeyCode.A))
        {
            snake.velocity += new Vector3(-Speed * Sensitivity, 0, 0);
            
            if(snake.position.x < - GameField.XSize)
               snake.position = new Vector3(-GameField.XSize, snake.position.y, snake.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            snake.velocity += new Vector3(Speed * Sensitivity, 0, 0);

            if (snake.position.x > GameField.XSize)
                snake.position = new Vector3(GameField.XSize, snake.position.y, snake.position.z);
        }
    }

    public void ReachFinish()
    {
        snake.velocity = Vector3.zero;
        Debug.Log("Snake is won");
        Logic.OnSnakeRichedFinish();
    }

    public void Die()
    {
        snake.velocity = Vector3.zero;
        Debug.Log("Snake is died");
        Logic.OnSnakeDied();
    }
}