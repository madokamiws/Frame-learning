using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class LoadSceneManager : SingletonPatternBase<LoadSceneManager>
{
    /// <summary>
    /// 切换到当前场景
    /// </summary>
    public void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// 切换到下一个场景
    /// </summary>
    public void LoadNextScene( bool isCyclical = false)
    {
        int xx = SceneManager.GetActiveScene().buildIndex + 1;
        if (xx > SceneManager.sceneCountInBuildSettings - 1)
        {
            if (isCyclical)
            {
                xx = 0;
            }
            else
            {
                return;
            }

        }
        SceneManager.LoadScene(xx);

    }
    //public void LoadSceneAsync(string sceneName, UnityAction completed = null, LoadSceneMode mode = LoadSceneMode.Single)
    //{
    //    MonoManager.Instance.StartCoroutine(LoadSceneCoroutine(sceneName, completed, mode));
    //}
    //IEnumerator LoadSceneCoroutine(string sceneName, UnityAction completed = null, LoadSceneMode mode = LoadSceneMode.Single)
    //{
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
    //    yield return asyncOperation;//等待资源加载完毕
    //    completed?.Invoke();
    //}

    /// <summary>
    /// <para>异步加载场景。默认情况下，成功加载场景后，会切换到该场景。</para>
    /// <para>可以控制外部进度条的显示。</para>
    /// </summary>
    /// <param name="sceneBuildIndex">要加载的场景在Build Settings窗口中的索引。</param>
    /// <param name="loading">加载中的回调。只要在加载中，就会不断地执行这个回调。一般用于进度条的显示。</param>
    /// <param name="completed">加载完毕后的回调。</param>
    /// <param name="setActiveAfterCompleted">加载场景完毕后，是否切换到该场景。</param>
    /// <param name="mode">加载场景的模式。默认是LoadSceneMode.Single，表示会卸载原来的场景，再切换到新场景。LoadSceneMode.Additive表示会将新场景叠加在原来的场景中。</param>
    public void LoadSceneAsync(int sceneBuildIndex, UnityAction<float> loading = null, UnityAction<AsyncOperation> completed = null, bool setActiveAfterCompleted = true, LoadSceneMode mode = LoadSceneMode.Single)
    {
        ////如果要加载的场景的索引不合法，则返回。
        //if (!IsSceneBuildIndexValid(sceneBuildIndex))
        //    return;

        //开启协程进行异步加载。
        MonoManager.Instance.StartCoroutine(LoadSceneAsyncCoroutine(sceneBuildIndex, loading, completed, setActiveAfterCompleted, mode));
    }
    IEnumerator LoadSceneAsyncCoroutine(int sceneBuildIndex, UnityAction<float> loading = null, UnityAction<AsyncOperation> completed = null, bool setActiveAfterCompleted = true, LoadSceneMode mode = LoadSceneMode.Single)
    {
        //异步操作对象，记录了异步操作的数据。
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex, mode);

        //设置为false，则即使场景加载完毕，也不会切换过去。当场景加载完毕，再次把这个值复制为true，才会切换过去。
        asyncOperation.allowSceneActivation = false;

        //加载场景的过程中，提供给外部执行的回调。一般用于进度条的显示。
        while (asyncOperation.progress < 0.9f)
        {
            loading?.Invoke(asyncOperation.progress);
            yield return null;
        }

        //当asyncOperation.allowSceneActivation为false，则asyncOperation.progress最多只能到达0.9，我们人为让它凑成整数1，方便外部进度条的显示。
        loading?.Invoke(1f);

        //加载场景完毕之后，如果把这个变量设置为true，则会切换到该场景。如果为false，则不会切换到该场景。
        asyncOperation.allowSceneActivation = setActiveAfterCompleted;

        //加载场景完毕之后执行的回调。
        completed?.Invoke(asyncOperation);
    }
}
