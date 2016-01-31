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
	public Text t;

	// Use this for initialization
	new void Start () {
		base.Start ();

		if (!game)
			game = this;

		MiniGestureRecognizer.Swipe += (MiniGestureRecognizer.SwipeDirection dir) => {
			t.text = dir.ToString();	
			if (pressedItem && pressedItem.swipeDirection == dir) reset();
		};
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();

		if (Input.GetMouseButtonDown (0) && !pressedItem) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100) && hit.collider.GetComponent<Item> ()) {
				pressedItem = hit.collider.GetComponent<Item> ();
				if (pressedItem && pressedItem.state != Item.ItemState.Broken) {
					if (pressedItem.swipeDirection == MiniGestureRecognizer.SwipeDirection.NONE) {
						pressedItem.press ();
						Invoke ("reset", pressedItem.holdToResetPerState [(int)pressedItem.state]);
					}
				}
			}
		} else if (Input.GetMouseButtonUp (0) && pressedItem) {
			CancelInvoke ("reset");
			pressedItem.release ();
			pressedItem = null;
		}
	}

	void reset(){
		pressedItem.reset ();
		if (pressedItem)
			Invoke ("reset", pressedItem.holdToResetPerState [(int)pressedItem.state]);
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
		ApplicationModel.ObjectID = 11;
		Application.LoadLevel ("letter");
	}


}
