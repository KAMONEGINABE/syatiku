using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRuleManager : MonoBehaviour
{
    public static class timeLimit
    {
        static float timeLimitSecond; 
        static float currentTimeSecond;
        public static void setupTimeLimit(float newTimeLimitSecond)
        {
            timeLimitSecond = newTimeLimitSecond;
            currentTimeSecond = 0;
            
        }
        public static void updateCurrentTime()
        {
            currentTimeSecond += Time.deltaTime;
        }
        public static void checkTimeLimit()
        {
            if(currentTimeSecond >= timeLimitSecond)
            {
                var keyInputManager = GameObject.FindObjectOfType<keyInputManager>();
                keyInputManager.enabled = false;
                
                print("ゲーム終了！");

                var gameRuleManager = GameObject.FindObjectOfType<gameRuleManager>();
                gameRuleManager.enabled = false;
            }
        }
    }
    [SerializeField]private float timeLimitSecond;

    void Start()
    {
        timeLimit.setupTimeLimit(timeLimitSecond);
    }

    void Update()
    {
        timeLimit.updateCurrentTime();
        timeLimit.checkTimeLimit();
    }
}
