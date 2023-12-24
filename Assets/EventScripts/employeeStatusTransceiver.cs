using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class employeeStatusTransceiver : MonoBehaviour
{
    [SerializeField]private int employeeNumber;
    public bool justNowHit;
    public bool destroyed;
    GameObject scriptManager;
    
    public void hitCalculation(int damage)
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();
        
        justNowHit = true;
        destroyed = statusManager.StatusDataList[employeeNumber].status_decreaceHitPoint(damage);
    }
}
