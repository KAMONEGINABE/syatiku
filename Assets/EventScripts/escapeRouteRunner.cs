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
    int timesReachTargetPosition;
    bool alreadyCorrected;///employeeNumber5と8の社員だけ、中継地点0を無視して進行する必要があるため、そのチェック用。
    Vector3 targetPosition = new Vector3(0f, 0f, 0f);
    private int roomNumber(int employeeNumber)///左上なら1,右上なら2,左下なら3,右下なら4
    {
        if(employeeNumber<=2){return 1;}
        else if(employeeNumber<=4){return 2;}
        else if(employeeNumber<=7){return 3;}
        else if(employeeNumber<=10){return 4;}
        else{return 0;}
    }
    void Start()
    {
        scriptManager = GameObject.Find("scriptManager");
        escapeRouteManager = scriptManager.GetComponent<escapeRouteManager>();
        statusManager = scriptManager.GetComponent<statusManager>();
        employeeStatusTransceiver = this.gameObject.GetComponent<employeeStatusTransceiver>();
        timesReachTargetPosition = 0;
    }
    void Update()
    {
        if (statusManager.employeeStatusDataList[employeeStatusTransceiver.EmployeeNumber].checkEscaping())
        {

            targetPosition = escapeRouteManager.targetPositionProvider(roomNumber(employeeStatusTransceiver.EmployeeNumber), timesReachTargetPosition);
            baseSpeed = statusManager.employeeStatusDataList[employeeStatusTransceiver.EmployeeNumber].speed;

            if(employeeStatusTransceiver.EmployeeNumber == 5  && timesReachTargetPosition == 0)
            {
                targetPosition.x = -9.6f;
            }
            if(employeeStatusTransceiver.EmployeeNumber == 8  && timesReachTargetPosition == 0)
            {
                targetPosition.x = -3.0f;
            }

            Vector3 targetDistance = this.gameObject.transform.position - targetPosition;

            if (Mathf.Abs(targetDistance.x) <= 0.03 && Mathf.Abs(targetDistance.z) <= 0.03)
            {
                timesReachTargetPosition++;
                print("timesReachTargetPosition:"+timesReachTargetPosition);
                targetPosition = escapeRouteManager.targetPositionProvider(roomNumber(employeeStatusTransceiver.EmployeeNumber), timesReachTargetPosition);
                print("更新　"+targetPosition);
            }
            else
            {
                if
                (Mathf.Abs(targetDistance.x) >= 0.03 && Mathf.Abs(targetDistance.z) >= 0.03)
                {
                    calculatedSpeed = baseSpeed / 2.0f; ///斜め移動をする際はx,zの両方にspeedを+＝するので、片側の移動速度を半分に
                    print("斜め移動中　"+calculatedSpeed);
                }
                else { calculatedSpeed = baseSpeed; }

                if (this.gameObject.transform.position.x < targetPosition.x)///xを加減算するのはココ
                {
                    Vector3 calculatedPosition = this.gameObject.transform.position;
                    calculatedPosition.x += calculatedSpeed * Time.deltaTime;
                    this.gameObject.transform.position = calculatedPosition;
                }
                else if (this.gameObject.transform.position.x > targetPosition.x)
                {
                    Vector3 calculatedPosition = this.gameObject.transform.position;
                    calculatedPosition.x -= calculatedSpeed * Time.deltaTime;
                    this.gameObject.transform.position = calculatedPosition;
                }

                if (this.gameObject.transform.position.z < targetPosition.z)///zを加減算するのはココ
                {
                    Vector3 calculatedPosition = this.gameObject.transform.position;
                    calculatedPosition.z += calculatedSpeed * Time.deltaTime;
                    this.gameObject.transform.position = calculatedPosition;
                }
                else if (this.gameObject.transform.position.z > targetPosition.z)
                {
                    Vector3 calculatedPosition = this.gameObject.transform.position;
                    calculatedPosition.z -= calculatedSpeed * Time.deltaTime;
                    this.gameObject.transform.position = calculatedPosition;
                }
            }

            if (this.gameObject.transform.position.z >= -1.7 && this.gameObject.transform.position.z <= 1.7)///通路(-1.7<Z<1.7)に居る状態では、常にXにspeed分、加算を行い続ける
            {
                Vector3 calculatedPosition = this.gameObject.transform.position;
                calculatedPosition.x += calculatedSpeed * Time.deltaTime * 2;///(上でついてる-x方向の進行を相殺するために*2をつけてる)
                this.gameObject.transform.position = calculatedPosition;
            }
        }
    }
}
