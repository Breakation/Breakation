using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIGame : MonoBehaviour {

	public Text movesMadeLabel;
	public Text timeElapsedLabel;
	public Text endingText;

	void Update() {

        LightsOutManager instance = LightsOutManager.Instance;
		movesMadeLabel.text = "Moves made: " + instance.numberOfClicks.ToString ();

		if (instance.elapsedTime < 60) {
			timeElapsedLabel.text = "Time elapsed: " + instance.elapsedTime.ToString ();
		} else {
			int seconds = instance.elapsedTime % 60;
			int minutes = instance.elapsedTime / 60;

			timeElapsedLabel.text = "Time elapsed: " + minutes + "m " + seconds + "s";
			endingText.text = "Congratulations";
		}
	}
}