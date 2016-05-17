using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	[SerializeField] private float BoostSpeed;
	[SerializeField] private float speed;
	[SerializeField] private float JumpSpeed = 1500;
	[SerializeField] private Transform GroundDetection;
	[SerializeField] private LayerMask Ground;
	[SerializeField] public int NumberOfBoost;
	[SerializeField] private ParticleSystem[] PlayerParticle;	
	[SerializeField] private Material[] playerColors;
	[SerializeField] private GameObject BoostSound;
	[SerializeField] private GameObject hitGroundSound;
	[SerializeField] private GameObject DropSound;
	[SerializeField] private GameObject pickUpSound;
	//[SerializeField] private Camera camera;
	//[SerializeField] private GameObject Junk;


	/*[SerializeField] private float duration = .5f;
	private float elapsed = 0f;
	private bool zoomIn = false;
	private bool zoomOut = false;
*/
	//private
	private MeshRenderer playerRenderer;
	private Animator myAnim;
	private Rigidbody2D myRb;
	private bool grounded;
	private bool jumped = false;
	// Use this for initialization
	void Start () {
		myRb = gameObject.GetComponent<Rigidbody2D> ();
		myAnim = gameObject.GetComponent<Animator> ();
		playerRenderer = gameObject.GetComponent<MeshRenderer> ();
		//camera = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		 
		/*if (zoomIn)
			CameraZoomIn();
		if (zoomOut)
			CameraZoomOut();
		*/

		grounded = Physics2D.OverlapCircle (GroundDetection.position, 0.1f, Ground);
		if (jumped && grounded){
			hitGroundSound.GetComponent<AudioSource> ().Play ();
			jumped = false;
		}

		if (Input.GetKey (KeyCode.UpArrow) && grounded) {
			if (myRb.velocity.x > 0) {
				myAnim.SetTrigger ("jump_right");
			} else {
				myAnim.SetTrigger ("jump_left");
			}

			myRb.velocity = new Vector2 (myRb.velocity.x, JumpSpeed * Time.deltaTime);
			jumped = true;
		}


		if (Input.GetKey (KeyCode.RightArrow)) {
			if (myRb.velocity.x <= (speed * Time.deltaTime)) {
				myRb.velocity = new Vector2 (speed * Time.deltaTime, myRb.velocity.y);
			}
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (myRb.velocity.x >= (-speed * Time.deltaTime)) {
				myRb.velocity = new Vector2 (-speed * Time.deltaTime, myRb.velocity.y);
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (NumberOfBoost > 0) {
				NumberOfBoost -= 1;
				BoostSound.GetComponent<AudioSource> ().Play ();
				//zoomOut = true;

				if (NumberOfBoost == 2) {
					gameObject.GetComponent<Transform> ().localScale = new Vector2 (1f, 1f);
					playerRenderer.material = playerColors [1];
					GameObject instantiatedParticle = Instantiate (PlayerParticle [2], transform.position, Quaternion.identity) as GameObject;
					Destroy (instantiatedParticle, 3f);
				} else if (NumberOfBoost == 1) {
					gameObject.GetComponent<Transform> ().localScale = new Vector2 (.75f, .75f);
					playerRenderer.material = playerColors [0];
					GameObject instantiatedParticle = Instantiate (PlayerParticle [0], transform.position, Quaternion.identity) as GameObject;
					Destroy (instantiatedParticle, 3f);
				} else if (NumberOfBoost == 0) {
					gameObject.GetComponent<Transform> ().localScale = new Vector2 (.5f, .5f);
					playerRenderer.material = playerColors [2];
					GameObject instantiatedParticle = Instantiate (PlayerParticle[1], transform.position, Quaternion.identity) as GameObject;
					Destroy (instantiatedParticle, 3f);
				}
					

				if (myRb.velocity.x > 0) {
					
					myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, myRb.velocity.x * BoostSpeed * Time.deltaTime);

				} else if (myRb.velocity.x < 0) {
					myRb.velocity = new Vector2 (myRb.velocity.x * BoostSpeed * Time.deltaTime, -myRb.velocity.x * BoostSpeed * Time.deltaTime);
				} else {
					if (grounded) {
					myRb.velocity = new Vector2 (7 * BoostSpeed * Time.deltaTime, 0);
					} else {
						myRb.velocity = new Vector2 (0, 10 * BoostSpeed * Time.deltaTime);
					}
				}
					
			}
		}
	}

	/*private void CameraZoomIn()
	{
		if (zoomIn) {
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (8f, 5f, 0.8f);
			if (Camera.main.orthographicSize == 5f) {
				zoomIn = false;
			}
		}
	}

	private void CameraZoomOut()
	{
		if (zoomOut) {
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.Lerp (5f, 8f, 0.8f);
			if (Camera.main.orthographicSize == 8f) {
				zoomIn = true;
				zoomOut = false;
			}
		}
	}*/

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "food") {
			Destroy (other.gameObject);
			if (NumberOfBoost >= 2) {
				DropSound.GetComponent<AudioSource> ().Play ();
				GameObject instantiatedParticle = Instantiate (PlayerParticle [3], transform.position, Quaternion.identity) as GameObject;
				NumberOfBoost = 2;
			}else {
				pickUpSound.GetComponent<AudioSource> ().Play ();
				NumberOfBoost += 1;
				if (NumberOfBoost == 1) {
					gameObject.GetComponent<Transform> ().localScale = new Vector2 (.75f, .75f);
					playerRenderer.material = playerColors [0];
					GameObject instantiatedParticle = Instantiate (PlayerParticle[1], transform.position, Quaternion.identity) as GameObject;
					Destroy (instantiatedParticle, 3f);
				} else if (NumberOfBoost == 2) {
					gameObject.GetComponent<Transform> ().localScale = new Vector2 (1f, 1f);
					playerRenderer.material = playerColors [1];
					GameObject instantiatedParticle = Instantiate (PlayerParticle [0], transform.position, Quaternion.identity) as GameObject;
					Destroy (instantiatedParticle, 3f);
				}
			}
			//Destroy (other.gameObject, 3f);
		}
	}
}
