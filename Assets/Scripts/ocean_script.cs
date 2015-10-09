using UnityEngine;
using System.Collections;

public class ocean_script : MonoBehaviour {

	public float speed = -.01f;
	public float tideDistance = 1;

	private float xPos;
	private float yPos;
	private float yMax;
	private float topBorder;
	private bool highTide;
	// Use this for initialization
	void Start () {
		highTide = true;
		float dist = (transform.position - Camera.main.transform.position).z;
		topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y;
		topBorder = 16;
		yMax = transform.position.y - tideDistance;
	
	}
	
	// Update is called once per frame
	void Update () {
		xPos = transform.position.x;
		yPos = transform.position.y;
		transform.position = new Vector2(xPos, yPos + speed);

		if (transform.position.y < yMax && highTide ) {
			speed = speed * -1;
			highTide = false;
			yMax = yPos - tideDistance;
		}

		if (transform.position.y >= topBorder && !highTide) {
			speed = speed * -1;
			highTide = true;
		}
	
	}
}
