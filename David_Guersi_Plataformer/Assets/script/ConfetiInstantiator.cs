using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfetiInstantiator : MonoBehaviour
{
    [SerializeField] GameObject confeti;

    public void ConfetiInstantiate()
    {
        Instantiate(confeti, gameObject.transform.position, Quaternion.identity);
    }
}
