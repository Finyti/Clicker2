using UnityEngine;

public class Pot : MonoBehaviour
{
	public float shrinkSpeed;
	public Vector3 rotateSpeed;
	public GameObject PotEffect;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void Update()
	{
		transform.Rotate(rotateSpeed * Time.deltaTime);
		if (transform.localScale.x > 1f)
		{
			transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
		}
	}

	void OnMouseDown()
	{
		transform.localScale = Vector3.one * 1.3f;
		source.PlayOneShot(source.clip);
		GameManager.clicks++;

		for(int i = 0; i < 10; i++)
		{
			var obj = Instantiate(PotEffect);
			obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode.Impulse);
			Destroy(obj, 1f);
        }
	}
}