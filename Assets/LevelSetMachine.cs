using UnityEngine;
using System.Collections;

public class LevelSetMachine : MonoBehaviour {

	public GameObject[] allItems;
	// Use this for initialization
	void Start () {
		//enable game objects equal to the level ID+2
		for (int i=0;i<=ApplicationModel.ObjectID+4	;i++){
			allItems[i].SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
