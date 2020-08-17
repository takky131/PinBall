using UnityEngine;
using System.Collections;
public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    // Use this for initialization
    void Start()
    {

        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);

        Debug.Log("Screen Width : " + Screen.width);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if (t.phase == TouchPhase.Began)
                {
                    if (t.position.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                    {
                        // 左半分の指を押した時
                        SetAngle(this.flickAngle);
                    }
                    else if (t.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                    {
                        // 右半分の指を押した時
                        SetAngle(this.flickAngle);
                    }
                }
                //タッチが離されたときかどうか
                else if (t.phase == TouchPhase.Ended)
                {
                    if (t.position.x < Screen.width * 0.5 && tag == "LeftFripperTag")
                    {
                        // 左半分の指を離した時
                        SetAngle(this.defaultAngle);
                    }
                    else if (t.position.x > Screen.width * 0.5 && tag == "RightFripperTag")
                    {
                        // 右半分の指を離した時
                        SetAngle(this.defaultAngle);
                    }
                }

            }


        }
    }
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
    bool OnTouchDown()
    {
        // タッチされているとき
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if (t.phase == TouchPhase.Began)
                    if (t.position.x < Screen.width * 0.5)
                    {
                        // 左半分の指を押した時
                        SetAngle(this.flickAngle);
                    }
                    else if (t.position.x > Screen.width * 0.5)
                    {
                        // 右半分の指を押した時
                        SetAngle(this.flickAngle);
                    }
                return true;


            }

        }
        return false; //タッチされてなかったらfalse

    }
    bool OnTouchUp()
    {
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチしたときかどうか
                if (t.phase == TouchPhase.Ended)
                    if (t.position.x < Screen.width * 0.5)
                    {
                        // 左半分の指を離した時
                    }
                    else if (t.position.x > Screen.width * 0.5)
                    {
                        // 右半分の指を離した時
                    }
                return true;

            }
        }
        return false; //タッチされてなかったらfalse
    }

}









