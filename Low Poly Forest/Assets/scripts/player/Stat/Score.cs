using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;

	public float seconds, minutes;


	void Start () {
		scoreText = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(Time.time/60f);
		seconds = (int)(Time.time % 60f);
		scoreText.text = minutes.ToString ("00") + seconds.ToString ("00");
	}
}