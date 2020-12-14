using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatingCard : MonoBehaviour {
	public SpriteRenderer sr;
	public TextMeshPro title;

	public Sprite defaultBackgroundImg;

	[HideInInspector]
	public CardInfo cardInfo;

	[HideInInspector]
	public float target_y;

	const float INIT_Y = 0.6f;
	const float SPEED = 0.13f;
	const float ROTATION_MAX = 50.0f;


	// Start is called before the first frame update
	void Start() {
		if (cardInfo.background != null) {
			sr.sprite = cardInfo.background;
		} else {
			sr.sprite = defaultBackgroundImg;
		}
		title.text = cardInfo.title;
		transform.position = new Vector3(transform.position.x, INIT_Y, transform.position.z);
		float new_y = 180.0f + Random.Range(-ROTATION_MAX, ROTATION_MAX);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, new_y, transform.eulerAngles.z);
	}


	// Update is called once per frame
	void Update() {
		if (transform.position.y > target_y) {
			transform.position -= Time.deltaTime * SPEED * Vector3.up;
			if (transform.position.y < target_y) {
				transform.position = new Vector3(transform.position.x, target_y, transform.position.z);
			}
		}
	}
}
