using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartDestroyer : MonoBehaviour
{
    [SerializeField] float PlayerDistance_Destroyer;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + PlayerDistance_Destroyer < player.transform.position.x )
        {
            Destroy(this.gameObject, 0f);
        }
    }
}
