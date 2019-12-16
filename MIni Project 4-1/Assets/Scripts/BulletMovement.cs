using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //IEnumerator Start()
    //{
    //    yield return null;
    //}

    //// Update is called once per frame
    void Update()
    {
        if (transform.position.x < 12f && transform.position.x > -12f)
        {
            transform.Translate(Vector3.right * 15 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other" + other);
        if (other.CompareTag("Trigger"))
        {
            //bullets.Add(other.gameObject);
            Debug.Log("Entered?");
        }
    }
}
