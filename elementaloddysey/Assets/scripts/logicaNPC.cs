using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaNPC : MonoBehaviour {
	//atributos
	public GameObject simboloMision;
	public logicaPersonaje jugador;

	public GameObject panelNpc, panelNpc2, panelNpcMision;
	public Text textoMision;

	private bool jugadorCerca;
	private bool aceptarMision=false;

	public GameObject[] objetivos;
	public int numObjetivos;

	public GameObject botonMision;

	public Animator animNpc;

	// Use this for initialization
	void Start () {
		animNpc = GetComponent<Animator> ();
		numObjetivos = objetivos.Length;
		textoMision.text = "obten las esferas rojas\n Restantes: " + numObjetivos;
		//jugador = GameObject.FindGameObjectWithTag ("Player").GetComponent<logicaPersonaje> ();
		simboloMision.SetActive (true);
		panelNpc.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)&&jugadorCerca==true && aceptarMision==false &&jugador.puedoSaltar==true){
			Vector3 posjugador = new Vector3 (transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
			jugador.gameObject.transform.LookAt (posjugador);

			jugador.anim.SetFloat ("VelX", 0);
			jugador.anim.SetFloat ("VelY", 0);
			jugador.enabled = false;
			panelNpc.SetActive (false);
			panelNpc2.SetActive (true);
			
		}
		
	}

	private void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			jugadorCerca = true;
			if(aceptarMision==false){
				panelNpc.SetActive (true);
			}
		}
	}

	private void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			jugadorCerca = false;
			panelNpc.SetActive (false);
			panelNpc2.SetActive (false);
		}		
	}

	public void no(){
		jugador.enabled = true;
		panelNpc2.SetActive (false);
		panelNpc.SetActive (true);
	}

	public void si(){
		numObjetivos = objetivos.Length;
		jugador.enabled = true;
		aceptarMision = true;
		for(int i=0; i<objetivos.Length;i++){
			objetivos [i].SetActive (true);
		}
		jugadorCerca = false;
		simboloMision.SetActive (false);
		panelNpc.SetActive (false);
		panelNpc2.SetActive (false);
		panelNpcMision.SetActive (true);
	}







}
