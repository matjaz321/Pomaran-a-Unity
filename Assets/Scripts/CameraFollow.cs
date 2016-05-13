using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Transform Target;
	[SerializeField] private float Smoothing;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - Target.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetCamPos = Target.position + offset;

		transform.position = /*Vector3.Lerp (*/targetCamPos/*)*/;
	}
}
