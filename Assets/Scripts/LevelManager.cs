using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;

    private int coinCount;
    public PlayerController player;

    public Text CoinText;

    public Image hart1;

    public Image hart2;

    public Image hart3;

     public Sprite hartFull;

    public Sprite hartHalf;

    public Sprite hartEmpty;

    public int healthCount;

    public int maxHealthCount;
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text="Coins :" + coinCount;
        player=FindObjectOfType<PlayerController>();
        ResetHealth();
    }

    void Update() {
        RedrawHearts(healthCount);
    }

    public void RedrawHearts(int health){
        switch (health)
        {
            case 6:
                hart3.sprite=hartFull;
                hart2.sprite=hartFull;
                hart1.sprite=hartFull;
            break;
            case 5:
                hart3.sprite=hartHalf;
                hart2.sprite=hartFull;
                hart1.sprite=hartFull;
            break;
            case 4:
                hart3.sprite=hartEmpty;
                hart2.sprite=hartFull;
                hart1.sprite=hartFull;
            break;
            case 3:
                hart3.sprite=hartEmpty;
                hart2.sprite=hartHalf;
                hart1.sprite=hartFull;
            break;
            case 2:
                hart3.sprite=hartEmpty;
                hart2.sprite=hartEmpty;
                hart1.sprite=hartFull;
            break;
            case 1:
                hart3.sprite=hartEmpty;
                hart2.sprite=hartEmpty;
                hart1.sprite=hartHalf;
            break;
            default:
                hart3.sprite=hartEmpty;
                hart2.sprite=hartEmpty;
                hart1.sprite=hartEmpty;
                break;
        }

    }

    public void Respawn(){
        StartCoroutine("RespawnCo");
    }

    public void ResetHealth(){
        healthCount=maxHealthCount;
    }

    public IEnumerator RespawnCo(){
        yield return new WaitForSeconds(waitToRespawn);
        player.Respawn();
    }

    public void CollectCoin(int CoinWeight){
        coinCount+=CoinWeight;
        CoinText.text="Coins :" + coinCount;
    }

    public void TakeDamage(int damage){
        healthCount-=damage;
    }
}
