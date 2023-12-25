using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{

    public static int coinCount;
    public GameObject coinText;
    public GameObject cam;
    

    private void Awake()
    {
        coinText = GameObject.Find("Score");
        cam = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerRunner player = collider.GetComponent<PlayerRunner>();

        if (player != null)
        {

            cam.GetComponent<CoinScore>().point();
            Destroy(gameObject);
            
        }
    }

    public static void ResetCoinCount()
    {
        coinCount = 0;
    }
}
