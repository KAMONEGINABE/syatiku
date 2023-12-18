using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusManager : MonoBehaviour
{
    // Start is called before the first frame update
    public class employeeStatus
    {
        int registrationNumber;
        float strength;
        float scoreIncreace;
        int hitPoint;

        public employeeStatus(int newRegistrationNumber,float newStrength)
        {
            registrationNumber = newRegistrationNumber;
            strength = newStrength;
            scoreIncreace = strength;
            hitPoint = (int)strength;
        }
        public void status_justNowEscaped(float newStrength)
        {
            strength = newStrength;
            scoreIncreace = strength;
            hitPoint = (int)strength;
        }
        public bool status_decreaceHitPoint(int damagePoint)
        {
            if ( registrationNumber != 0)
            {
                hitPoint -= damagePoint;
                if (hitPoint <= 0) { return true; }
                else{ return false; }
            }
            else{ return false; }
        }
        public void forDebug_showAllStatus()
        {
            print(registrationNumber);
            print(strength);
            print(scoreIncreace);
            print(hitPoint);
        }
    }

    public employeeStatus[] StatusDataList = new employeeStatus[13];

    void Start()
    {

        for (int employeeNumber = 1; employeeNumber <= 12; employeeNumber++)
        {
            StatusDataList[employeeNumber] = new employeeStatus(employeeNumber,100f);
        }

        void forDebug_showAllEmployeeStatus()
        {
            for (int employeeNumber = 1; employeeNumber <= 12; employeeNumber++)
            {
                print(employeeNumber);
                StatusDataList[employeeNumber].forDebug_showAllStatus();
            }
        }
    }


}
