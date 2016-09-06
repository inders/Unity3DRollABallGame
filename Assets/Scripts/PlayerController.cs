using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text CountText;
	public Text winText;

	void Start() 
	{
		rb = this.GetComponent<Rigidbody>();
		DisplayCount ();
		winText.text = "";
	}

	//Fixed update is called before applying any physics calculation
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontal, 0.0f, vertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		
		if (other.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			DisplayCount ();
			if (count == 6)
			{
				winText.text = "You Win!!";
			}
		}
	}

	void DisplayCount()
	{
		CountText.text = "Count: " + count.ToString ();
	}
		
}
