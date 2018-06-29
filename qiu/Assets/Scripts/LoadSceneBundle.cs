using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/// <summary>
/// 脚本位置：需要加载物体的场景中任意物体上
/// 脚本功能：加载物体
/// </summary>
public class LoadSceneBundle : MonoBehaviour
{
        
    private string url;
    private string assetname;
 
    void Start ()
    {
        // 下载压缩包，写出具体的名字
       //url = "file://" + Application.dataPath + "/earth.unity3d";
        url = Application.absoluteURL + "/../earth.unity3d";
        // unity预制体名字，即被打包的场景名字叫 2
        assetname = "earth";
 
        StartCoroutine (Download ());
    }
 
    IEnumerator Download ()
    {
 
        WWW www = new WWW (url);
        yield return www;
        if (www.error != null) {
            Debug.Log (www.error);
        } else {
            AssetBundle bundle = www.assetBundle;
            SceneManager.LoadSceneAsync ("earth");
            print ("跳转场景");
            // AssetBundle.Unload(false)，释放AssetBundle文件内存镜像，不销毁Load创建的Assets对象
            // AssetBundle.Unload(true)，释放AssetBundle文件内存镜像同时销毁所有已经Load的Assets内存镜像
            bundle.Unload (false);
        }
 
        // 中断正在加载过程中的WWW
        www.Dispose ();
    }
 
}