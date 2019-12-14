using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefender : MonoBehaviour
{
    [Header("Ground")]
    public Renderer cRenderer;

    public GameObject cubePrefab;

    public Vector3 pos;

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

        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(cubePrefab, x, Quaternion.identity).transform.SetParent(this.transform);
        }
    }
}
