using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class logicaPausaPlayModeTest
{
	private GameObject gameObject;
	private logicaPausa logicaPausaScript;
	private GameObject menu;

	[SetUp]
	public void Setup()
	{
		// Crear un GameObject vacío y añadir el script logicaPausa
		gameObject = new GameObject();
		logicaPausaScript = gameObject.AddComponent<logicaPausa>();

		// Crear el menú y asignarlo al script
		menu = new GameObject();
		menu.SetActive(false);
		logicaPausaScript.menu = menu;
	}

	[TearDown]
	public void Teardown()
	{
		// Destruir los objetos creados después de cada prueba
		Object.Destroy(gameObject);
		Object.Destroy(menu);
	}

	[UnityTest]
	public IEnumerator TestMenuActivatesOnToggleMenu()
	{
		// Esperar un frame para asegurarse de que todo se inicializa correctamente
		yield return null;

		// Llamar manualmente al método ToggleMenu del script
		logicaPausaScript.ToggleMenu();

		// Verificar que el menú está activo
		Assert.IsTrue(menu.activeSelf);
	}
}
