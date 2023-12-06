using TMPro;
using UnityEngine;

public class Worker : MonoBehaviour
{
	public TMP_Text countText;
	public TMP_Text priceText;

	public int count;
	public int price;
	public int cps;
	public float priceIncrease;

	void Start()
	{
		InvokeRepeating("Work",1f,1f);
	}

	void Update()
	{
		countText.text = count.ToString();
		priceText.text = "price:" + price;
	}

	public void Work()
	{
		GameManager.clicks += count * cps;
	}

	public void Buy()
	{
		if (GameManager.clicks < price) return;

		GameManager.clicks -= price;
		count++;
		price = (int)(price * priceIncrease);
	}
}