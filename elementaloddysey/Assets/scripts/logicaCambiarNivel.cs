using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logicaCambiarNivel : MonoBehaviour {

    // Método público para cambiar de escena
    public void cambiarNivel(int indice){
        // Se carga la escena correspondiente al índice proporcionado
        SceneManager.LoadScene (indice);
    }
}
