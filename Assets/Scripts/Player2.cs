using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	public float speed;
	public float fireRate;
	private float nextFire;
	public Transform tiroSpaw;
	public GameObject tiro;
	public bool pause;

    public int health;
	public LevelMenager _lMenager;

	void Awake (){
        _lMenager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelMenager>();
	}
	void Start (){
		pause = false;
	}

	void FixedUpdate () {
		if (pause == false){
			if (Input.GetKey (KeyCode.P) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (0,0,+speed*60);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (0,0,-speed*60);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (0, +speed, 0);
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (0, -speed, 0);
			}
		}
	}
    public void getHit (){
        health-=1;
        if (health == 0){
            Debug.Log("Rip 2");
			_lMenager.winnerName = "Player 1";
			_lMenager.GameEnd();
            pause = true;
        }
    }
}
