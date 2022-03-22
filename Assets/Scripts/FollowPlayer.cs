using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float CarX, CarY, CarZ;

    //private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame

    private void Update()
    {
        CarX = player.transform.eulerAngles.x;
        CarY = player.transform.eulerAngles.y;
        CarZ = player.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY, CarZ - CarZ);
    }
    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
    }
}
