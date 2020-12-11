using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCardPlayed : MonoBehaviour {
	public FloatingCard floatingCardPrefab;
	public Decklist cardRegistry;

	const float d_floating_y = 0.01f;

	private SpriteRenderer sr;
	private float target_y;
	private NetObject thisNetObj;
	private long lastCTSTtime = 0;


	// Start is called before the first frame update
	void Start() {
		thisNetObj = GetComponentInParent<NetObject>();
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = null;
		target_y = transform.position.y + d_floating_y;
	}


	// called every frame
	private void Update() {
		if (thisNetObj.netVariables.cardToStack.Length > 0 && !thisNetObj.netVariables.lastCTSTtime.Equals(lastCTSTtime)) {
			lastCTSTtime = thisNetObj.netVariables.lastCTSTtime;
			CardInfo cardInfo = cardRegistry.getCardInfoByTitle(thisNetObj.netVariables.cardToStack);
			spawnFloatingCard(cardInfo);
		}
	}


	// Spawns a card above this point that floats down to it
	public void spawnFloatingCard(CardInfo cardInfo) {
		FloatingCard floatingCard = Instantiate(floatingCardPrefab, transform);
		floatingCard.cardInfo = cardInfo;
		floatingCard.transform.position = transform.position;
		floatingCard.target_y = target_y;
		target_y += d_floating_y;
	}
}
