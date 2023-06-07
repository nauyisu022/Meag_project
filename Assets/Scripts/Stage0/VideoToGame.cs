using UnityEngine;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // ��ȡVideoPlayer���
        videoPlayer = GetComponent<VideoPlayer>();

        // ������Ƶ
        videoPlayer.Play();
    }

    void Update()
    {
        // �����Ƶ�Ƿ񲥷����
        if (!videoPlayer.isPlaying)
        {
            // ��Ƶ������ϵĴ����߼�
            CameraManager.Instance.switchCamera("����Camera");
        }
    }
}
