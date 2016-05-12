using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float BoostSpeed;
	[SerializeField] private float speed;
	[SerializeField] private float Jump;


	private Rigidbody2D myRb;
	private bool grounded;
	private bool Boost = false;

	// Use this for initialization
	void Start () {
		myRb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			myRb.velocity = new Vector2 (myRb.velocity.x, Jump * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if(myRb.velocity.x <= (speed * Time.deltaTime))
				myRb.velocity = new Vector2 (speed * Time.deltaTime, myRb.velocity.y);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if(myRb.velocity.x >= (-speed * Time.deltaTime))
				myRb.velocity = new Vector2 (-speed * Time.deltaTime, myRb.velocity.y);

		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, myRb.velocity.y * BoostSpeed * Time.deltaTime);
			//myRb.AddForce((Vector2.right + Vector2.up) * BoostSpeed * Time.deltaTime);
			if (myRb.velocity.y < 0) {
				myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, myRb.velocity.y * BoostSpeed * Time.deltaTime);
			}
		}
	}
		
}
