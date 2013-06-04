using UnityEngine;
using System.Collections;

public class RadioButton : MonoBehaviour {
	
	public bool active;
	public RadioController controller;
	public Texture2D activeTexture;
	public Texture2D inactiveTexture;
	
	public void Init(RadioController cont, bool act)
	{
		Debug.Log ("init");
		controller = cont;
		active = act;
		SetTexture(act);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Clicked()
	{
		controller.Clicked(this);
		Debug.Log ("Clicked radio");
	}
	
	public void SetState(bool act)
	{
		if (active == act)
			return;
		
		SetTexture(act);
		active = act;
		Debug.Log ("Set radio " + act);
	}
	
	void SetTexture(bool act)
	{
		foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
		{
			if (mr.material.mainTexture == activeTexture && !act)
			{
				Debug.Log ("hit1");
				mr.material.mainTexture = inactiveTexture;
			}
			else if (mr.material.mainTexture == inactiveTexture && act)
			{
				Debug.Log("hit2");
				mr.material.mainTexture = activeTexture;
			}
				
		}
	}
}
