using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SPmenager : MonoBehaviour
{
    public string GameMode;
    private Player1 _player1;

    public GameObject pauseMenu;
    public GameObject endMenu;

    private bool pauseControl;
    public string winnerName;
    public Text winnerText;
    
    void Start()
    {
        _player1 = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player1>();
    }

    void FixedUpdate()
    {
        if ((Input.GetKey (KeyCode.Escape)) && (pauseControl == false)){
            PauseStart();
        }
    }

    public void PauseStart (){   
            _player1.pause = true;     
            pauseMenu.SetActive(true);
    }

    public void ContinueGame(){
        _player1.pause = false;
        pauseMenu.SetActive(false);

    }

    public void RestartGame(){
        SceneManager.LoadScene(this.gameObject.scene.buildIndex);
    }

    public void Quit() {
        Application.Quit();
    }

    public void GameEnd (){
        endMenu.SetActive(true);
        winnerText.text = winnerName + " venceu a batalha!";
    }

}
