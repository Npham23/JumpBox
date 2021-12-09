using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBar : MonoBehaviour
{
    [SerializeField]
    GameObject crowBar;

    public float throwRate; 
    public float nextCrowBar;

    void Start()
    {
        nextCrowBar = Time.time;
    }
    
    void Update()
    {
        throwNewCrowBar();
    }

    void throwNewCrowBar() // throws next crow bar base on time
    {
        if(Time.time > nextCrowBar)
        {
            Instantiate(crowBar, transform.position, Quaternion.identity);
            nextCrowBar = Time.time + throwRate; // base on throw rate
        }
    }
}
