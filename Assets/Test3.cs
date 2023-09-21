using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,120,50),"·¢ËÍÃüÁî1"))
        {
            //GameObject go = GameObject.Find("Cube");
            //go.GetComponent<cube>().Write();
            EventCenterManager.Instance.Dispatch("¿ª¹¤");
             
        }
        if (GUI.Button(new Rect(150, 0, 120, 50), "·¢ËÍÃüÁî2"))
        {
            //GameObject go = GameObject.Find("Cube");
            //go.GetComponent<cube>().Write();
            EventCenterManager.Instance.Dispatch("»ğÑæ");

        }
    }

}
public class Image_attribute
{
    public List<TYPE> image_types;

}
public enum TYPE
{
    type1,
    type2,
    type3,
    type4
}