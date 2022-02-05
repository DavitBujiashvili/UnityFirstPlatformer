using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPointController : MonoBehaviour
{
    public Sprite flagClosed;

    public Sprite flagOpen;

    private SpriteRenderer spriterenderer;

    public bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        spriterenderer=GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            spriterenderer.sprite = flagOpen;
            isActive=true;
        }
    }

}
