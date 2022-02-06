using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private LevelManager levelManager;

    public int coinWeight =1;
    void Start()
    {
        levelManager=FindObjectOfType<LevelManager>();

    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
           Destroy(gameObject);
           levelManager.CollectCoin(coinWeight);
        }
    }
}
