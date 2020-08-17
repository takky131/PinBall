using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoretext;
    public int score = 0;
    // Use this for initialization
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 30;
        }
        else if (other.gameObject.tag == "LargeCloudTag")

        {
            score += 50;
        }
        scoretext.text = score + "ポイント";
    }
}
