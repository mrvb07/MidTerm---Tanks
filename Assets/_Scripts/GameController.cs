using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public EnemyController enemyController;
    public PlayerController player;
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameoverLabel;
    public Button RestartButton;

    //PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    //PUBLIC ACCESS METHODS
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
                this._endGame();
              
            }
            else
            {
                this.LivesLabel.text = "lives: " + this._livesValue;
            }
        }
    }

    // Use this for initialization
    void Start () {
        this._initialize();
        
        
        
    }

    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameoverLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);
        this._GenerateTanks();


    }

    // Update is called once per frame
    void Update () {
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}
    private void _endGame()
    {

        // this.GameOverLabel.gameObject.SetActive(true);
        
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.GameoverLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.player.gameObject.SetActive(false);
        this.tank.gameObject.SetActive(false);
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
