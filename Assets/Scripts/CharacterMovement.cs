using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float BoostSpeed;
	[SerializeField] private float speed;
	[SerializeField] private float Jump;
	[SerializeField] private Transform GroundDetection;
	[SerializeField] private LayerMask Ground;
	[SerializeField] private int NumberOfBoost;

	private Rigidbody2D myRb;
	private bool grounded;
	private bool Boost = false;

	// Use this for initialization
	void Start () {
		myRb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (GroundDetection.position, 0.1f, Ground);

		if (Input.GetKey (KeyCode.UpArrow) && grounded) {
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

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (NumberOfBoost > 0) {
				NumberOfBoost -= 1;
			
				if (myRb.velocity.x > 0) {
					myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, myRb.velocity.x * BoostSpeed * Time.deltaTime);
				} else {
					myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, -myRb.velocity.x * BoostSpeed * Time.deltaTime);
				} 

				if (myRb.velocity.x == 0) {
					myRb.velocity = new Vector2 (0, 2000  * Time.deltaTime);
				}

				if (grounded) {
					myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed / 2 * Time.deltaTime, 0);
				}
			}
		}
	}
}
