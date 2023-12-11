using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_instance_test : MonoBehaviour
{

    public static class MyInput
    {
        static bool isCheck_Input;
        static bool preventContinuityInput;

        static float buttonDownTime;
        static float timer;


        /// <summary>
        /// Simultaneous input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool MyInputKeyDown(KeyCode key)
        {
            if (Input.anyKeyDown == false) isCheck_Input = false;

            if (isCheck_Input == false)
            {
                if (Input.GetKeyDown(key))
                {
                    isCheck_Input = true;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continuity input prohibited
        /// </summary>
        /// <param name="key"></param>
        /// <param name="intervalSeconds"></param>
        /// <returns></returns>
        public static bool MyInputKeydown(KeyCode key, float intervalSeconds)
        {
            timer = Time.time;

            if (Input.GetKeyDown(key) && timer - buttonDownTime >= intervalSeconds)
            {
                if (preventContinuityInput == false)
                {
                    preventContinuityInput = true;
                    buttonDownTime = Time.time;
                    return true;
                }
                else if (preventContinuityInput)
                {
                    preventContinuityInput = false;
                    buttonDownTime = Time.time;
                    return true;
                }
            }

            return false;
        }
    }

    

    public class KeyData
    {
        public string keyName;
        public KeyCode anyKeyCode;
        public Vector3 keyPosition;

        public KeyData(string newKeyName,KeyCode newAnyKeyCode,Vector3 newKeyPosition)
        {
            keyName = newKeyName;
            anyKeyCode = newAnyKeyCode;
            keyPosition = newKeyPosition;
        }
    }

        KeyData key_justNowPressed = new KeyData( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
        KeyData key_oneTimeAgoPressed = new KeyData( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
        KeyData key_twoTimeAgoPressed = new KeyData( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
        KeyData key_threeTimeAgoPressed = new KeyData( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
        ///<summary>
        ///key_justNowPressedはUpdate_KeyMemory内でのみ使う。キーが入力されたらまず最初にUpdate_KeyMemoryを実行して、key_oneTimeAgoPressedにデータを移してから、そちらを参照すること。
        ///</summary>

    void Update_KeyMemory()
    {
        key_threeTimeAgoPressed = key_twoTimeAgoPressed;
        key_twoTimeAgoPressed = key_oneTimeAgoPressed;
        key_oneTimeAgoPressed = key_justNowPressed;
        print(key_oneTimeAgoPressed);
    }

    List<KeyData> KeyDataList = new List<KeyData>();

    void Start()
    {
        
        KeyDataList.Add( new KeyData( "Z",KeyCode.Z,new Vector3(-6.7f,0.5f,-1.9f)));
        KeyDataList.Add( new KeyData( "X",KeyCode.X,new Vector3(-5.4f,0.5f,-1.9f)));
        KeyDataList.Add( new KeyData( "C",KeyCode.C,new Vector3(-4.1f,0.5f,-1.9f)));
        KeyDataList.Add( new KeyData( "V",KeyCode.V,new Vector3(-2.8f,0.5f,-1.9f)));
        KeyDataList.Add (new KeyData( "B", KeyCode.B, new Vector3(-1.5f, 0.5f, -1.9f)));
        KeyDataList.Add( new KeyData( "N", KeyCode.N, new Vector3(-0.2f, 0.5f, -1.9f)));
        KeyDataList.Add( new KeyData( "M", KeyCode.M, new Vector3(1.1f, 0.5f, -1.9f)));
        KeyDataList.Add( new KeyData( "A", KeyCode.A, new Vector3(-7.3f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "S", KeyCode.S, new Vector3(-6.04f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "D", KeyCode.D, new Vector3(-4.78f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "F", KeyCode.F, new Vector3(-3.52f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "G", KeyCode.G, new Vector3(-2.26f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "H", KeyCode.H, new Vector3(-1f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "J", KeyCode.J, new Vector3(0.26f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "K", KeyCode.K, new Vector3(1.52f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "L", KeyCode.L, new Vector3(2.78f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "Q", KeyCode.Q, new Vector3(-7.95f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "W", KeyCode.W, new Vector3(-6.68f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "E", KeyCode.E, new Vector3(-5.41f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "R", KeyCode.R, new Vector3(-4.14f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "T", KeyCode.T, new Vector3(-2.87f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "Y", KeyCode.Y, new Vector3(-1.6f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "U", KeyCode.U, new Vector3(-0.33f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "I", KeyCode.I, new Vector3(0.94f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "O", KeyCode.O, new Vector3(2.21f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "P", KeyCode.P, new Vector3(3.48f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( "1", KeyCode.Alpha1, new Vector3(-8.5f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "2", KeyCode.Alpha2, new Vector3(-7.25f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "3", KeyCode.Alpha3, new Vector3(-6f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "4", KeyCode.Alpha4, new Vector3(-4.75f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "5", KeyCode.Alpha5, new Vector3(-3.5f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "6", KeyCode.Alpha6, new Vector3(-2.25f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "7", KeyCode.Alpha7, new Vector3(-1f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "8", KeyCode.Alpha8, new Vector3(0.25f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "9", KeyCode.Alpha9, new Vector3(1.5f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "0", KeyCode.Alpha0, new Vector3(2.75f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "-", KeyCode.Minus, new Vector3(4f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( "^", KeyCode.Caret, new Vector3(5.25f, 0.5f, 1.25f)));
        KeyDataList.Add( new KeyData( ";", KeyCode.Semicolon, new Vector3(4.04f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( ":", KeyCode.Colon, new Vector3(5.3f, 0.5f, -0.87f)));
        KeyDataList.Add( new KeyData( "@", KeyCode.At, new Vector3(4.75f, 0.5f, 0.16f)));
        KeyDataList.Add( new KeyData( ",", KeyCode.Comma, new Vector3(2.4f, 0.5f, -1.9f)));
        KeyDataList.Add( new KeyData( ".", KeyCode.Period, new Vector3(3.7f, 0.5f, -1.9f)));
        KeyDataList.Add( new KeyData( "/", KeyCode.Slash, new Vector3(5f, 0.5f, -1.9f)));

    }

    // Update is called once per frame
    void Update()
    {
        
         if (MyInput.MyInputKeyDown(KeyCode.Z))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Z );
        }
         if (MyInput.MyInputKeyDown(KeyCode.X))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.X );
        }
         if (MyInput.MyInputKeyDown(KeyCode.C))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.C );
        }
         if (MyInput.MyInputKeyDown(KeyCode.V))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.V );
        }
         if (MyInput.MyInputKeyDown(KeyCode.B))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.B );
        }
         if (MyInput.MyInputKeyDown(KeyCode.N))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.N );
        }
         if (MyInput.MyInputKeyDown(KeyCode.M))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.M );
        }
         if (MyInput.MyInputKeyDown(KeyCode.A))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.A );
        }
         if (MyInput.MyInputKeyDown(KeyCode.S))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.S );
        }
         if (MyInput.MyInputKeyDown(KeyCode.D))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.D );
        }
         if (MyInput.MyInputKeyDown(KeyCode.F))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.F );
        }
         if (MyInput.MyInputKeyDown(KeyCode.G))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.G );
        }
         if (MyInput.MyInputKeyDown(KeyCode.H))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.H );
        }
         if (MyInput.MyInputKeyDown(KeyCode.J))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.J );
        }
         if (MyInput.MyInputKeyDown(KeyCode.K))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.K );
        }
         if (MyInput.MyInputKeyDown(KeyCode.L))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.L );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Q))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Q );
        }
         if (MyInput.MyInputKeyDown(KeyCode.W))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.W );
        }
         if (MyInput.MyInputKeyDown(KeyCode.E))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.E );
        }
         if (MyInput.MyInputKeyDown(KeyCode.R))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.R );
        }
         if (MyInput.MyInputKeyDown(KeyCode.T))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.T );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Y))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Y );
        }
         if (MyInput.MyInputKeyDown(KeyCode.U))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.U );
        }
         if (MyInput.MyInputKeyDown(KeyCode.I))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.I );
        }
         if (MyInput.MyInputKeyDown(KeyCode.O))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.O );
        }
         if (MyInput.MyInputKeyDown(KeyCode.P))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.P );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha1))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha1 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha2))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha2 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha3))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha3 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha4))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha4 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha5))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha5 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha6))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha6 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha7))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha7 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha8))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha8 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha9))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha9 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha0))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Alpha0 );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Minus))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Minus );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Caret))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Caret );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Semicolon))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Semicolon );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Colon))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Colon );
        }

         if (MyInput.MyInputKeyDown(KeyCode.At))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.At );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Comma))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Comma );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Period))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Period );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Slash))
        {
            key_justNowPressed = KeyDataList.Find( key => key.anyKeyCode == KeyCode.Slash );
        }
        //trueじゃなければHPマイナス
        if (MyInput.MyInputKeydown(KeyCode.Space, 1 / 2))
        {
            print("3秒待つと押せるよ");
        }
        if (Input.anyKeyDown)
        {
            Update_KeyMemory();
        }
    }
}