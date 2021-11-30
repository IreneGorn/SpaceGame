using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounderyScript : MonoBehaviour
{
    //срабатывает при выходе одного объекта из другого
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
