Shader "Custom/Gaussian Blur"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BlurSize("Blur Size", Float) = 1
    }
        SubShader
        {
       
            Pass
            {
                NAME "GAUSSIAN_BLUR_VERTICAL"
                
            }
            Pass
            {
                NAME "GAUSSIAN_BLUR_HORIZONTAL"
                
            }
        }
            
}