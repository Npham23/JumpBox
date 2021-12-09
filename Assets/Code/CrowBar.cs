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
        throwRate = 1f;
        nextCrowBar = Time.time;
    }
    
    void Update()
    {
        throwNewCrowBar();
    }

    void throwNewCrowBar()
    {
        if(Time.time > nextCrowBar)
        {
            Instantiate(crowBar, transform.position, Quaternion.identity);
            nextCrowBar = Time.time + throwRate;
        }
    }
}
