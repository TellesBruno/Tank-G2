using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoV2 : MonoBehaviour
{
    public float speed;
    public float speedMax;
	public float fireRate;
	private float nextFire;
	public Transform tiroSpaw;
	public GameObject tiro;
	public Player1 _player;

	public LevelMenager _lMenager;

    void Awake (){ //Executa quando o objeto entra em cena
        _lMenager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<LevelMenager>();
        _player = GameObject.FindGameObjectWithTag ("Player1").GetComponent<Player1>();
	}
    void Start() //Executa no primeiro frame do jogo
    {
        
    }

    void FixedUpdate()
    {
        if (_player.pause == false && _lMenager.pauseControl == false){
			transform.Translate (0, +speed, 0);
		}
    }

    void OnCollisionEnter2D (Collision2D other){ //Acionando no momento ca colisão
        if (speed<speedMax){
            speed += 0.001f;
        }
        if(other.gameObject.tag == "Player1"){
            Destroy(other.gameObject);
            _player.getHit();
        } else {
            if(other.gameObject.tag == "Iron"){
                transform.Translate(0,-0.1f,0);
                transform.Rotate (0,0,+90);
            } else {
                transform.Translate(0,-0.1f,0);
                transform.Rotate (0,0,+45);
            }
        }
    }
    void OnTriggerEnter2D (Collider2D other){ //Aciona quando um objeto entra no espaço do Gatilho
        if(other.gameObject.tag == "Player1" && Time.time > nextFire && _lMenager.pauseControl == false) {
			nextFire = Time.time + fireRate;
            Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
        }
        if(other.gameObject.tag == "Block" && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
            Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
        }
    }

    void OnCollisionStay2D (Collision2D other){ //Acionado quando fica em contato com outro objeto, e evita que fique travado em blocos
        if(other.gameObject.tag == "Block" && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
            Instantiate (tiro, tiroSpaw.position, tiroSpaw.rotation);
        }

        if(other.gameObject.tag == "Player1"){
            Destroy(other.gameObject);
            _player.getHit();
        }
    }
}
