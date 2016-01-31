using UnityEngine;
using System.Collections;

public class Item : BaseObject {

	public enum ItemState {Idle = 0, Angry = 1, SuperAngry = 2, Broken = 3};
	public Sprite[] stateSprites;
	public SpriteRenderer spriteRenderer;
	public int[] maxRetriesPerState = new int[]{1, 3, 5};
	public int retries = 0;
	public ItemState state = ItemState.Idle;
	public System.Action OnStateChange;
	public System.Action OnAsk;
	public System.Action OnReset;
	public AudioSource[] sounds;
	public float[] minAsksPerState = new float[]{ 2f, 2f, 2f };
	public float[] maxAsksPerState = new float[]{ 3f, 3f, 3f };
	public float[] holdToResetPerState = new float[]{ 2f, 2f, 2f };

	private Color originalColor;
	AudioSource activeSound;

	void Awake(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		state = ItemState.Idle;
		spriteRenderer.sprite = stateSprites [(int)state];
	}

	// Use this for initialization
	protected new void Start () {		
		base.Start ();
		originalColor = spriteRenderer.color;
		Invoke ("askAction", Random.Range( minAsksPerState[(int)state], maxAsksPerState[(int)state]));
	}
	
	// Update is called once per frame
	protected new void Update () {
	}

	void askAction(){
		if (retries++ >= maxRetriesPerState [(int)state]) {
			state++; 
			setItemPerNewState ();
		} else {
			if (OnAsk != null)
				OnAsk ();			
		}

		if (state != ItemState.Broken)
			Invoke ("askAction", Random.Range( minAsksPerState[(int)state], maxAsksPerState[(int)state]));
	}

	public void reset(){
		if (state > 0) {
			state--;
			setItemPerNewState ();
		}
	}

	void setItemPerNewState(){
		spriteRenderer.sprite = stateSprites [(int)state];
		retries = 0;
		if (activeSound.isPlaying)
			activeSound.Stop ();
		if (sounds.Length >= (int)state + 1) {
			activeSound = sounds [(int)state];
			activeSound.Play ();
		}
		if (OnStateChange != null)
			OnStateChange ();
	}

	public void press(){
		if (state == ItemState.Idle || state == ItemState.Broken){
			//don't do anything
			l("pressed, but shouldn't be");
		}
		else{
			//do things
			l("pressed");
			spriteRenderer.color = Color.blue;

			CancelInvoke ("askAction");
		}


	}

	public void release(){
		Invoke ("askAction", Random.Range( minAsksPerState[(int)state], maxAsksPerState[(int)state]));
		l("released");
		spriteRenderer.color = originalColor;
	}


}
