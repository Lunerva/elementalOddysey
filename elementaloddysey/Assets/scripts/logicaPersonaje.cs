using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPersonaje : MonoBehaviour {
	//movimiennto
	private float velocidadMov = 5.0f;
	private float velocidadRot = 200.0f;
	private Animator anim;
	public float x, y;
	//salto
	public Rigidbody rb;
	public float fuerzaSalto = 6f;
	public bool puedoSaltar;
	//golpe
	public bool estoyAtacando;
	public bool avanzoSolo;
	public float impulsoGolpe = 10.0f;





	// Use this for initialization
	void Start () {
		puedoSaltar = false;
		anim = GetComponent<Animator>();
	}

	void FixedUpdate (){
		if(!estoyAtacando){
			transform.Rotate (0, x * Time.deltaTime * velocidadRot, 0);
			transform.Translate (0, 0, y * Time.deltaTime * velocidadMov);
		}


		if(avanzoSolo){
			rb.velocity = transform.forward * impulsoGolpe;
		}

	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Vertical");

		if (Input.GetKeyDown (KeyCode.Mouse0) && puedoSaltar && !estoyAtacando && (anim.GetFloat("VelY")==0f)) {
			anim.SetTrigger ("golpeo");
			estoyAtacando = true;
		} else {
			dejeDeGolpear ();
		}

		anim.SetFloat ("VelX", x);
		anim.SetFloat ("VelY", y);


		if (puedoSaltar) {
			if(!estoyAtacando){
				if (Input.GetKeyDown (KeyCode.Space)) {
					anim.SetBool ("salte",true);
					rb.AddForce (new Vector3 (0, fuerzaSalto, 0), ForceMode.Impulse);
				}
			}
			anim.SetBool ("tocoSuelo", true);
		} else {
			estoyCayendo ();
		}


	}

	public void estoyCayendo(){
		anim.SetBool ("tocoSuelo", false);
		anim.SetBool ("salte", false);
	}

	public void dejeDeGolpear(){
		estoyAtacando = false;
	}

	public void AvanzoSolo(){
		avanzoSolo = true;
	}

	public void dejoDeAvanzar(){
		avanzoSolo = false;
	}

}
