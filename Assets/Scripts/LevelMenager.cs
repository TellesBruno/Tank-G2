using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenager : MonoBehaviour
{
    public SpawnerScript _spaw;

    public string GameMode; //Preenchido no editor da Unity
    public string winnerName;
    
    private Player1 _player1;
    private Player2 _player2;

    public GameObject pauseMenu;
    public GameObject endMenu;
    public GameObject winMenu;
    public GameObject gameOverMenu;

    public bool pauseControl;

    public Text winnerText;
    public Text scoreText;
    public Text scoreText2;
    public Text scoreText3;
    public Text scoreText4;
    public Text Pontos;
    public Text Vidas;

    public int controlador;
    public int score;
    public int testeScore;
    public int playerLife;

    public int inimigo1Mortos;
    public int inimigo2Mortos;
    public int inimigo3Mortos;

    void Awake (){
		if (GameMode == ""){
            Debug.Log ("GameMode Vazio!");
            Application.Quit();
        }
	}

    void Start(){
        if(GameMode == "SinglePlayer"){
            _spaw.SpawPlayer();
            Vidas.text = "Vidas x" + playerLife;
        }
        testeScore = PlayerPrefs.GetInt("Score");
        _player1 = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player1>();
        if(GameMode == "MultiPlayer"){
            _player2 = GameObject.FindGameObjectWithTag ("Player2").GetComponent<Player2>();
        }
    }

    void FixedUpdate(){
        if(GameMode == "SinglePlayer"){
            Pontos.text = "Score: " + score;
        }
        if ((Input.GetKey (KeyCode.Escape)) && (pauseControl == false)){
            PauseStart();
        }
    }

    public void PauseStart (){
        pauseControl = true;
        _player1.pause = true;
        if(GameMode == "MultiPlayer"){
            _player2.pause = true;
        }       
        pauseMenu.SetActive(true);
    }

    public void ContinueGame(){
        _player1.pause = false;
        if(GameMode == "MultiPlayer"){
            _player2.pause = false;
        }
        pauseMenu.SetActive(false);
        pauseControl = false;

    }

    public void RestartGame(){
        SaveScore();
        SceneManager.LoadScene(this.gameObject.scene.buildIndex);
    }

    public void Quit() {
        SaveScore();
        Application.Quit();
    }

    public void LifeCounter(){
        playerLife--;
        Vidas.text = "Vidas x" + playerLife;
        if(playerLife<0){
            GameOver();
        } else {
            _spaw.SpawPlayer();
        }
    }

    public void GameOver (){
        SaveScore();
        gameOverMenu.SetActive(true);
        _player1.pause = true;
        scoreText.text = "Pontuação total: " + score;
        scoreText4.text = "Record Atual: " + PlayerPrefs.GetInt("Score").ToString();
    }    

    public void GameEnd (){
        endMenu.SetActive(true);
        _player1.pause = true;
        if(GameMode == "MultiPlayer"){
            _player2.pause = true;
        }
        winnerText.text = winnerName + " venceu a batalha!";
    }

    public void WinGame (){
        SaveScore();
        winMenu.SetActive(true);
        _player1.pause = true;
        scoreText2.text = "Pontuação total: " + score;
        scoreText3.text = "Record Atual: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void MainMenu(){
        SaveScore();
        SceneManager.LoadScene(0);
    }

    public void SaveScore()
    {
        if (testeScore <= score)
        {
            PlayerPrefs.SetInt("Score", score);
        }
        Debug.Log(PlayerPrefs.GetInt("Score"));
        PlayerPrefs.Save();
        Debug.Log("Funciona!");
    }

}
