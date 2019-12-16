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
                if (k != null)
                {
                    Instantiate(bullet, hit.collider.transform.position, Quaternion.identity).transform.SetParent(hit.transform);
                }
            }
        }
    }
}
