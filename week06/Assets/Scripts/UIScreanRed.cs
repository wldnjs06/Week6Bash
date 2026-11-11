using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScreanRed : MonoBehaviour
{
	private	Image imageScreen;    

	private void Awake()
	{
		imageScreen = GetComponent<Image>();
	}

	public void OnHitAnimation()
	{
		StopCoroutine(nameof(Process));
		StartCoroutine(nameof(Process));
	}

	private IEnumerator Process()
	{
		Color color = imageScreen.color;
		color.a = 0.4f;
		imageScreen.color = color;

		while ( color.a >= 0.0f )
		{
			color.a -= Time.deltaTime;
			imageScreen.color = color;

			yield return null;
		}
	}
}
