using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawnPlayer : MonoBehaviour {

	public string LevelName;
	
	AudioSource deathSound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D player)
	{
			Application.LoadLevel(Application.loadedLevel);
	}
}
