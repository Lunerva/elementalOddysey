using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicafullscreen : MonoBehaviour {

	public Toggle toggle;

	public Dropdown resDropdown;
	Resolution[] resoluciones;

	// Use this for initialization
	void Start () {
		if (Screen.fullScreen) {
			toggle.isOn = true;

		} else {
			toggle.isOn = false;
		}

		revisarRes ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void activarFullscreen(bool pantallaCompleta){
		Screen.fullScreen = pantallaCompleta;
	}

	public void revisarRes(){
		resoluciones = Screen.resolutions;
		resDropdown.ClearOptions ();
		List<string> opciones = new List<string> ();
		int resActual = 0;

		for(int i=0;i<resoluciones.Length;i++){
			string opcion = resoluciones [i].width + " x " + resoluciones [i].height;
			opciones.Add (opcion);

			if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height){
				resActual = i;
			}
		}
		resDropdown.AddOptions (opciones);
		resDropdown.value = resActual;
		resDropdown.RefreshShownValue ();

		resDropdown.value = PlayerPrefs.GetInt ("numeroRes",0);
	}

	public void cambiarRes(int indiceRes){
		PlayerPrefs.SetInt ("numeroRes",resDropdown.value);
		Resolution res = resoluciones [indiceRes];
		Screen.SetResolution (res.width, res.height, Screen.fullScreen);

	}


}
