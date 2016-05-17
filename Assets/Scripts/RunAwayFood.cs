using UnityEngine;
using System.Collections;

public class RunAwayFood : MonoBehaviour {

	public GameObject food;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		food.GetComponent<Rigidbody2D>().velocity = new Vector2(-12,0);
	}
}
