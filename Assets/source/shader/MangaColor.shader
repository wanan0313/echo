Shader "Custom/MangaColorDots_Colorful"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _DotSize ("Dot Size", Range(1, 20)) = 4.72
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _DotSize;

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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // 彩色点阵函数
            inline float added(float2 sh, float d)
            {
                float2 rsh = sh * 0.70710678;
                return 0.5 + 0.25 * cos((rsh.x + rsh.y) * d) + 0.25 * cos((rsh.x - rsh.y) * d);
            }

            // 彩色描边函数
            inline float3 Outline(float2 uv)
            {
                float4 lines = float4(0.30,0.59,0.11,1.0);
                lines.rgb *= 4.0; lines /= 4.0;

                float S512 = (1.0 / 512.0) * 2.0;

                float s11 = dot(tex2D(_MainTex, uv + float2(-S512,-S512)), lines);
                float s13 = dot(tex2D(_MainTex, uv + float2(S512,-S512)), lines);
                float s21 = dot(tex2D(_MainTex, uv + float2(-S512,0.0)), lines);
                float s23 = s21;
                float s31 = dot(tex2D(_MainTex, uv + float2(-S512,S512)), lines);
                float s32 = dot(tex2D(_MainTex, uv + float2(0,S512)), lines);
                float s33 = dot(tex2D(_MainTex, uv + float2(S512,S512)), lines);

                float t1 = s13 + s33 + (2.0*s23) - s11 - (2.0*s21) - s31;
                float t2 = s31 + (2.0*s32) + s33 - s11 - (2.0*s12) - s13;

                if ((t1*t1 + t2*t2) > 0.04)
                    return float3(-1,-1,-1);
                return float3(0,0,0);
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float3 texColor = tex2D(_MainTex, uv).rgb;

                // 对 RGB 通道分别做 smoothstep
                texColor.r = smoothstep(0.4+(_DotSize/8)-0.6, 0.7+(_DotSize/8)-0.6, texColor.r);
                texColor.g = smoothstep(0.4+(_DotSize/8)-0.6, 0.7+(_DotSize/8)-0.6, texColor.g);
                texColor.b = smoothstep(0.4+(_DotSize/8)-0.6, 0.7+(_DotSize/8)-0.6, texColor.b);

                // 彩色点阵：每个通道独立计算
                float2 coord = uv * _DotSize;
                float2 gv = frac(coord) - 0.5;
                float dist = length(gv);

                float3 dotMask;
                dotMask.r = step(texColor.r, dist);
                dotMask.g = step(texColor.g, dist);
                dotMask.b = step(texColor.b, dist);

                texColor *= dotMask;

                // 彩色轮廓线加点阵
                float3 outline = Outline(uv).g * 0.5; // 调整强度
                texColor = texColor + outline;

                return float4(texColor,1.0);
            }
            ENDCG
        }
    }
}
