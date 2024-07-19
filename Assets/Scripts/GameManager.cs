using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;

    public int score = 0;
    public GameObject gamePlayUI;
    public GameObject gameMenu;
    public GameObject gameScore;
    public Text scoreText;
    public Text highScoreText;
    public bool showingResult;
    public Animator anim;
    public int gem;

    private bool isDisable = false;

    public Text finalScore, finalHighScore;

    int highScore;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpdateScore");
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "HighScore : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisable)
        {
            if (gameStarted && Input.GetMouseButtonDown(0))
            {
                score++;
            }
            if (!gameStarted && Input.GetMouseButtonDown(0))
            {
                if (showingResult)
                {
                    StartCoroutine("RestartGame");
                }
                else
                {
                    GameStart();
                }
            }

            if (score % 50 == 0 && score != 0)
            {
                ColorChange.instance.timeLeft = ColorChange.instance.transTime;
                ColorChange.instance.switchColor();
            }

            scoreText.text = score.ToString() + " ";
        }
    }
    public void GameStart()
    {
        AudioController.instance.playTrack(3);
        gameMenu.SetActive(false) ;
        gamePlayUI.SetActive(true);
        gameStarted = true;
        gem = 0;
    }
    public void GameOver()
    {
        AudioController.instance.playTrack(2);
        ShopManager.instance.gem = gem;
        ShopManager.instance.UpdateGem();
        isDisable = true;
        gameStarted = false;
        StopCoroutine("UpdateScore");
        SaveHighScore();
        PlatformSpawner.instance.stop = true;
        StartCoroutine("WaitForShowing");
        StartCoroutine("showScore");
        //PlatformSpawner.instance.firstLoad = true;
    }

    IEnumerator showScore()
    {
        gamePlayUI.SetActive(false);
        showingResult = true;
        finalScore.text = score.ToString();
        finalHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        yield return new WaitForSeconds(1f);
        gameScore.SetActive(true);
    }
    IEnumerator RestartGame()
    {
        anim.SetTrigger("doneGame");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (gameStarted)
            {
                score++;
            }
        }
    }
    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score); 
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    IEnumerator WaitForShowing()
    {
        yield return new WaitForSeconds(1f);
        isDisable = false;
    }
}
