using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChef : MonoBehaviour {

	public void DestroyThisChef()
    {
        Destroy(this.gameObject);
    }
}
