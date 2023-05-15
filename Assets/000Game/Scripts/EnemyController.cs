using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int newPosX;
    public int newPosY;
    public int newPosZ;

    private void OnValidate()
    {
        transform.position = new Vector3(newPosX, newPosY, newPosZ);
    }
}
