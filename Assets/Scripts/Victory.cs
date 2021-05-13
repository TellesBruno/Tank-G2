using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public LevelMenager _lMenager;

    void Awake(){
        _lMenager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelMenager>();
    }

    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Player1"){
            _lMenager.score += 300;
            _lMenager.WinGame();
            Destroy(this.gameObject);  
        }
    }
}
