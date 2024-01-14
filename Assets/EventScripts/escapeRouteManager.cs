using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeRouteManager : MonoBehaviour
{
    Vector3[,] targetPointList;
    void InitializeTargetPointList()
    {
        targetPointList = new Vector3[,]
        {
            {new Vector3(9999f, 9999f, 9999f), new Vector3(9999f, 9999f, 9999f), new Vector3(0f, 0f, 0f)},
            {new Vector3(-7.797577f, 0.06f, 4.28f), new Vector3(-10.65f, 0.06f, 4.28f), new Vector3(-10.65f, 0.06f, Random.Range(-1.6f, 1.6f))},
            {new Vector3(-0.9175768f,0.06f,4.28f),new Vector3(-3.57f,0.06f,4.28f),new Vector3(-3.57f, 0.06f, Random.Range(-1.6f, 1.6f))},
            {new Vector3(-7.967577f,0.06f,-4.28f),new Vector3(-10.65f,0.06f,-4.28f),new Vector3(-10.65f, 0.06f, Random.Range(-1.6f, 1.6f))},
            {new Vector3(-0.89f,0.06f,-4.28f),new Vector3(-3.57f,0.06f,-4.28f),new Vector3(-3.57f,0.06f, Random.Range(-1.6f, 1.6f))}
        };
    }
    public Vector3 targetPositionProvider(int employeeNumber,int timesReachTargetPosition)
    {
        return targetPointList[employeeNumber,timesReachTargetPosition];
    }
    void Start()
    {
        InitializeTargetPointList();
    }
}