using UnityEngine;
using System.Collections;

public class PrismInteraction : MonoBehaviour {
	
	Vector3 previousPos;
	float velocity;
	float vref;
	bool canSelect;
	int sidesChanged = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (MenuManager.menuState == MenuManager.MenuState.Tutorial)
		{
			Interact();
		}
	}
	
	void Interact()
	{
		if (Input.GetMouseButtonDown(0))
		{
			canSelect = true;
			previousPos = Input.mousePosition;
		}
		
		if (Input.GetMouseButton(0))
		{
			
			velocity = (previousPos.x - Input.mousePosition.x)/200;
			
			if (velocity > .1f)
				canSelect = false;
		}
		if (Input.GetMouseButtonUp(0))
		{
			previousPos = Vector3.zero;
			
			if (canSelect)
				CheckPrismHit();
		}
		
		if (Mathf.Abs (velocity) >0)
		{
			transform.RotateAround(Vector3.up,velocity);
			velocity = Mathf.SmoothDamp(velocity,0,ref vref,.5f);
		}
		
		previousPos = Input.mousePosition;
	}
	
	void CheckPrismHit()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hits = Physics.RaycastAll(ray);
		float dist = Mathf.Infinity;
		int index = -1;
		
		for (int i=0; i < hits.Length;i++)
		{
			if (hits[i].collider.tag == "PrismSide" && Vector3.SqrMagnitude(hits[i].point-transform.position) <dist)
			{
				index = i;
				dist = Vector3.SqrMagnitude(hits[i].point-transform.position);
			}
		}
		
		if (index != -1)
		{
			if (!hits[index].collider.gameObject.renderer.enabled)
			{
				hits[index].collider.gameObject.renderer.enabled = true;
				sidesChanged ++;
				
				if (sidesChanged == 3)
				{
					CallLevelLoad.SetLevelLoad(ProfileManager.currentProfile.Planet+3,1);
					//MenuManager.menuState = MenuManager.MenuState.Start;
				}
			}
		}
	}
}
