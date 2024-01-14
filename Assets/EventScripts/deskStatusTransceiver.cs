using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; 
using UnityEngine;

public class deskStatusTrans : MonoBehaviour
{
    [SerializeField]private int employeeNumber;
    bool isEscaping;
    GameObject scriptManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scriptManager = GameObject.Find("scriptManager");
        statusManager statusManager = scriptManager.GetComponent<statusManager>();

        isEscaping = statusManager.employeeStatusDataList[employeeNumber].checkEscaping();
        if(isEscaping)
        {
            CustomEvent.Trigger(this.gameObject,"Kieru");
        }
    }
}
