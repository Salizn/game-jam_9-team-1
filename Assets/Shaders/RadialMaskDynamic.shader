Shader "UI/RadialMaskDynamic"
{
    Properties
    {
        _Color ("Mask Color", Color) = (0,0,0,1)
        _Radius ("Radius", Range(0,1)) = 1
        _Softness ("Edge Softness", Range(0,1)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            float _Radius;
            float _Softness;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float dist = distance(i.uv, center);

                // Smoothstep creates a soft transition at the circle's edge
                float alpha = smoothstep(_Radius - _Softness, _Radius, dist);

                return half4(_Color.rgb, alpha * _Color.a);
            }
            ENDHLSL
        }
    }
}
