using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BasketBallScore : MonoBehaviour
{

    [SerializeField]
    private Text _basketBallScore;
    int _score;
    // Use this for initialization

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "basket")
        {
            print("得分");
            _score += 3;
            _basketBallScore.text = "" + _score;
        }
    }

}
