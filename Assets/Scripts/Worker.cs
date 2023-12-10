using TMPro;
using UnityEngine;

public class Worker : MonoBehaviour
{
	public TMP_Text CookCountText;
	public TMP_Text CookPriceText;

    public TMP_Text ChefCountText;
    public TMP_Text ChefPriceText;

    public TMP_Text RobotCountText;
    public TMP_Text RobotPriceText;

    public int countCooks;
	public int countChefs;
	public int countRobots;
	public int cookPrice;
    public int chefPrice;
    public int robotPrice;
    public int cps;
	public float priceIncrease;

    public int multiplicator = 1;
    public int vegetablesPrice;
    public int meatPrice;
    public int secretIngridientPrice;

    public GameObject Vegetables;
    public GameObject Meat;
    public GameObject SecretIngridient;


    public GameObject Soups;

    public AudioClip Money;

	private bool hideSoups = false;

	private bool showSoups = false;

    void Start()
	{
		InvokeRepeating("Work",1f,1f);
	}

	void Update()
	{
        CookCountText.text = countCooks.ToString();
        CookPriceText.text = "price:" + cookPrice;

        ChefCountText.text = countChefs.ToString();
        ChefPriceText.text = "price:" + chefPrice;

        RobotCountText.text = countRobots.ToString();
        RobotPriceText.text = "price:" + robotPrice;

        RectTransform rt = Soups.GetComponent<RectTransform>();
        if (hideSoups)
		{
            Soups.transform.position = Vector3.Lerp(Soups.transform.position, new Vector3(-rt.sizeDelta.x + (rt.sizeDelta.x * 0.78f), Soups.transform.position.y, Soups.transform.position.z), 0.1f);
        }
        if (showSoups)
        {
            Soups.transform.position = Vector3.Lerp(Soups.transform.position, new Vector3(rt.sizeDelta.x - (rt.sizeDelta.x * 0.78f), Soups.transform.position.y, Soups.transform.position.z), 0.1f);
        }

    }

	public void Work()
	{
		GameManager.clicks += countCooks * cps * multiplicator;
        GameManager.clicks += countChefs * cps * 8 * multiplicator;
        GameManager.clicks += countRobots * cps * 30 * multiplicator;
    }

	public void BuyCook()
	{
		if (GameManager.clicks < cookPrice) return;

		GameManager.clicks -= cookPrice;
        BuySound();
        countCooks++;
        cookPrice = (int)(cookPrice * priceIncrease);
	}
    public void BuyChef()
    {
        if (GameManager.clicks < chefPrice) return;

        GameManager.clicks -= chefPrice;
        BuySound();
        countChefs++;
        chefPrice = (int)(chefPrice * priceIncrease);
    }
    public void BuyRobot()
    {
        if (GameManager.clicks < robotPrice) return;

        GameManager.clicks -= robotPrice;
        BuySound();
        countRobots++;
        robotPrice = (int)(robotPrice * priceIncrease);
    }
    public void MovePanel()
    {
		hideSoups = false;
        showSoups = false;

        if (Soups.transform.position.x > -100)
		{
			hideSoups = true;
		}
        else if (Soups.transform.position.x < -100)
        {
            showSoups = true;
        }

    }


    public void BuyVegetables()
    {
        if (GameManager.clicks < vegetablesPrice) return;

        multiplicator = 2;
        BuySound();
        Destroy(Vegetables);
    }
    public void BuyMeat()
    {
        if (GameManager.clicks < meatPrice) return;

        multiplicator = 5;
        BuySound();
        Destroy(Meat);
    }


    public void BuySecretIngridient()
    {
        if (GameManager.clicks < secretIngridientPrice) return;

        multiplicator = 15;
        BuySound();
        Destroy(SecretIngridient);
    }

    public void BuySound()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Money, 1f);
    }



}