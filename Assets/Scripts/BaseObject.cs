using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour {

	// Use this for initialization
	protected void Start () {
		l ("a");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void l(object o){
		Debug.Log (o);
	}
}
