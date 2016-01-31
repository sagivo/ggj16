using UnityEngine;
using System.Collections;

public class shelfScaler : MonoBehaviour {

	public GameObject theSprite;
	public Camera theCamera;

	// Use this for initialization
	void Start () {
		ResizeSpriteToScreen (theSprite, theCamera, 1, 0);
	}

	// Update is called once per frame
	void Update () {

	}

	void ResizeSpriteToScreen(GameObject theSprite, Camera theCamera, int fitToScreenWidth, int fitToScreenHeight)
	{        
		SpriteRenderer sr = theSprite.GetComponent<SpriteRenderer>();

		theSprite.transform.localScale = new Vector3(1,1,1);

		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;

		float worldScreenHeight = (float)(theCamera.orthographicSize * 2.0);
		float worldScreenWidth = (float)(worldScreenHeight / Screen.height * Screen.width);

		if (fitToScreenWidth != 0)
		{
			Vector2 sizeX = new Vector2(worldScreenWidth / width / fitToScreenWidth,theSprite.transform.localScale.y);
			theSprite.transform.localScale = sizeX;
		}

		if (fitToScreenHeight != 0) {
			Vector2 sizeY = new Vector2 (theSprite.transform.localScale.x, worldScreenHeight / height / fitToScreenHeight);
			theSprite.transform.localScale = sizeY;
		} else {
			//Vector2 retain = new Vector2 (theSprite.transform.localScale.x, theSprite.transform.localScale.x);
			//theSprite.transform.localScale = retain;
		}
	}
}
