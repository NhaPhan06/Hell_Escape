using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill : MonoBehaviour
{
    public Health warrior;

    public Image fillImage;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            Debug.Log("1" + slider.value);
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            Debug.Log("2" +slider.value);
            fillImage.enabled = true;
        }

        float fillValue = warrior.currentHealth / warrior.maxHealth;
        if (fillValue <= slider.maxValue / 3)
        {
            Debug.Log("3" +slider.value);
            fillImage.color = Color.red;
        }
        else if (fillValue > slider.maxValue /3)
        {
            Debug.Log("4" +slider.value);
            fillImage.color = Color.green;
        }

        slider.value = fillValue;
    }
}
