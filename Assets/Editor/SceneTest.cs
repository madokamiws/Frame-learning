using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class SceneTest
{
    [MenuItem("我的彩蛋/方法1")]
    static void Method1()
    {
        LoadSceneManager.Instance.LoadActiveScene();
    }
    [MenuItem("我的彩蛋/方法2")]
    static void Method2()
    {

        LoadSceneManager.Instance.LoadNextScene(true);
    }
    [MenuItem("我的彩蛋/方法3")]
    static void Method3()
    {

    }
    [MenuItem("我的彩蛋/异步切换到场景1")]
    static void Method4()
    {

        LoadSceneManager.Instance.LoadSceneAsync(0,(obj)=>
        {
            Debug.Log("加载进度是：" + obj * 100 + "%");
        },(obj2)=>
        {
            Debug.Log("加载完成了！");
        });
    }



}
#endif