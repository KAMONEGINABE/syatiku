using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeRouteRunner : MonoBehaviour
{
    GameObject scriptManager;
    escapeRouteManager escapeRouteManager;
    statusManager statusManager;
    employeeStatusTransceiver employeeStatusTransceiver;
    float baseSpeed;
    float calculatedSpeed;
    int timesReachTargetPosition = 0;
    Vector3 targetPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        scriptManager = GameObject.Find("scriptManager");
        escapeRouteManager = scriptManager.GetComponent<escapeRouteManager>();
        statusManager = scriptManager.GetComponent<statusManager>();
        employeeStatusTransceiver = this.gameObject.GetComponent<employeeStatusTransceiver>();
    }
    void Update()
    {
        print("EmployeeNumber:"+employeeStatusTransceiver.EmployeeNumber);
    }
}
