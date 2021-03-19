using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class HungerBar : MonoBehaviour
{
    public RectTransform bar;
    public Slider slider;
    public RectTransform redZone;
    [Range(5,50)]
    public int redPercentage = 30;
    public RectTransform greenZone;
    [Range(5, 50)]
    public int greenPercentage = 25;
    public PostProcessVolume postProcess;
    [Range(0.5f,3.0f)]
    public float desaturationSpeed=1.5f;

    private int offset = 3;
    private float barLength;

    public float basicIncrease = 10;
    private int framePause = 360;
    private int healSpeed = 2;
    private int frameReduction = 200;

    [Range(1,8)]
    public int reductionSpeed = 1;

    public PlayerHealth playerHealth;
    //public int healPercentage = 5;

    private int maxCounter;
    private int reduceCounter;
    private int healCounter;

    // Start is called before the first frame update
    void Start()
    {
        // graphical update
        barLength = bar.rect.width;
        float redLength = ((float)redPercentage) / 100 * barLength;
        redZone.transform.localPosition = new Vector3(-barLength / 2 + redLength / 2 + offset - 1, 0, 0);
        redZone.transform.localScale = new Vector3(((float)redPercentage) / 100, 1, 1);
        float greenLength = ((float)greenPercentage) / 100 * barLength;
        greenZone.transform.localPosition = new Vector3(barLength / 2 - greenLength / 2 - offset + 1, 0, 0);
        greenZone.transform.localScale = new Vector3(((float)greenPercentage) / 100, 1, 1);

        // variable init
        maxCounter = 0;
        reduceCounter = 0;
        healCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float value = slider.value;
        if (maxCounter > framePause)
        {
            if (value > slider.minValue) { reduceBar(); }
        }
        else
        {
            maxCounter++;
        }
        if ((1 - value / slider.maxValue) < (float)greenPercentage/100.0f  || healCounter> frameReduction / reductionSpeed)
        {
            if (healCounter > healSpeed * frameReduction/reductionSpeed)
            {
                healCounter = 0;
                if(playerHealth!=null)playerHealth.Heal(5);
            }
            else
            {
                healCounter++;
            }
        }
    } 

    public void SetMaxHunger(float max)
    {
        slider.maxValue = max;
    }

    public void SetBasicIncrease(int percentage)
    {
        basicIncrease = percentage/100.0f*slider.maxValue;
    }

    public void IncreaseHungerBarCustom(int percentage)
    {
        float increase = (float)percentage / 100.0f * slider.maxValue;
        slider.value = Mathf.Min(slider.maxValue, slider.value + increase);
        maxCounter = 0;
        healCounter = 0;
        postProcess.weight = Mathf.Max(1 - (slider.value / slider.maxValue) / ((float)redPercentage / 100.0f),0);
    }

    public void IncreaseHungerBarBasic()
    {
        slider.value = Mathf.Min(slider.maxValue, slider.value + basicIncrease);
        maxCounter = 0;
        healCounter = 0;
        postProcess.weight = Mathf.Max(1 - (slider.value / slider.maxValue) / ((float)redPercentage / 100.0f),0);
    }

    private void reduceBar()
    {
        if (reduceCounter > frameReduction/reductionSpeed)
        {
            float value = slider.value;
            reduceCounter = 0;
            slider.value = Mathf.Max(slider.minValue, value - 0.01f * slider.maxValue);
            if ((value / slider.maxValue) < (float)redPercentage / 100.0f)
            {
                postProcess.weight = Mathf.Max(1 - (1-desaturationSpeed/10f) * Mathf.Pow((slider.value / slider.maxValue) / ((float)redPercentage / 100.0f),2.0f),0);
            }
        }
        else
        {
            reduceCounter++;
        }
    }

}
