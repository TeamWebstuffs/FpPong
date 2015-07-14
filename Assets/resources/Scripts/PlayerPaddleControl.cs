using UnityEngine;
using System.Collections;

public class PlayerPaddleControl : MonoBehaviour {

	private Universe universeSS;
	public float speed = 30;

	// Use this for initialization
	void Start () {
		universeSS = GameObject.Find("Universe").GetComponent<Universe>();
	}
	
	// Update is called once per frame
	void Update () {

		if (universeSS.key_Left && transform.position.x > -7){
			transform.Translate(-speed * Time.deltaTime, 0, 0);
		}

		if (universeSS.key_Right && transform.position.x < 7){
			transform.Translate(speed * Time.deltaTime, 0, 0);
		}
	}

}
