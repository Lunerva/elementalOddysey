using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaObjetivoEsferas : MonoBehaviour {

    // Referencia al script del NPC para actualizar los objetivos
    public logicaNPC lnpc;

    // Método que se llama cuando un objeto entra en el área de colisión del objetivo
    void OnTriggerEnter(Collider col){
        // Verifica si el objeto que entra es el jugador
        if(col.gameObject.tag == "Player"){
            // Reduce el número de objetivos restantes en el NPC
            lnpc.numObjetivos--;
            // Actualiza el texto de la misión en el NPC con el nuevo número de objetivos restantes
            lnpc.textoMision.text = "Obten las esferas verdes\nRestantes: " + lnpc.numObjetivos;

            // Verifica si se han recogido todos los objetivos
            if(lnpc.numObjetivos <= 0){
                // Actualiza el texto de la misión y muestra un botón de misión completada
                lnpc.textoMision.text = "¡GRACIAS!";
                lnpc.botonMision.SetActive (true);
                // Activa una animación en el NPC para expresar alegría
                lnpc.animNpc.SetBool ("Happy", true);
            }

            // Desactiva el objeto objetivo
            transform.parent.gameObject.SetActive (false);
        }
    }
}
