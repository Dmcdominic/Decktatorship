using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventPanel : MonoBehaviour {
	public TextMeshProUGUI title;
	public TextMeshProUGUI description;
	//public Image icon;
	//public Image backgroundImage;
	public EventOptionDisplay eventOptionDisplay1;
	public EventOptionDisplay eventOptionDisplay2;
	
	public QualityIcons qualityIcons;
	public Decklist cardRegistry;

	private EventCardInfo eventCardInfo;

	public bool optionChosen { get => _optionChosen; set => _optionChosen = value; }
	private bool _optionChosen = false;

	public NetObject thisNetObj { get => _thisNetObj; set => _thisNetObj = value; }
	private NetObject _thisNetObj;


	// early init
	private void Awake() {
		// child this to the Canvas
		transform.SetParent(MainCanvas.canvas.transform, false);
	}

	private void Start() {
		GetComponent<RectTransform>().SetLeft(0);
		GetComponent<RectTransform>().SetRight(0);
		GetComponent<RectTransform>().SetTop(0);
		GetComponent<RectTransform>().SetBottom(0);

		if (thisNetObj == null) thisNetObj = GetComponentInParent<NetObject>();
		setEventInfo(thisNetObj.netVariables.eventTitle, thisNetObj.ownedByThisClient());
	}


	// Initializes the card to use a particular CardInfo
	public void setEventInfo(string eventTitle, bool local_authority) {
		foreach (CardInfo cardInfo in cardRegistry.cardInfos) {
			if (!cardInfo) continue;
			if (cardInfo.title.Equals(eventTitle)) {
				eventCardInfo = cardInfo as EventCardInfo;
				break;
			}
		}
		if (eventCardInfo == null) {
			throw new System.Exception("No card with eventTitle: " + eventTitle + " found in CardRegistry");
		}

		title.text = eventCardInfo.title;
		description.text = eventCardInfo.description;
		//backgroundImage.sprite = cardInfo.background;
		//icon.sprite = cardIcons.IconSprites[(int)CardInfo.Effects.Effect1];

		eventOptionDisplay1.setEventOption(eventCardInfo.eventOption1, local_authority, this);
		eventOptionDisplay2.setEventOption(eventCardInfo.eventOption2, local_authority, this);
	}
}
