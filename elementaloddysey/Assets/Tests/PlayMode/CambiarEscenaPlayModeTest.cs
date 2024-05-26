using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CambiarEscenaPlayModeTest
{
	private GameObject gameObject;
	private logicaCambiarNivel logicaCambiarNivelScript;

	[SetUp]
	public void Setup()
	{
		// Crear un GameObject vacío y añadir el script logicaCambiarNivel
		gameObject = new GameObject();
		logicaCambiarNivelScript = gameObject.AddComponent<logicaCambiarNivel>();
	}

	[TearDown]
	public void Teardown()
	{
		// Destruir los objetos creados después de cada prueba
		Object.Destroy(gameObject);
	}

	[UnityTest]
	public IEnumerator TestCambiarNivel()
	{
		// Esperar un frame para asegurarse de que todo se inicializa correctamente
		yield return null;

		// Supongamos que la escena con índice 1 está disponible en tu proyecto
		int sceneIndex = 1;

		// Llamar manualmente al método cambiarNivel del script
		logicaCambiarNivelScript.cambiarNivel(sceneIndex);

		// Esperar un frame para permitir que el cambio de escena ocurra
		yield return null;

		// Verificar que la escena activa es la que se esperaba
		Assert.AreEqual(sceneIndex, SceneManager.GetActiveScene().buildIndex);
	}
}
