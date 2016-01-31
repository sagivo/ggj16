using UnityEngine;
using System.Collections;

public class BaconItem : Item {

	// Use this for initialization
	protected new void Start () {
		base.Start();

		OnAsk += () => {
			l("bacon ask! " +  state);
		};

		OnStateChange += () => {
			if (state == ItemState.Broken) GameController.game.decLife();
		};
	}
	
	// Update is called once per frame
	protected new void Update () {
		base.Update ();
	}
}
