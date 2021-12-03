using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerHealth health;
    [SerializeField] Slider slider;

    

    // Update is called once per frame
    void Update()
    {
        slider.value = health.health;
    }
}
