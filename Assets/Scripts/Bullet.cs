using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
	public float shotSpeed;
	public Player2 _player2;
    public LevelMenager _lMenager;

    void Awake (){
        _lMenager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelMenager>();
        if (_lMenager.GameMode == "MultiPlayer"){
            _player2 = GameObject.FindGameObjectWithTag ("Player2").GetComponent<Player2>();
        }
        Debug.Log("OI");
    }

	void FixedUpdate () {
        if (_lMenager.pauseControl == false){
		    transform.Translate (0, shotSpeed, 0);
        }
	}

	void OnBecameInvisible(){
		//Destroy (this.gameObject);
	}

    void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Block"){
            _lMenager.score += 5;
            Destroy (other.gameObject);
            Destroy (this.gameObject);
        }

        if (other.gameObject.tag == "Iron"){
            Destroy (this.gameObject);
        }

        if (other.gameObject.tag == "Player2"){
            _player2.getHit();
            Destroy (this.gameObject);
        }

        if (other.gameObject.tag == "Inimigo1"){
            _lMenager.score += 20;
            _lMenager.inimigo1Mortos++;
            Destroy (other.gameObject);
            Destroy (this.gameObject);
        }

        if (other.gameObject.tag == "Inimigo2"){
            _lMenager.score += 40;
            _lMenager.inimigo2Mortos++;
            Destroy (other.gameObject);
            Destroy (this.gameObject);
        }

        if (other.gameObject.tag == "Inimigo3"){
            _lMenager.score += 80;
            _lMenager.inimigo3Mortos++;
            Destroy (other.gameObject);
            Destroy (this.gameObject);
        }
    }
}
