using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRuleManager : MonoBehaviour
{
    public static class timeLimit
    {
        [SerializeField]static float timeLimitSecond; 
        static float currentTimeSecond;
        static float currentTimeFlame;
        public static void setupCurrentTime()
        {
            currentTimeSecond = 0;
            currentTimeFlame = 0;
            updateInterval_currentTimeSecond = 1000;//ミリ秒で指定
        }
        public static void updateCurrentTime()
        {
            currentTimeFlame += Time.deltaTime;
            currentTimeSecond = currentTimeFlame/60;
        }
        public static void checkTimeLimit()
        {
            if(currentTimeFlame == timeLimitSecond)
            {
                print("ゲーム終了！")
            }
        }
    }

    void Start()
    {
        timeLimit.setupCurrentTime();
    }

    void Update()
    {
        timeLimit.updateCurrentTime();
        timeLimit.checkTimeLimit();
    }
}
