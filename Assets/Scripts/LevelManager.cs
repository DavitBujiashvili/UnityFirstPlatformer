using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;

    private int coinCount;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>();
    }

    public void Respawn(){
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo(){
        yield return new WaitForSeconds(waitToRespawn);
        player.Respawn();
    }

    public void CollectCoin(int CoinWeight){
        coinCount+=CoinWeight;
    }
}
