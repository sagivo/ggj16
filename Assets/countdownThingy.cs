using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class countdownThingy : BaseObject {

	public Text textAss;
	float timeLeft;
	float totalTime;

	void Start () {
		totalTime = (30 + (ApplicationModel.ObjectID * 10));
	}

	// Update is called once per frame
	void Update () {
		timeLeft = Mathf.Round(totalTime-Time.timeSinceLevelLoad);
		textAss.text = timeLeft.ToString();
		if (timeLeft == 0) {
			endLevel ();
		}
	}

	public void endLevel(){
		//things
		print("TIME IS UP");
		ApplicationModel.ObjectID++;
		Application.LoadLevel ("letter");
	}
}