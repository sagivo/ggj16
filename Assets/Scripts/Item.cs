using UnityEngine;
using System.Collections;

public class Item : BaseObject {

	public enum ItemState {Idle = 0, Angry = 1, SuperAngry = 2, Broken = 3};
	public Sprite[] stateSprites;
	SpriteRenderer spriteRenderer;
	public int[] maxRetriesPerState = new int[]{1, 3, 5};
	public int retries = 0;
	public ItemState state = ItemState.Idle;
	public System.Action OnStateChange;
	public System.Action OnAsk;
	public float[] minAsksPerState = new float[]{ 2f, 2f, 2f };
	public float[] maxAsksPerState = new float[]{ 3f, 3f, 3f };

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		state = ItemState.Idle;
		spriteRenderer.sprite = stateSprites [(int)state];
	}

	// Use this for initialization
	protected new void Start () {		
		base.Start ();

		Invoke ("askAction", Random.Range( minAsksPerState[(int)state], maxAsksPerState[(int)state]));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void askAction(){
		if (retries++ >= maxRetriesPerState [(int)state]) {
			state++; 
			spriteRenderer.sprite = stateSprites [(int)state];
			retries = 0;
			if (OnStateChange != null)
				OnStateChange ();
		} else {
			if (OnAsk != null)
				OnAsk ();			
		}

		if (state != ItemState.Broken)
			Invoke ("askAction", Random.Range( minAsksPerState[(int)state], maxAsksPerState[(int)state]));
	}

	void reset(){
		state--;
		if (OnStateChange != null)
			OnStateChange ();
	}


}
