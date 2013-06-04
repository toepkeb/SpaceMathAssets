using UnityEngine;
using System.Collections;

public class BillboardText : MonoBehaviour {
	
	Transform target;
	public bool changeAxis;
	
	// Use this for initialization
	void Start () {
	
		target = GameObject.FindGameObjectWithTag("Player").transform.parent;
		//target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!changeAxis)
		{
			Vector3 targetPos = transform.position + target.rotation * Vector3.forward;
			Vector3 targetOrientation = target.rotation * target.up;
			transform.LookAt(targetPos, targetOrientation);
			transform.rotation = target.rotation;
		}
		else
		{
//			Vector3 targetPos = transform.position + target.rotation * Vector3.forward;
//			Vector3 targetOrientation = target.rotation * target.forward;
//			transform.LookAt(targetPos, targetOrientation);
			transform.LookAt(Camera.main.transform);
			transform.up = transform.forward;
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z - 10f);
		}
		
//		Vector3 temp = target.position - transform.position;
//		//temp.x = temp.z = 0;
//		transform.LookAt(2 * target.position - target.position);
	}
}
