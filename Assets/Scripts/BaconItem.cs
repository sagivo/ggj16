using UnityEngine;
using System.Collections;

public class BaconItem : Item {

	// Use this for initialization
	protected new void Start () {
		base.Start();
		l ("c");
		OnAsk += () => {
			l("bacon ask!");
		};

		OnStateChange += () => {
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
