using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaSalto : MonoBehaviour {
	public logicaPersonaje lp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other){
		lp.puedoSaltar = true;
	}

	private void OnTriggerExit(Collider other){
		lp.puedoSaltar = false;
	}
}
