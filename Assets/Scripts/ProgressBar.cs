using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Snake Snake;
    public Slider slider;
   
    public Transform Finish;

    private float _startY;
    
    void Start()
    {
        _startY = Snake.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float _finishY = Finish.transform.position.z;
        float t = Mathf.InverseLerp(_startY, _finishY, Snake.transform.position.z);

        slider.value = t;
    }
}

