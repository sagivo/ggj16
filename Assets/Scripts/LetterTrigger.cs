using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LetterTrigger : MonoBehaviour {

	/*
		Level Order:
		
		Starting Set:
			0	vase
			0	glasses
			0	string
			
			Levels
			1	teddy
			2	book
			3	dynamite
			4	mirror
			5	kettle
			6	present */


	public GameObject letterStuff;

	//public RawImage letterImage;
	public Text letterText;
	//public Button letterButton;

	public bool isLetterActive;

	public int ObjectID;
	
	void Start () {
		ObjectID = ApplicationModel.ObjectID;

		LetterActivate ();
	}

	void Update () {
		//Fire1 on mobile by default is a touch. On a computer it's a click.
		//If the letter is off, it will turn on. If it's on, it will turn off.
		if (Input.GetKeyDown (KeyCode.Tab)) {
			ApplicationModel.ObjectID +=1;
			Debug.Log (ApplicationModel.ObjectID);
		}

		if (Input.GetMouseButtonUp(0) && isLetterActive == false) {
			LetterActivate();
			Debug.Log ("Trying to activate...");
		}
		if (Input.GetMouseButtonUp(1) && isLetterActive == true) {
			LetterDeActivate();
			Debug.Log ("Trying to deactivate...");
		}
		//Another script will control what the ObjectID is. This is just for checking it works
		if (Input.GetKeyDown (KeyCode.Space)) {
			ObjectID += 1;
			Debug.Log ("New Object!");
		}
	}

	public void LetterActivate () {
		ObjectID = ApplicationModel.ObjectID;
		letterStuff.SetActive (true);
		isLetterActive = true;;

		if (ObjectID == 0) {
			letterText.text = "Clive, darling,\n So sorry for dashing off like that — I was so looking forward to a quiet morning of cuddles before heading off for the book tour. But the call came in the middle of the night, and we both know it’s not a good idea to let an exorcism wait. Much easier to get a good, clean soul when the possession is still fresh.\nYou know the drill whle I’m away — keep Mom’s vase upright (she had such terrible posture near the end…) and unfog Dad’s glasses if he gets grumpy. We don’t want a repeat of last Christmas, so please keep an eye on them, for your sake if no one else’s :S\nAnd now they’ve got a new friend! Who would have thought such a kind-looking old granny had a demon inside her? I guess compulsively knitting pentagrams is a bit of a tell ;P One more for the collection! Just try to make sure it doesn’t start knitting itself, or you’ll be tying yourself in knots untangling it ;)\nxoxo,\nEliza";
		} else if (ObjectID == 1) {
			letterText.text = "Sweet sweet Clive,\nAlways sad to see kids getting possessed. You wanna believe that sort of thing won’t happen till you’re older, right? Once you hit 50, you’re really just waiting for it. But at four? sigh. Had to SIT on the poor girl until the spirit came out. Not sure if she cried more from that or from losing her teddy :( but trapped souls in toys don’t make for great playmates. Teddy misses her too, I think — it’d be darling if you could pet him now and then to keep him calm.\nThanks as always, dear,\nEliza";
		} else if (ObjectID == 2) {
			letterText.text = "Clive my love,\nWhat a night! The book signing was a hit — copies were flying off the table. This one fan got a little toooo friendly, though — started grabbing my hand while I was signing his copy. Bad move, kiddo: laying hands is MY move. Gotta say, though, trapping him in the book was great publicity! ;D\nIf he starts writing angry stuff, just turn the page.\nSquash the little bugger!\nxoxo,\nEliza";
		} else if (ObjectID == 3) {
			letterText.text = "OMG Clive,\nWhat. A. Treat. After so many mundane spirits, getting to work with a real celebrity? WOW. Alfred Nobel, like, THE Alfred Nobel. Clive! You know he always regretted inventing dynamite? What a scene — back from the dead, hoping to destroy the world’s stocks of TNT? quite an… explosive situation. Good thing I was there to… defuse it ;)\nSpeaking of which — the ol’ feller’s getting feisty in that little tube, so please keep an eye on him. He’s got a terribly… short fuse!\n(Sorry. Couldn’t resist.) kisses from Sweden,\nEliza";
		} else if (ObjectID == 4) {
			letterText.text = "Mirror, mirror, on the wall — who’s the most glamorous exorcist of all? ;P\nClive, I think this was my most action-movie fight so far — head to head with a hair stylist in a Soho salon, spells bouncing off the mirrored walls… all that was missing were some John Woo doves! \nIronic, almost — she spent so much of her life staring into the mirror, and she’s staring out of one! Just give her a few good taps if she starts peeking around.\nxoxo,\nEliza";
		} else if (ObjectID == 5) {
			letterText.text = "Pip pip! Tally ho! Eh, what! Hello from England, darling :)\nThe tour is going splendidly. Clive, I’m the toast of London! Just yesterday I was the guest of hono(u)r at a fancy tea party. At first I thought the butterflies in my stomach were just nerves, but then I realized: nope, my spirit-sense is tingling! One elegant gentleman face-down in a tray of crumpets later… :P it was quite a scene. And went over rawther well. British orders doubled for the book afterwards *\0/*\nGoodness, though, that man was...steaming mad! But I’m sure you’ll keep a lid on him :p\nxoxo,\nEliza";
		} else if (ObjectID == 6) {
			letterText.text = "Merry Christmas, Clive!\njk jk ;) this is one present you DON’T want to open. Eugh, I hate crashing parties, but spirits have no sense of timing. No respect for special occasions. And the look on that boy’s face when I walked out of there with his gift! Still, no present at all is better than a present with death in it. Or maybe that’s just me :P\nCake or death! Caaaake.\nhugs,\nEliza";
		}
		else {
			letterText.text = "Clive, things aren't working out. This just isn't working. Stuff ain't good. What I'm saying is... you broke the game";
		}
		Debug.Log ("Letter Activated!");
	}

	public void LetterDeActivate () {
		letterStuff.SetActive (false);
		isLetterActive = false;
		Debug.Log ("Letter DeActivated!");
	}

	public void LoadLevel () {
		Application.LoadLevel ("scean1");
	}
}
