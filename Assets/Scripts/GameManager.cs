using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public TMP_Text clickText;
	public static int clicks;

	void Update()
	{
		clickText.text = clicks.ToString();
	}
}