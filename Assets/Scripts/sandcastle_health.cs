using UnityEngine;
using System.Collections;

public class sandcastle_health : MonoBehaviour {

	public int health = 3;

	private ArrayList sprites; 
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;
		sprites = new ArrayList();
		sprites.Add (Resources.Load ("Sprites/sandcastle", typeof (Sprite)));
		sprites.Add (Resources.Load ("Sprites/sandcastle-broken", typeof(Sprite)));
		sprites.Add (Resources.Load ("Sprites/sandcastle-dead", typeof(Sprite)));
		spriteRenderer.sprite = (Sprite) sprites [0];

	}
	
	// Update is called once per frame
	void Update () {
		this.updateSprite (health);
	}

	private void updateSprite(int curHealth){

		int index = 0;
		if (curHealth == 3) {
			index = 0;
		} else if (curHealth == 2) {
			index = 1;
		} else {
			index = 2;
		}
		spriteRenderer.sprite = (Sprite)sprites [index];
	}
	

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Ocean") {
			this.health -= 1;
		}
	}
}
