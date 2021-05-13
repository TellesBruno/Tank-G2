using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public LevelMenager _lMenager;
    public GameObject WinGame;
    public GameObject player1;

    public GameObject inimigo1;
    public GameObject[] inimigo1Array;
    public int inimigo1NaTela;
    public int maxInimogos1;
    public int metaInimigo1;

    public GameObject inimigo2;
    public GameObject[] inimigo2Array;
    public int inimigo2NaTela;
    public int maxInimogos2;
    public int metaInimigo2;

    public GameObject inimigo3;
    public GameObject[] inimigo3Array;
    public int inimigo3NaTela;
    public int maxInimogos3;
    public int metaInimigo3;

    public float proxInimigo;
	public float spawDeley;

    private bool canSpawWin;

    public Transform[] spawPositionArray;
    public Transform spawEnd;
    public Transform playerSpaw;    

    void Awake (){
        _lMenager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelMenager>();
	}

    void Start(){
        metaInimigo1 = 0;
        metaInimigo2 = 0;
        metaInimigo3 = 0;
        canSpawWin = true;
    }

    void FixedUpdate(){
        if ((_lMenager.pauseControl == false) ){

		    CriaInimigo1 ();

            if (maxInimogos1 == _lMenager.inimigo1Mortos){
                CriaInimigo2 ();
            }

            if (maxInimogos2 == _lMenager.inimigo2Mortos){
            CriaInimigo3 ();
            }
		}

        if (maxInimogos1 == _lMenager.inimigo1Mortos && maxInimogos2 == _lMenager.inimigo2Mortos && maxInimogos3 == _lMenager.inimigo3Mortos && canSpawWin){
            canSpawWin = false;
            Instantiate (WinGame, spawEnd);
        }
	}

	void CriaInimigo1(){
		inimigo1Array = GameObject.FindGameObjectsWithTag ("Inimigo1");
		if ((inimigo1Array.Length < inimigo1NaTela) && (maxInimogos1>metaInimigo1) && (Time.time > proxInimigo)) {
            proxInimigo = Time.time + spawDeley;
			Instantiate (inimigo1, spawPositionArray[Random.Range (0, 4)]);
			metaInimigo1++;
		}
	}

    void CriaInimigo2(){
		inimigo2Array = GameObject.FindGameObjectsWithTag ("Inimigo2");
		if ((inimigo2Array.Length < inimigo2NaTela) && (maxInimogos2>metaInimigo2) && (Time.time > proxInimigo)) {
            proxInimigo = Time.time + spawDeley;
			Instantiate (inimigo2, spawPositionArray[Random.Range (0, 4)]);
			metaInimigo2++;
		}
	}

    void CriaInimigo3(){
		inimigo3Array = GameObject.FindGameObjectsWithTag ("Inimigo3");
		if ((inimigo3Array.Length < inimigo3NaTela) && (maxInimogos3>metaInimigo3) && (Time.time > proxInimigo)) {
            proxInimigo = Time.time + spawDeley;
			Instantiate (inimigo3, spawPositionArray[Random.Range (0, 4)]);
			metaInimigo3++;
		}
	}

    public void SpawPlayer(){
        Instantiate(player1, playerSpaw);
    }
}
