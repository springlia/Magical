using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Image[] UIhealth;
    public Text UIScore;
    public GameObject RestartButton;
    public int score;
    public float time = 10.0f;
    public PlayerMove player;
    public int HP = 5;

    void Start()
    {
        InvokeRepeating("TimeScore", 0, time);
    }

    void TimeScore()
    {
        if (SceneManager.GetActiveScene().name == "Game_hard")
            score += 10;
    }

    void Update()
    {
        UIScore.text = ("Score: " + score).ToString();
    }

    public void HealthDown()
    {
        if(HP > 1) {
            HP --;
            UIhealth[HP].color = new Color(1,1,1,0.2f);
        }
        else {
            HP = 0;
            UIhealth[0].color = new Color(1,1,1,0.2f);
            player.OnDie();
            RestartButton.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
