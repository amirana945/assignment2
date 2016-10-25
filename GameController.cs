using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private int _livesValue;
    private int _scoreValue;
    private AudioSource _gameOver;
    


    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOver;
    public Text FinalScore;
    public Button RestartButton;


    public GameObject Player;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject Star1;
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this.endGame();
            }
            else
            {
                this.LivesLabel.text = "lives: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }





    void Start()
    {
        this.LivesValue = 5;
        this.ScoreValue = 0;
        this.GameOver.gameObject.SetActive(false);
        this.FinalScore.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
        this._gameOver = this.GetComponent<AudioSource>();

    }
    private void endGame()
    {
        this.GameOver.gameObject.SetActive(true);
        this.FinalScore.text = "Final Score: " + this.ScoreValue;
        this.FinalScore.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this._gameOver.Play();
        this.Player.SetActive(false);
        this.ghost1.SetActive(false);
        this.ghost2.SetActive(false);
        this.Star1.SetActive(false);

    }
    public void RestartButton_Click()
    {
        SceneManager.LoadScene("main");
    }
}

   

    
