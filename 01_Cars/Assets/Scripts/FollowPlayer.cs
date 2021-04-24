using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public GameObject player;
   public Vector3 offSet = new Vector3(0,5,6);
   
    private void Update()
    {
        transform.position=player.transform.position + offSet;
    }

}
