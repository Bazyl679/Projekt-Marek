using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePointF;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float fireForce = 20f;

    [SerializeField] Transform playerSprite;

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1f)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (playerSprite.eulerAngles.z <= 90 || playerSprite.eulerAngles.z >= 280)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        }
        else if (playerSprite.eulerAngles.z >= 90 || playerSprite.eulerAngles.z > 280)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePointF.position, firePointF.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        }
    }
}
