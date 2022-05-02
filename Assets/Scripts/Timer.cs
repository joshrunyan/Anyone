using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Slider timeSlider;
    public Gradient gradient;
    public float gameTime;
    public Image fill;

    private float actionTime;
    private bool endTime;
    private float fillAmount;

    

    // Start is called before the first frame update
    void Start()
    {
        endTime = false;
        timeSlider.maxValue = gameTime;
        timeSlider.value = gameTime;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleTime();
    }

    private void HandleTime()
    {
        float time = gameTime - Time.time;
        //float time = gameTime - actionTime; (this will be used after testing is finished)

        if(timeSlider.value <= 0) //this line will need to be changed to fit the action based time thing
        {
            endTime = true;
        }
        if(endTime == false)
        {
            timeSlider.value = time;
        }

        fill.color = gradient.Evaluate(timeSlider.normalizedValue);
    }

}
