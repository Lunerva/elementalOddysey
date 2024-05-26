using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaSalto : MonoBehaviour
{
	// Referencia al script del personaje
	public logicaPersonaje lp;

	// Método público para activar la capacidad de saltar
	public void ActivarSalto()
	{
		lp.puedoSaltar = true;
	}

	// Método público para desactivar la capacidad de saltar
	public void DesactivarSalto()
	{
		lp.puedoSaltar = false;
	}

	// Método que se llama cuando un objeto permanece en el área de colisión
	private void OnTriggerStay(Collider other)
	{
		// Verifica si el objeto en contacto es el suelo
		if (other.tag == "piso")
		{
			// Permite al personaje saltar
			ActivarSalto();
		}
	}

	// Método que se llama cuando un objeto sale del área de colisión
	private void OnTriggerExit(Collider other)
	{
		// Desactiva la capacidad del personaje para saltar
		DesactivarSalto();
	}
}
