using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpactIcon : MonoBehaviour {
	public Image sr;
	public Image arrow1;
	public Image arrow2;
	public Image arrow3;

	public QualityIcons qualityIcons;


	// Start is called before the first frame update
	void Awake() {
		sr.enabled = false;
		arrow1.enabled = false;
		arrow2.enabled = false;
		arrow3.enabled = false;
	}


	// Sets the visuals of this icon (and its corresponding arrow) according to this impact
	public void setImpact(Impact impact) {
		sr.sprite = qualityIcons.icons[(int)impact.quality];
		sr.enabled = true;
		Sprite arrowSprite = impact.decrease ? qualityIcons.downArrow : qualityIcons.upArrow;
		arrow1.enabled = true;
		arrow1.sprite = arrowSprite;
		if (impact.amount > Amount.LOW) {
			arrow2.sprite = arrowSprite;
			arrow2.enabled = true;
		}
		if (impact.amount > Amount.MEDIUM) {
			arrow3.sprite = arrowSprite;
			arrow3.enabled = true;
		}
	}
}
