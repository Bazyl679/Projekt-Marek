using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    [SerializeField] Player dashCooldown;
    [SerializeField] Image image;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = dashCooldown.dashCooldown;
    }
}
