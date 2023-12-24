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
        public static bool isTimeLimitReached()
        {
            if(currentTimeSecond >= timeLimitSecond)
            {
                return true;
            }
            else
            {
                return false;
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
        if(timeLimit.isTimeLimitReached())
        {
            var keyInputManager = GameObject.FindObjectOfType<keyInputManager>();
            keyInputManager.enabled = false;
            
            var UIManager = GameObject.FindObjectOfType<UIManager>();
            UIManager.drawResultCanvas();
            print("ゲーム終了！");

            var gameRuleManager = GameObject.FindObjectOfType<gameRuleManager>();
            gameRuleManager.enabled = false;
        }
    }
}