using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	private Universe universeSS;
	public bool isActive = false;
	public Vector3 angle = new Vector3(1, 0, -1);
	public float speed = 5;

	private Vector3 ballN, ballE, ballS, ballW;
	private float raySpacing = 0.4f;
	private Ray rayN, rayE, rayS, rayW;
	private bool colN, colE, colS, colW;
	public float rayDist;
	private RaycastHit rayHitInfo;
	private int maskBounce;

	// Use this for initialization
	void Start () {
		universeSS = GameObject.Find("Universe").GetComponent<Universe>();
		rayDist = 0.5f;
		maskBounce = 1 << 8;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActive && universeSS.key_Space){
			isActive = true;
		}

		if (isActive){
			transform.Translate(speed * angle * Time.deltaTime);
		}
	}

	void UpdateRaycastOrigins () {
		ballN = new Vector3(transform.position.x, transform.position.y, transform.position.z + raySpacing);
		ballS = new Vector3(transform.position.x, transform.position.y, transform.position.z - raySpacing);
		ballW = new Vector3(transform.position.x - raySpacing, transform.position.y, transform.position.z);
		ballE = new Vector3(transform.position.x + raySpacing, transform.position.y, transform.position.z);
	}


	//
	void FixedUpdate () {
		UpdateRaycastOrigins ();
		
		if (angle.x > 0.01f){
			//ball going right
			rayN = new Ray(ballN, new Vector3(1, 0, 0));
			rayS = new Ray(ballS, new Vector3(1, 0, 0));
			colN = Physics.Raycast(rayN, out rayHitInfo, rayDist, maskBounce);
			colS = Physics.Raycast(rayS, out rayHitInfo, rayDist, maskBounce);

			if (colN || colS){
				Debug.Log("Right Bounce");
				angle = new Vector3(Mathf.Abs(angle.x) * -1, angle.y, angle.z);
			}
		}else if (angle.x < 0.01f){
			//ball going left
			rayN = new Ray(ballN, new Vector3(-1, 0, 0));
			rayS = new Ray(ballS, new Vector3(-1, 0, 0));
			colN = Physics.Raycast(rayN, out rayHitInfo, rayDist, maskBounce);
			colS = Physics.Raycast(rayS, out rayHitInfo, rayDist, maskBounce);
			
			if (colN || colS){
				Debug.Log("Left Bounce");
				angle = new Vector3(Mathf.Abs(angle.x) * 1, angle.y, angle.z);
			}
		}

		if (angle.z < 0.01f){
			//ball going down
			rayW = new Ray(ballW, new Vector3(0, 0, -1));
			rayE = new Ray(ballE, new Vector3(0, 0, -1));
			colW = Physics.Raycast(rayW, out rayHitInfo, rayDist, maskBounce);
			colE = Physics.Raycast(rayE, out rayHitInfo, rayDist, maskBounce);
			
			if (colW || colE){
				Debug.Log("Bot Bounce");
				angle = new Vector3(angle.x, angle.y, Mathf.Abs(angle.z) * 1);
			}
		}else if (angle.z > 0.01f){
			//ball going up
			rayW = new Ray(ballW, new Vector3(0, 0, 1));
			rayE = new Ray(ballE, new Vector3(0, 0, 1));
			colW = Physics.Raycast(rayW, out rayHitInfo, rayDist, maskBounce);
			colE = Physics.Raycast(rayE, out rayHitInfo, rayDist, maskBounce);
			
			if (colW || colE){
				Debug.Log("Bot Bounce");
				angle = new Vector3(angle.x, angle.y, Mathf.Abs(angle.z) * -1);
			}
		}

	}
}
