using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicaSaltoPlayModeTest
{
	private GameObject gameObject;
	private logicaSalto logicaSaltoScript;
	private logicaPersonaje logicaPersonajeScript;
	private GameObject piso;

	[SetUp]
	public void Setup()
	{
		// Crear un GameObject para el personaje y añadir los scripts necesarios
		gameObject = new GameObject();
		gameObject.AddComponent<Animator>();
		logicaSaltoScript = gameObject.AddComponent<logicaSalto>();
		logicaPersonajeScript = gameObject.AddComponent<logicaPersonaje>();
		logicaSaltoScript.lp = logicaPersonajeScript;

		// Crear un GameObject para el suelo
		piso = new GameObject();
		piso.tag = "piso";
		piso.AddComponent<BoxCollider>();
	}

	[TearDown]
	public void Teardown()
	{
		// Destruir los objetos creados después de cada prueba
		Object.Destroy(gameObject);
		Object.Destroy(piso);
	}

	[UnityTest]
	public IEnumerator TestPermitirSaltoCuandoTocaPiso()
	{
		// Activar la capacidad de saltar manualmente
		logicaSaltoScript.ActivarSalto();

		// Asegurarse de que el personaje está en la colisión con el suelo
		piso.transform.position = gameObject.transform.position;

		// Esperar un frame para permitir que el método procese la colisión
		yield return null;

		// Verificar que el personaje puede saltar
		Assert.IsTrue(logicaPersonajeScript.puedoSaltar);
	}

}
