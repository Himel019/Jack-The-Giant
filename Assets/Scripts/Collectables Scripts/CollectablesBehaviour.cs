using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyCollectable", 10f);
    }

    private void DestroyCollectable() {
        gameObject.SetActive(false);
    }
}
