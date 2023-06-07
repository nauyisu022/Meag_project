using UnityEngine;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // 获取VideoPlayer组件
        videoPlayer = GetComponent<VideoPlayer>();

        // 播放视频
        videoPlayer.Play();
    }

    void Update()
    {
        // 检测视频是否播放完毕
        if (!videoPlayer.isPlaying)
        {
            // 视频播放完毕的处理逻辑
            CameraManager.Instance.switchCamera("宿舍Camera");
        }
    }
}
