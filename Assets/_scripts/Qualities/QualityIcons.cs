using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="custom/QualityIcons")]
public class QualityIcons : ScriptableObject {
	[SerializeField]
	private Quality orderReference; // not actually used
	public List<Sprite> icons;
	public List<Sprite> back_icons;
	public List<Sprite> fill_icons;
	public Sprite upArrow;
	public Sprite downArrow;
}
