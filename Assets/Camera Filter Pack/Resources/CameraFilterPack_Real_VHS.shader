Shader "CameraFilterPack/Chill_VHS_CookedEgg"
{
    Properties 
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ScanlineStrength ("Scanline Strength", Range(0, 0.1)) = 0.02
        _Saturation ("Saturation", Range(0, 1)) = 0.8
        _CoolTone ("Cool Tone", Range(0, 1)) = 0.1
    }

    SubShader 
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            Cull Off ZWrite Off ZTest Always
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _ScanlineStrength;
            float _Saturation;
            float _CoolTone;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // 扫描线（细条纹）效果
                float scan = sin(uv.y * 800.0) * _ScanlineStrength;

                float3 col = tex2D(_MainTex, uv).rgb;

                // 模拟亮度变化
                col += scan;

                // 降低饱和度
                float gray = dot(col, float3(0.3, 0.59, 0.11));
                col = lerp(gray.xxx, col, _Saturation);

                // 添加冷色调（轻微偏蓝+梦幻）
                float3 coolTint = float3(0.8, 0.9, 1.0);
                col = lerp(col, coolTint, _CoolTone);

                return float4(col, 1.0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
