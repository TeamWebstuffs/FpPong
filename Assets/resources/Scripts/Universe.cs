using UnityEngine;
using System.Collections;

public class Universe : MonoBehaviour {

	public int playerOneScore = 0;
	public int playerTwoScore = 0;
	public bool key_Left = false;
	public bool key_Right = false;
	public bool key_Space = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckKeys();
	}
	
	public void CheckKeys () {
		key_Left = Input.GetKey(KeyCode.LeftArrow);
		key_Right = Input.GetKey(KeyCode.RightArrow);
		key_Space = Input.GetKey(KeyCode.Space);
	}
}
