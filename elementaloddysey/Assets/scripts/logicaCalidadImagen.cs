using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaCalidadImagen : MonoBehaviour {

    // Declaración de variables públicas
    public Dropdown dropdown; // Referencia al componente Dropdown en la interfaz de usuario
    public int calidad; // Variable para almacenar el nivel de calidad seleccionado

    // Método que se ejecuta al iniciar el script
    void Start () {
        // Se obtiene el nivel de calidad almacenado en PlayerPrefs (persistente entre sesiones)
        calidad = PlayerPrefs.GetInt ("numeroDeCalidad",3);
        // Se establece el valor del Dropdown según el nivel de calidad almacenado
        dropdown.value = calidad;
        // Se llama al método para ajustar la calidad
        ajustarCalidad ();
    }

    // Método público llamado cuando se cambia la opción del Dropdown
    public void ajustarCalidad(){
        // Se establece el nivel de calidad según el valor seleccionado en el Dropdown
        QualitySettings.SetQualityLevel (dropdown.value);
        // Se guarda el nivel de calidad seleccionado en PlayerPrefs para futuras sesiones
        PlayerPrefs.SetInt ("numeroDeCalidad",dropdown.value);
        // Se actualiza la variable calidad con el valor seleccionado en el Dropdown
        calidad = dropdown.value;
    }
}

