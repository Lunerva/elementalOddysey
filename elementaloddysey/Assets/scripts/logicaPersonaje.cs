using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPersonaje : MonoBehaviour {
    // Movimiento
    private float velocidadMov = 5.0f;
    private float velocidadRot = 200.0f;
    public Animator anim;
    private float x, y;

    // Salto
    public Rigidbody rb;
    public float fuerzaSalto = 6f;
    public bool puedoSaltar;

    // Golpe
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10.0f;

    // Método que se llama al inicio del script
    void Start () {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }

    // Método que se llama en cada frame de física
    void FixedUpdate (){
        // Control del movimiento del personaje
        if(!estoyAtacando){
            transform.Rotate (0, x * Time.deltaTime * velocidadRot, 0);
            transform.Translate (0, 0, y * Time.deltaTime * velocidadMov);
        }

        // Control del impulso de avance al golpear
        if(avanzoSolo){
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }
    
    // Método que se llama en cada frame
    void Update () {
        // Entrada de teclado para el movimiento
        x = Input.GetAxis ("Horizontal");
        y = Input.GetAxis ("Vertical");

        // Control del golpe
        if (Input.GetKeyDown (KeyCode.Mouse1) && puedoSaltar && !estoyAtacando && (anim.GetFloat("VelY")==0f)) {
            anim.SetTrigger ("golpeo");
            estoyAtacando = true;
        } else {
            dejeDeGolpear ();
        }

        // Actualización de las variables del animator para el movimiento
        anim.SetFloat ("VelX", x);
        anim.SetFloat ("VelY", y);

        // Control del salto
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

    // Método llamado cuando el personaje está cayendo
    public void estoyCayendo(){
        anim.SetBool ("tocoSuelo", false);
        anim.SetBool ("salte", false);
    }

    // Método llamado cuando el personaje deja de golpear
    public void dejeDeGolpear(){
        estoyAtacando = false;
    }

    // Método llamado cuando el personaje avanza solo (golpea)
    public void AvanzoSolo(){
        avanzoSolo = true;
    }

    // Método llamado cuando el personaje deja de avanzar solo
    public void dejoDeAvanzar(){
        avanzoSolo = false;
    }
}

