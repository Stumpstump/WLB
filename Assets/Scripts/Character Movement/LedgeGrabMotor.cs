using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WLB
{
	public class LedgeGrabMotor : MonoBehaviour 
	{
		public float climbTime;

		public Transform playerPos;
		public Transform climbPos;

		public Collider2D spaceCheck;
		public Collider2D ledgeCheck;

		public List<GameObject> gosInSpaceCheck = new List<GameObject>();
		public bool isLedge = false;
		public bool spaceEmpty = false;

		private bool isClimbing;

		private void Update()
		{
			Debug.Log ("isLedge " + isLedge + " spaceEmpty " + spaceEmpty);
			if(isLedge && spaceEmpty && !isClimbing)
			{
				StartCoroutine(Climb());
			}
		}


		private IEnumerator Climb()
		{
			isClimbing = true;

			Vector2 endPos = climbPos.position;
			Vector2 currentPos = playerPos.position;
			Debug.Log ("climbing");
			while(currentPos != endPos)
			{
				yield return null;
				Vector2.Lerp(currentPos, endPos, climbTime * Time.fixedDeltaTime);
			}

			isClimbing = false;
		}
	}
}
