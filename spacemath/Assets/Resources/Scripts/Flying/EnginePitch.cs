using UnityEngine;
using System.Collections;

public class EnginePitch : MonoBehaviour {
	
	Vector3 prevPos;
	Transform _transform;
	AudioSource sc;
	
	// Use this for initialization
	void Start () {
		_transform = transform;
		sc = audio;
		prevPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Vector3.SqrMagnitude(_transform.position-prevPos));
		float newpitch = Vector3.SqrMagnitude(_transform.position-prevPos)/5;
		audio.pitch = 1 + Mathf.Clamp (newpitch,0,2);
		prevPos = _transform.position;
	}
}
