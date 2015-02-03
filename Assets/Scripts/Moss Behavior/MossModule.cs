using UnityEngine;
using System.Collections;


namespace WLB
{
	public class MossModule : MonoBehaviour 
	{
		public int mossCount = 3;
		public int maxMoss = 5;
		public Transform lightPosition;
		public GameObject mossLightPrefab;

		private GameObject heldLight;
		private bool holdingLight = false;

		private void FixedUpdate()
		{
			if(Input.GetKeyDown(KeyCode.Q) && mossCount > 0)
			{
				mossCount -= 1;
				GameObject light = Instantiate(mossLightPrefab, lightPosition.position, Quaternion.identity) as GameObject;
				holdingLight = true;
				heldLight = light;
				heldLight.rigidbody2D.gravityScale = 0;
			}

			if(Input.GetKeyUp(KeyCode.Q))
			{
				heldLight.rigidbody2D.gravityScale = 1;
				holdingLight = false;
			}

			if(holdingLight)
			{

				heldLight.transform.position = lightPosition.position;
			}
		}
	}
}
