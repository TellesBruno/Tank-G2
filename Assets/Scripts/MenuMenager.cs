using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
    public int topScore;
    public Text scoreText;

    void Start (){
        topScore = PlayerPrefs.GetInt("Score");
        scoreText.text = "Maior pontuação: " + topScore;
    }

    public void NewGame(){
        SceneManager.LoadScene(2);
    }

    public void MultiPlayer(){
        SceneManager.LoadScene(1);
    }
    
    public void Quit() {
        Application.Quit();
    }
}
