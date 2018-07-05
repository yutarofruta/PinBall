using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    private int score;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;

    // Use this for initialization
    void Start() {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
        this.gameoverText.GetComponent<Text>().text = "";
        this.scoreText.GetComponent<Text>().text = "SCORE: 0";

        score = 0;

    }

    // Update is called once per frame
    void Update() {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "GAME OVER";
        }
        this.scoreText.GetComponent<Text>().text = "SCORE: " + score;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "LargeCloudTag") {
            score += 20;
        }
        else if (collision.gameObject.tag == "SmallCloudTag") {
            score += 15;
        }
        else if (collision.gameObject.tag == "LargeStarTag") {
            score += 10;
        }
        else if (collision.gameObject.tag == "SmallStarTag"){
            score += 5;
        }
    }
}
