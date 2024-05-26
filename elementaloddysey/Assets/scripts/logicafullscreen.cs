using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicafullscreen : MonoBehaviour {

    // Declaración de variables públicas
    public Toggle toggle; // Referencia al componente Toggle que controla la pantalla completa
    public Dropdown resDropdown; // Referencia al componente Dropdown que muestra las opciones de resolución
    Resolution[] resoluciones; // Array para almacenar las resoluciones disponibles

    // Método que se llama al iniciar el script
    void Start () {
        // Verifica si la pantalla está en modo de pantalla completa y actualiza el estado del Toggle
        if (Screen.fullScreen) {
            toggle.isOn = true;
        } else {
            toggle.isOn = false;
        }

        // Llama al método para configurar las opciones de resolución
        revisarRes ();
    }
    
    // Método público para activar o desactivar el modo de pantalla completa
    public void activarFullscreen(bool pantallaCompleta){
        Screen.fullScreen = pantallaCompleta;
    }

    // Método para revisar y configurar las opciones de resolución
    public void revisarRes(){
        // Obtiene todas las resoluciones disponibles
        resoluciones = Screen.resolutions;
        resDropdown.ClearOptions (); // Borra todas las opciones del Dropdown
        List<string> opciones = new List<string> ();
        int resActual = 0;

        // Recorre todas las resoluciones disponibles
        for(int i=0; i<resoluciones.Length; i++){
            // Crea una cadena de texto con el formato "Ancho x Alto" para cada resolución
            string opcion = resoluciones [i].width + " x " + resoluciones [i].height;
            opciones.Add (opcion); // Agrega la opción al listado

            // Verifica si la resolución actual coincide con la resolución de la pantalla
            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height){
                resActual = i; // Almacena el índice de la resolución actual
            }
        }

        resDropdown.AddOptions (opciones); // Agrega todas las opciones al Dropdown
        resDropdown.value = resActual; // Establece el valor del Dropdown con la resolución actual
        resDropdown.RefreshShownValue (); // Actualiza el Dropdown para mostrar la resolución actual

        // Recupera la resolución seleccionada anteriormente (si la hay) desde PlayerPrefs
        resDropdown.value = PlayerPrefs.GetInt ("numeroRes", 0);
    }

    // Método para cambiar la resolución de la pantalla
    public void cambiarRes(int indiceRes){
        // Guarda la resolución seleccionada en PlayerPrefs
        PlayerPrefs.SetInt ("numeroRes", resDropdown.value);
        // Obtiene la resolución seleccionada del array de resoluciones
        Resolution res = resoluciones [indiceRes];
        // Establece la resolución de la pantalla
        Screen.SetResolution (res.width, res.height, Screen.fullScreen);
    }
}
