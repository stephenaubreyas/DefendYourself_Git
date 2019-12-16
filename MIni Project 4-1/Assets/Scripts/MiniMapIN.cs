using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapIN : MonoBehaviour
{
	#region RequiredComponents

	public Transform player;
	public bool ChangeMiniMapBorderColor = true;
	public Transform MiniMapBorder;

	#endregion

	void Start()
	{
		if (ChangeMiniMapBorderColor)
			MiniMapBorder.GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value, 255);
	}

	void LateUpdate()
	{
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;

		transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
	}
}
