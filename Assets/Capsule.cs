using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private void Awake()
    {
        EventCenterManager.Instance.AddListener("开工", Draw);
    }
    public void Draw()
    {
        transform.Rotate(Vector3.forward, 5f);
        Debug.Log("我是美术，我在画画");
    }

    private void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener("开工", Draw);
    }
}
