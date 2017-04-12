using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseIconScript : MonoBehaviour {

	Image imageComponent;
	public GameObject bagSize;
	private bagSizeScript bagSizeScript;

	public Sprite dashIcon;
	public Sprite noIcon;
	public Sprite smashIcon;

	// Use this for initialization
	void Start () {
		bagSize = GameObject.Find ("bagSize");
		bagSizeScript = (bagSizeScript)bagSize.GetComponent (typeof(bagSizeScript));
		imageComponent = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bagSizeScript.size <= 2f) {
			imageComponent.sprite = dashIcon;
		} else if (bagSizeScript.size > 2f && bagSizeScript.size < 6f) {
			imageComponent.sprite = noIcon;
		} else if (bagSizeScript.size >= 6f) {
			imageComponent.sprite = smashIcon;
		}
	}
}
