using UnityEngine;
using System.Collections;

public class VaseItem : Item {


	// Use this for initialization
	protected new void Start () {
		base.Start();

		OnAsk += () => {
			//l("vate ask! " +  state);
		};

		OnStateChange += () => {
			//l("vase is "+ state);
		};
	}
	
	// Update is called once per frame
	protected new void Update () {
		base.Update ();
	}
}
