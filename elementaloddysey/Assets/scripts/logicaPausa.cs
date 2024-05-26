using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPausa : MonoBehaviour
{
	public GameObject menu;

	// Update is called once per frame
	void Update()
	{
		if (IsEscapeKeyPressed())
		{
			ToggleMenu();
		}
	}

	public bool IsEscapeKeyPressed()
	{
		return Input.GetKeyDown(KeyCode.Escape);
	}

	public void ToggleMenu()
	{
		menu.SetActive(true);
	}
}
