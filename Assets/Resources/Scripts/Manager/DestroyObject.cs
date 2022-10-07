using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnLevelWasLoaded(int level)
    {
        Destroy(gameObject);
    }
}
