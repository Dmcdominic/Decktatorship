using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QualityDisplays : MonoBehaviour {

	public Image background;
	public List<Image> back_images;
	public List<Image> fill_images;

	public QualityIcons qualityIcons;
	public regionView region_view;

	private NetObject thisNetObj;


	// Start is called before the first frame update
	void Start() {
		thisNetObj = GetComponentInParent<NetObject>();
		Debug.Assert(back_images.Count == QualityStates.NUM_QUALITIES);
		Debug.Assert(fill_images.Count == QualityStates.NUM_QUALITIES);
		for (int i = 0; i < back_images.Count; i++) {
			Image image = back_images[i];
			image.sprite = qualityIcons.back_icons[i];
		}
		for (int i = 0; i < fill_images.Count; i++) {
			Image image = fill_images[i];
			image.sprite = qualityIcons.fill_icons[i];
		}
	}


	// Update is called once per frame
	void Update() {
		if (region_view.currentRegion != thisNetObj) {
			hide_all();
		} else {
			show_all();
		}
	}


	// Hides all the images
	private void hide_all() {
		foreach (Image image in back_images) {
			image.enabled = false;
		}
		foreach (Image image in fill_images) {
			image.enabled = false;
		}
	}


	// Shows all the images
	private void show_all() {
		foreach (Image image in back_images) {
			image.enabled = true;
		}
		for (int i=0; i < fill_images.Count; i++) {
			Image image = fill_images[i];
			image.enabled = true;
			float state = thisNetObj.netVariables.qualityStates.states[i];
			image.fillAmount = (state - QualityStates.min) / (QualityStates.soft_max - QualityStates.min);
		}
	}
}
