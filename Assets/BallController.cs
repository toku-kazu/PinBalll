using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //得点を表示するテキスト
    public Text scoreText; //Text用変数
    private int score = 0;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
     

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    
    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        score = 0;
        SetScore();   //初期スコアを代入して表示
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        
    }
     void OnCollisionEnter(Collision collision)
    {
        // タグによって得点を変える
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 50;
        }
        else if (collision.gameObject.tag == "SmallCloudTag" || collision.gameObject.tag == "LargeCloudTag")
        {
            score += 5;
        }
            SetScore();
        
    }
    void SetScore()
    {
        scoreText.text = string.Format("Score{0}" , score);
    }
}
