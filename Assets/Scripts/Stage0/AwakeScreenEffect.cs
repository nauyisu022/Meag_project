using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class AwakeScreenEffect : MonoBehaviour
{
    int blink = 0;
    public float speed = 0.2f;
    [Range(0f, 1f)]
    [Tooltip("купя╫Ь╤х")]
    public float progress = 0.0f;
    public Shader shader;
    
    [SerializeField]
    Material material;
    Material Material
    {
        get
        {
            if (material == null)
            {
                material = new Material(shader);
                material.hideFlags = HideFlags.DontSave;
            }
            return material;
        }
    }
    private void Start()
    {
        progress = 0.0f;
    }
    void Update()
    {
        if(SceneManager.Instance.jumpToClassroom == false)
        {
            if (progress >= 0.5 && blink == 0)
            {
                blink = 1;
            }
            if (progress <= 0 && blink == 1)
            {
                blink = 2;
            }
            if (progress < 0.5 && blink == 0)
            {
                progress += speed * Time.deltaTime;
            }
            if (progress > 0 && blink == 1)
            {
                progress -= speed * Time.deltaTime;
            }
            if (progress < 1 && blink == 2)
            {
                progress += speed * Time.deltaTime;
            }
        }


    }
    void OnDisable()
    {
        if (material)
        {
            DestroyImmediate(material, true);
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Material.SetFloat("_Progress", progress);
        Graphics.Blit(src, dest, material);
    }
}
