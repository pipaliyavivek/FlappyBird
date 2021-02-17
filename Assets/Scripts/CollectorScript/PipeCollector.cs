using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{
   
    private GameObject[] PipeHolders;
    private float Distance = 3.5f;
    private float lastPipeX;
    private float PipeMin= -2.68f;
    private float PipeMax = 2.38f;

     void Awake()
    {
        PipeHolders = GameObject.FindGameObjectsWithTag("Pipe Holder");

        for(int i=0;i < PipeHolders.Length;i++)
        {
            Vector3 temp = PipeHolders[i].transform.position;
            temp.y = Random.Range(PipeMin, PipeMax);
            PipeHolders[i].transform.position = temp;
        }
        lastPipeX = PipeHolders[0].transform.position.x;
        for (int i = 1; i < PipeHolders.Length; i++)
        {
            if(lastPipeX < PipeHolders[i].transform.position.x)
            {
               lastPipeX = PipeHolders[i].transform.position.x;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag =="Pipe Holder")
        {
            Vector3 temp = target.transform.position;
            temp.x = lastPipeX + Distance;
            temp.y = Random.Range(PipeMin, PipeMax);
            target.transform.position = temp;

            lastPipeX = temp.x;
        }
        if (target.tag == "Pipe")
        {
            Debug.Log("pipe Triggerd");
        }
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
