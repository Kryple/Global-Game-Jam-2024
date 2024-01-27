using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffectSystem : MonoBehaviour
{
	[SerializeField] private GameObject mainCamera;

	[SerializeField] private List<float>  parallaxEffect;
	[SerializeField] private List<GameObject> backgroundObjects;

	private List<float> lengthOfBG = new List<float>();
	private List<float> startPos = new List<float>();
	private float currentScale;
	private readonly float defaultZoom = 10f;

	private void Start()
	{
		for (int i = 0; i < this.backgroundObjects.Count; i++)
		{
			this.startPos.Add(new float());
			this.lengthOfBG.Add(new float());

			this.startPos[i] = this.backgroundObjects[i].transform.position.x;
			this.lengthOfBG[i] = this.backgroundObjects[i].GetComponentInChildren<SpriteRenderer>().bounds.size.x;
		}
	}

	private void FixedUpdate()
	{
		//this.currentScale = this.mainCamera.GetComponent<Camera>().orthographicSize / 10f;

		for (int i = 0; i < this.backgroundObjects.Count; i++)
		{
			float temp = (this.mainCamera.transform.position.x * (1 - this.parallaxEffect[i]));
			float dist = (this.mainCamera.transform.position.x * this.parallaxEffect[i]);

			this.backgroundObjects[i].transform.position = new Vector3(
				this.startPos[i] + dist,
				this.backgroundObjects[i].transform.position.y,
				this.backgroundObjects[i].transform.position.z
				);

			if (temp > this.startPos[i] + this.lengthOfBG[i])
			{
				this.startPos[i] += this.lengthOfBG[i];
			}
			else if (temp < this.startPos[i] - this.lengthOfBG[i])
			{
				this.startPos[i] -= this.lengthOfBG[i];
			}
		}
	}
}
