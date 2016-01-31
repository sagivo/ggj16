using UnityEngine;
using System.Collections;

public class GameController : BaseObject {

	//Color originalColor;
	Item pressedItem;

	// Use this for initialization
	new void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (Input.GetMouseButtonDown (0) && !pressedItem) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100) && hit.collider.GetComponent<Item> ()) {
				pressedItem = hit.collider.GetComponent<Item> ();
				pressedItem.press ();
				//originalColor = pressedItem.spriteRenderer.color;
				//pressedItem.spriteRenderer.color = Color.red;
				Debug.Log ("Hit object: " + hit.collider.gameObject.name);
				Invoke ("reset", pressedItem.holdToResetPerState [(int)pressedItem.state]);
			}
		} else if (Input.GetMouseButtonUp (0) && pressedItem) {
			CancelInvoke ("reset");
			pressedItem.release ();
			//pressedItem.spriteRenderer.color = originalColor;
			pressedItem = null;
		}
	}

	void reset(){
		pressedItem.reset ();
	}
}
