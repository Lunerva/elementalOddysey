using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVolumen : MonoBehaviour {
    // Referencia al slider de volumen en la interfaz de usuario
    public Slider slider;
    // Valor actual del slider
    public float sliderVal;

    // Método que se llama al inicio del script
    void Start () {
        // Establece el valor del slider al último valor guardado en PlayerPrefs (o 0.5f si no hay valor guardado)
        slider.value = PlayerPrefs.GetFloat ("volumenAudio", 0.5f);
        // Establece el volumen del AudioListener al valor actual del slider
        AudioListener.volume = slider.value;
    }

    // Método llamado cuando se cambia el valor del slider
    public void ChangeSlider(float val){
        // Actualiza el valor del slider
        sliderVal = val;
        // Guarda el nuevo valor del volumen en PlayerPrefs
        PlayerPrefs.SetFloat ("volumenAudio", sliderVal);
        // Actualiza el volumen del AudioListener con el nuevo valor del slider
        AudioListener.volume = slider.value;
    }
}
