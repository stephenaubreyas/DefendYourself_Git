using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDefender : MonoBehaviour
{
    [Header("Ground")]
    public Renderer cRenderer;

    public GameObject cubePrefab;

    public Vector3 pos;

    public LayerMask layerMask;

    public bool onButtonTouched;

    public GameObject bullet;

    public Canvas canvas;

    public GameObject k;

	[HideInInspector] public GameObject[] bullets;//Collection of pooled bullets A.k.a No.of.bullets.
	public int bulletPoolSize = 5;//How many bullets to keep on start.
	[HideInInspector] public int currentBullet = 0;//Index of the current bullet in the collection.

	private static PlayerDefender instance;

    public static PlayerDefender Instance
    {
        get
        {
            instance = FindObjectOfType<PlayerDefender>();
            return instance;
        }
    }

    private void Awake()
    {
        TouchControls.tData += CreateCube;
    }

	private void Start()
	{
		//Initialize the bullets collection.
		bullets = new GameObject[bulletPoolSize];
		//Loop through the collection... 
		for (int i = 0; i < bulletPoolSize; i++)
		{
			bullets[i] = (GameObject)Instantiate(bullet);
			bullets[i].SetActive(false);
		}
	}

	void CreateCube(TouchMovement touchData)
    {
        var x = Camera.main.ScreenToWorldPoint(new Vector3(touchData.StartPos.x, touchData.StartPos.y, 10));

        Ray ray = Camera.main.ScreenPointToRay(touchData.StartPos);

        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();

        PointerEventData ped = new PointerEventData(null);

        ped.position = touchData.StartPos;

        List<RaycastResult> results = new List<RaycastResult>();

        gr.Raycast(ped, results);


        if (results.Count <= 0)
        {
            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                k = Instantiate(cubePrefab, x, Quaternion.identity);
                k.transform.SetParent(this.transform);
            }
            else
            {
                if (k != null && !hit.collider.CompareTag("Ground"))
				{
					bullets[currentBullet].transform.position = hit.collider.transform.position;
					bullets[currentBullet].transform.rotation = Quaternion.identity;
					bullets[currentBullet].SetActive(true);

					//Instantiate(bullets[currentBullet], hit.collider.transform.position, Quaternion.identity).transform.SetParent(hit.transform);
					currentBullet++;
					if (currentBullet >= bulletPoolSize)
					{
						currentBullet = 0;
					}
				}
            }
        }
    }
}
