using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaNPC : MonoBehaviour {
    // Atributos
    public GameObject simboloMision;
    public logicaPersonaje jugador;

    public GameObject panelNpc, panelNpc2, panelNpcMision;
    public Text textoMision;

    private bool jugadorCerca;
    private bool aceptarMision = false;

    public GameObject[] objetivos;
    public int numObjetivos;

    public GameObject botonMision;

    public Animator animNpc;

    // Método que se llama al iniciar el script
    void Start () {
        animNpc = GetComponent<Animator> ();
        numObjetivos = objetivos.Length;
        textoMision.text = "Obten las esferas rojas\nRestantes: " + numObjetivos;
        simboloMision.SetActive (true);
        panelNpc.SetActive (false);
    }

    // Método que se llama en cada frame
    void Update () {
        // Si se presiona la tecla E, el jugador está cerca, aún no se ha aceptado la misión y el jugador puede saltar
        if (Input.GetKeyDown(KeyCode.E) && jugadorCerca == true && aceptarMision == false && jugador.puedoSaltar == true){
            // El jugador mira hacia el NPC
            Vector3 posjugador = new Vector3 (transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt (posjugador);

            // Se detiene la animación de movimiento del jugador
            jugador.anim.SetFloat ("VelX", 0);
            jugador.anim.SetFloat ("VelY", 0);
            jugador.enabled = false;
            panelNpc.SetActive (false);
            panelNpc2.SetActive (true);
        }
    }

    // Método que se llama cuando un objeto entra en el área de colisión del NPC
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            jugadorCerca = true;
            if(aceptarMision == false){
                panelNpc.SetActive (true);
            }
        }
    }

    // Método que se llama cuando un objeto sale del área de colisión del NPC
    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            jugadorCerca = false;
            panelNpc.SetActive (false);
            panelNpc2.SetActive (false);
        }       
    }

    // Método llamado cuando el jugador rechaza la misión
    public void no(){
        jugador.enabled = true;
        panelNpc2.SetActive (false);
        panelNpc.SetActive (true);
    }

    // Método llamado cuando el jugador acepta la misión
    public void si(){
        numObjetivos = objetivos.Length;
        jugador.enabled = true;
        aceptarMision = true;
        // Activa todos los objetivos de la misión
        for(int i=0; i<objetivos.Length; i++){
            objetivos [i].SetActive (true);
        }
        jugadorCerca = false;
        simboloMision.SetActive (false);
        panelNpc.SetActive (false);
        panelNpc2.SetActive (false);
        panelNpcMision.SetActive (true);
    }
}
