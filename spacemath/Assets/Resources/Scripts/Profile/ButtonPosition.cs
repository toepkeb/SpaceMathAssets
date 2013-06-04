using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ButtonPosition : MonoBehaviour {
	
	public Camera cam;
	public float depth = 1;
	public float x;
	public float y;
	public bool adjustWidthAspectRatio = true;
	
	Transform _transform;
	// Use this for initialization
	void Start () {
		
		_transform = transform;
		if (cam.GetComponent<AudioListener>())
			Destroy(cam.GetComponent<AudioListener>());
		depth = Mathf.Clamp(depth, cam.nearClipPlane,cam.farClipPlane);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (adjustWidthAspectRatio)
			_transform.localPosition = new Vector3(x*cam.orthographicSize*cam.aspect,y*cam.orthographicSize,depth);
		else
			_transform.localPosition = new Vector3(x*cam.orthographicSize,y*cam.orthographicSize,depth);
			
	}
	
}
