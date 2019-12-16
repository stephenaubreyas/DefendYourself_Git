using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapIN : MonoBehaviour
{
	#region RequiredComponents

	public Transform player;
	public Transform MiniMapBorder;
	public bool ChangeMiniMapBorderColor = true;
	Image MiniMapBorderImage;

	#endregion

	void Start()
	{
		if (ChangeMiniMapBorderColor)
		{
			MiniMapBorderImage = MiniMapBorder.GetComponent<Image>();
			MiniMapBorderImage.color = new Color(Random.value, Random.value, Random.value, 255);
			StartCoroutine(ChangeImageBorderColour());
		}
	}

	void LateUpdate()
	{
		MiniMap2Player();
	}

	//Main Code...
	#region Code

	void MiniMap2Player()
	{
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;

		transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
	}

	IEnumerator ChangeImageBorderColour()
	{
		yield return new WaitForSeconds(5f);
		MiniMapBorderImage.color = new Color(Random.value, Random.value, Random.value, 255);
	}

	#endregion
}
