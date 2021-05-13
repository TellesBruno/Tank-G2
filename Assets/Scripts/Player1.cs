using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
	public float speed;
	public float fireRate;
	private float nextFire;
	public Transform tiroSpaw;
	public GameObject tiro;
	public bool pause;

	public LevelMenager _lMenager;

    public int health;

	void Awake (){ //Executa quando o objeto entra em cena
        _lMenager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelMenager>();
	}
	void Start (){ //Executa no primeiro frame do jogo
		pause = false;
    }

	void FixedUpdate () {
		if (pause == false){
			if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (0,0,+speed*60);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (0,0,-speed*60);
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (0, +speed, 0);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (0, -speed, 0);
			}
		}
	}

    public void getHit (){
		if(_lMenager.GameMode == "MultiPlayer"){
			health-=1;
        	if (health == 0){
        	    Debug.Log("Rip 1");
				_lMenager.winnerName = "Player 2";
				_lMenager.GameEnd();
        	    pause = true;
        	}
		} else {
			Debug.Log("Rip 1");
			_lMenager.LifeCounter();
			Destroy(this.gameObject);
		}
        
    }

}