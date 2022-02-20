using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    [SerializeField] GameObject missile;
    
    float cooldown;
    
    void Update()
    {
        BoosShoot();
    }

    void BoosShoot()
    {
        cooldown += Time.deltaTime;

        if (cooldown >= 2)
        {
            
            Instantiate(missile, transform.position, Quaternion.identity);
            cooldown = 0;
        }
    }
}
