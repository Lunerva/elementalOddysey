using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaObjetivoEsferas : MonoBehaviour {

	public logicaNPC lnpc;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			lnpc.numObjetivos--;
			lnpc.textoMision.text = "obten las esferas rojas\n Restantes: " + lnpc.numObjetivos;


			if(lnpc.numObjetivos<=0){
				lnpc.textoMision.text = "GRACIAS!!";
				lnpc.botonMision.SetActive (true);
				lnpc.animNpc.SetBool ("Happy",true);
				
			}
			transform.parent.gameObject.SetActive (false);

		}
	}
}
