using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	Universe universeSS; //universe subscript
	BallMovement ballMovementSS;
	public string scoreText;
	GameObject ball;
	GUIText guiTextComp; //The gui text component


	// Use this for initialization
	void Start () {
	
		guiTextComp = gameObject.GetComponent<GUIText>();

		ball = GameObject.Find("Ball");
		universeSS = GameObject.Find("Universe").GetComponent<Universe>();
		ballMovementSS = GameObject.Find("Ball").GetComponent<BallMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	

		guiTextComp.text = scoreText;
		scoreText = "p1 score: " + universeSS.playerOneScore + "\np2 score: " + universeSS.playerTwoScore;

		if(ball.transform.position.z > 12 && ballMovementSS.isActive){

			universeSS.playerOneScore += 1000;
			ballMovementSS.isActive = false;
			ballMovementSS.ResetPosition();

		}


		if(ball.transform.position.z < -12 && ballMovementSS.isActive){
			
			universeSS.playerTwoScore += 1000;
			ballMovementSS.isActive = false;
			ballMovementSS.ResetPosition();
		}

	}
}
