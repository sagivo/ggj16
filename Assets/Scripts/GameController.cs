using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : BaseObject {

	//Color originalColor;
	Item pressedItem;
	public Image[] lifeImages;
	public int life = 3;
	public Sprite decImage;
	public static GameController game;

	// Use this for initialization
	new void Start () {
		base.Start ();

		if (!game)
			game = this;
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

	public void dec(){
		life--;
		if (life >= 0) {
			lifeImages [life].sprite = decImage;
		} else
			die ();
	}

	public void die(){
		l ("i'm dead!");
	}
}
