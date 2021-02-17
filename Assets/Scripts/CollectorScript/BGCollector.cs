using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    private GameObject[] Backgrouds;
    private GameObject[] grounds;

    private float LastBGX;
    private float LastGroundX;

    void Awake()
    {
        Backgrouds = GameObject.FindGameObjectsWithTag("Backgrond");

        grounds = GameObject.FindGameObjectsWithTag("Ground");

        LastGroundX  = grounds [0].transform.position.x;

        for(int i=1;i<Backgrouds.Length; i++)
        {
            if(LastBGX < Backgrouds [i].transform .position .x)
            {
                LastBGX = Backgrouds[i].transform.position.x;
            }
        }
        for (int i = 1; i < grounds.Length; i++)
        {
            if (LastGroundX < grounds[i].transform.position.x)
            {
                LastGroundX = grounds[i].transform.position.x;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Trigger Successfuly..");
        Debug.Log(gameObject.name);

        if (target.tag == "Backgrond")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = LastBGX + width;

            target.transform.position = temp;

            LastBGX = temp.x;
        }
       else if (target.tag == "Ground")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = LastGroundX  + width;

            target.transform.position = temp;

            LastGroundX  = temp.x;
        }
    }



    void Update()
    {
        
    }
}
