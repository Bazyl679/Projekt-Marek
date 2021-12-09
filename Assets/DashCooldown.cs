using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    [SerializeField] Player dashCooldown;
    [SerializeField] Image image;

    private void Start()
    {
        image.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        image.fillAmount = dashCooldown.dashCoolCounter;
        
    }
}
