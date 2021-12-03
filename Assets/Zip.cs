using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zip : MonoBehaviour
{

    [SerializeField] public int addPoits = 10;
    [SerializeField] GameObject floatingPointsPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Points();
        Instantiate(floatingPointsPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    public void Points()
    {
        GameObject thePlayer = GameObject.Find("Score");
        Score score = thePlayer.GetComponent<Score>();
        score.currentPoints += addPoits;
    }

}

