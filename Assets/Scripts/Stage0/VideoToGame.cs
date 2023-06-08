using UnityEngine;
using UnityEngine.Video;

public class VideoToGame : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject obj;

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
            obj.SetActive(true);
            Destroy(this.gameObject.GetComponent<VideoToGame>());
        }
    }
}
