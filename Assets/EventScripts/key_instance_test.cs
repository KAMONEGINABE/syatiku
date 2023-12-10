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
        public Vector3 keyPositon;

        public KeyData(string newKeyName,KeyCode newAnyKeyCode,Vector3 newKeyPosition)
        {
            keyName = newKeyName;
            anyKeyCode = newAnyKeyCode;
            KeyPosition = newKeyPosition;
        }
    }

    List<KeyData> KeyDataList = new List<KeyData>();
    KeyList.Add( new KeyData( "Z",KeyCode.Z,new Vector3(-6.7f,0.5f,-1.9f)));
    KeyList.Add( new KeyData( "X",KeyCode.X,new Vector3(-5.4f,0.5f,-1.9f)));
    KeyList.Add( new KeyData( "C",KeyCode.C,new Vector3(-4.1f,0.5f,-1.9f)));
    KeyList.Add( new KeyData( "V",KeyCode.V,new Vector3(-2.8f,0.5f,-1.9f)));

    
    KeyData key_justNowPressed = new KeyMemory( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );//key_justNowPressedはUpdate_KeyMemory内でのみ使う。キーが入力されたらまず最初にUpdate_KeyMemoryを実行して、key_oneTimeAgoPressedにデータを移してから、そちらを参照すること。
    KeyData key_oneTimeAgoPressed = new KeyMemory( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
    KeyData key_twoTimeAgoPressed = new KeyMemory( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
    KeyData key_threeTimeAgoPressed = new KeyMemory( "Neutral",KeyCode.None,new Vector3(9999f,9999f,9999f) );
    void Update_KeyMemory()
    {
        Key_threeTimeAgoPressed = Key_twoTimeAgoPressed;
        Key_twoTimeAgoPressed = Key_oneTimeAgoPressed;
        Key_oneTimeAgoPressed = Key_justNowPressed;
        print(Key_oneTimeAgoPressed);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MyInput.MyInputKeyDown(KeyCode.Z)) = 
        {
            KeyData foundKeyData = keyList.Find(key => key.anyKeyCode == KeyCode.C);
        }
         if (MyInput.MyInputKeyDown(KeyCode.X))
        {
            key_justNowPressed.overwriteKeyMemory( "X",new Vector3(-5.4f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.C))
        {
            key_justNowPressed.overwriteKeyMemory( "C",new Vector3(-4.1f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.V))
        {
            key_justNowPressed.overwriteKeyMemory( "V",new Vector3(-2.8f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.B))
        {
            key_justNowPressed.overwriteKeyMemory( "B",new Vector3(-1.5f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.N))
        {
            key_justNowPressed.overwriteKeyMemory( "N",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.M))
        {
            key_justNowPressed.overwriteKeyMemory( "M",new Vector3(1.1f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.A))
        {
            key_justNowPressed.overwriteKeyMemory( "A",new Vector3(-7.3f,0.5f,-0.87f) );

        }
         if (MyInput.MyInputKeyDown(KeyCode.S))
        {
            key_justNowPressed.overwriteKeyMemory( "S",new Vector3(-6.04f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.D))
        {
            key_justNowPressed.overwriteKeyMemory( "D",new Vector3(-4.78f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.F))
        {
            key_justNowPressed.overwriteKeyMemory( "F",new Vector3(-3.52f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.G))
        {
            key_justNowPressed.overwriteKeyMemory( "G",new Vector3(-2.26f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.H))
        {
            key_justNowPressed.overwriteKeyMemory( "H",new Vector3(-1f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.J))
        {
            key_justNowPressed.overwriteKeyMemory( "J",new Vector3(0.26f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.K))
        {
            key_justNowPressed.overwriteKeyMemory( "K",new Vector3(1.52f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.L))
        {
            key_justNowPressed.overwriteKeyMemory( "L",new Vector3(2.78f,0.5f,-0.87f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Q))
        {
            key_justNowPressed.overwriteKeyMemory( "Q",new Vector3(-7.95f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.W))
        {
            key_justNowPressed.overwriteKeyMemory( "W",new Vector3(-6.68f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.E))
        {
            key_justNowPressed.overwriteKeyMemory( "E",new Vector3(-5.41f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.R))
        {
            key_justNowPressed.overwriteKeyMemory( "R",new Vector3(-4.14f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.T))
        {
            key_justNowPressed.overwriteKeyMemory( "T",new Vector3(-2.87f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Y))
        {
            key_justNowPressed.overwriteKeyMemory( "Y",new Vector3(-1.6f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.U))
        {
            key_justNowPressed.overwriteKeyMemory( "U",new Vector3(-0.33f,0.5f,0.16f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.I))
        {
            print("I");
            Update_KeyMemory(new Vector3(0.94f,0.5f,0.16f));
            key_justNowPressed.overwriteKeyMemory( "I",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.O))
        {
            print("O");
            Update_KeyMemory(new Vector3(2.21f,0.5f,0.16f));
            key_justNowPressed.overwriteKeyMemory( "O",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.P))
        {
            print("P");
            Update_KeyMemory(new Vector3(3.48f,0.5f,0.16f));
            key_justNowPressed.overwriteKeyMemory( "P",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha1))
        {
            print("1");
            Update_KeyMemory(new Vector3(-8.5f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "1",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha2))
        {
            print("2");
            Update_KeyMemory(new Vector3(-7.25f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "2",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha3))
        {
            print("3");
            Update_KeyMemory(new Vector3(-6f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "3",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha4))
        {
            print("4");
            Update_KeyMemory(new Vector3(-4.75f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "4",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha5))
        {
            print("5");
            Update_KeyMemory(new Vector3(-3.5f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "5",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha6))
        {
            print("6");
            Update_KeyMemory(new Vector3(-2.25f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "6",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha7))
        {
            print("7");
            Update_KeyMemory(new Vector3(-1f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "7",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha8))
        {
            print("8");
            Update_KeyMemory(new Vector3(0.25f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "8",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha9))
        {
            print("9");
            Update_KeyMemory(new Vector3(1.5f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "9",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Alpha0))
        {
            print("0");
            Update_KeyMemory(new Vector3(2.75f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "0",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Minus))
        {
            print("-");
            Update_KeyMemory(new Vector3(4f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "-",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Caret))
        {
            print("^");
            Update_KeyMemory(new Vector3(5.25f,0.5f,1.25f));
            key_justNowPressed.overwriteKeyMemory( "^",new Vector3(-0.2f,0.5f,-1.9f) );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Semicolon))
        {
            print(";");
            Update_KeyMemory(new Vector3(4.04f,0.5f,-0.87f));
            key_justNowPressed.overwriteKeyMemory( ";",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Colon))
        {
            print(":");
            Update_KeyMemory(new Vector3(5.3f,0.5f,-0.87f));
            key_justNowPressed.overwriteKeyMemory( ":",new Vector3(-0.2f,0.5f,-1.9f) );
        }

         if (MyInput.MyInputKeyDown(KeyCode.At))
        {
            print("@");
            Update_KeyMemory(new Vector3(4.75f,0.5f,0.16f));
            key_justNowPressed.overwriteKeyMemory( "N",new Vector3(-0.2f,0.5f,-1.9f) );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Comma))
        {
            print(",");
            Update_KeyMemory(new Vector3(2.4f,0.5f,-1.9f));
            key_justNowPressed.overwriteKeyMemory( "N",new Vector3(-0.2f,0.5f,-1.9f) );
        }
         if (MyInput.MyInputKeyDown(KeyCode.Period))
        {
            print(".");
            Update_KeyMemory(new Vector3(3.7f,0.5f,-1.9f));
            key_justNowPressed.overwriteKeyMemory( "N",new Vector3(-0.2f,0.5f,-1.9f) );
        }

         if (MyInput.MyInputKeyDown(KeyCode.Slash))
        {
            print("/");
            Update_KeyMemory(new Vector3(5f,0.5f,-1.9f));
            key_justNowPressed.overwriteKeyMemory( "N",new Vector3(-0.2f,0.5f,-1.9f) );
        }
        //trueじゃなければHPマイナス
        if (MyInput.MyInputKeydown(KeyCode.Space, 1 / 2))
        {
            print("3秒待つと押せるよ");
        }
    }
}
