using UnityEngine;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Awake()
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
            Debug.Log("ha");
            CameraManager.Instance.switchCamera("����Camera");
            Destroy(this.gameObject.GetComponent<VideoToGame>());
        }
    }
}
