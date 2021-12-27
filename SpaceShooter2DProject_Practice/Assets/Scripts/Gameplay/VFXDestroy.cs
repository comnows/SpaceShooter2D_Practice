using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDestroy : MonoBehaviour
{
    public void DestroySelf_VFX()
    {
        Destroy(gameObject.transform.root.gameObject);
    }
}
