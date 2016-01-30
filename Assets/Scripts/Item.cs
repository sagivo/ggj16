using UnityEngine;
using System.Collections;

public class Item : BaseObject {

	public float needActionEvery = 3f;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("askAction", needActionEvery, needActionEvery);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void askAction(){
		l ("action now!");
	}
}
