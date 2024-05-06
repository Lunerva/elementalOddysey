using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVolumen : MonoBehaviour {

	public Slider slider;
	public float sliderVal;


	// Use this for initialization
	void Start () {
		slider.value = PlayerPrefs.GetFloat ("volumenAudio", 0.5f);
		AudioListener.volume = slider.value;
	}


	public void ChangeSlider(float val){
		sliderVal = val;
		PlayerPrefs.SetFloat ("volumenAudio", sliderVal);
		AudioListener.volume = slider.value;
	}
}
