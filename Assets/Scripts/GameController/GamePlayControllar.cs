using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayControllar : MonoBehaviour
{
    public static GamePlayControllar instance;

    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restsrtgamebutton, instractionbutton;

    [SerializeField]
    private GameObject pausePenal;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image modelimage;

    void Start()
    {
        
    }
    void Awake()
    {
        MakeInstance();
        Time.timeScale = 0f;
    }
    void MakeInstance()
    {
        instance = this;
        //if(instance = null)
        //{
        //    instance = this;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        if(BirdScript.instance!= null)
        {
            if(BirdScript.instance.isAlive )
            {
                pausePenal.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                endScore.text = "" + BirdScript.instance.Score;
                bestScore.text = "" + GameControllar.instance.GetHighScore();
                Time.timeScale = 0f;
                restsrtgamebutton.onClick.RemoveAllListeners();
                restsrtgamebutton.onClick.AddListener(()=> ResumeGame());
            } 

        }
    }
    public void GotoMainMEnuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }
    public void ResumeGame()
    {
        pausePenal.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneFader.instance.FadeIn(Application.loadedLevelName); 
    }
    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);

        birds[GameControllar.instance.GetSelectedBird()].SetActive(true);
        instractionbutton.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }
    public void SetScore(int score)
    {
        scoreText.text = "" + score;
        Debug.Log(score);
    }
    public void PlayerDiedShowScore(int score)
    {
        pausePenal.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = "" + score;

        if(score > GameControllar.instance.GetHighScore ())
        {
            GameControllar.instance.SetHighScore(score); 
        }
        bestScore.text = "" + GameControllar.instance.GetHighScore();
        if(score <=  20)
        {
            modelimage.sprite = medals[0];
        }else if(score > 20 && score < 40)
        {
            modelimage.sprite = medals[1];
            if( GameControllar .instance .IsGreenBirdUnlocked() == 0)
            {
                GameControllar.instance.UnlockGreenBird();
            }
        }
        else
        {
            modelimage.sprite = medals[2];
            if (GameControllar.instance.IsGreenBirdUnlocked() == 0)
            {
                GameControllar.instance.UnlockGreenBird();
            }
            if (GameControllar.instance.IsRedBirdUnlocked() == 0)
            {
                GameControllar.instance.UnlockGreenBird();
            }
        }
        restsrtgamebutton.onClick.RemoveAllListeners();
        restsrtgamebutton.onClick.AddListener(() => RestartGame());
    }
}
