using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform leftEnd;
    public Transform rightEnd;

    public GameObject dynamicPlatform;

    public float distanceDelta;
    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget=rightEnd.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dynamicPlatform.transform.position.x==rightEnd.position.x){
            currentTarget=leftEnd.transform.position;
        }

        if(dynamicPlatform.transform.position.x==leftEnd.position.x){
            currentTarget=rightEnd.transform.position;
        }

        dynamicPlatform.transform.position=Vector3.MoveTowards(dynamicPlatform.transform.position,currentTarget,distanceDelta*Time.deltaTime);
    }
}
