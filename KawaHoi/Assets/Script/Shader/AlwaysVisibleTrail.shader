Shader "Custom/AlwaysVisibleTrail"
{
    Properties
    {
        _Color ("Color", Color) = (1, 0, 0, 0.5)  // 기본 알파값 0.5 (반투명)
        _Emission ("Emission", Color) = (1, 0, 0, 1) // 블룸 효과 색상
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha  // 반투명 설정
            ZWrite Off  // 깊이 버퍼에 기록하지 않음 (오브젝트 뒤에서도 보이게)
            ZTest Always // 항상 그려짐

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.position = TransformObjectToHClip(v.vertex.xyz);
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                // 알파값 적용 (반투명)
                half4 col = i.color;
                col.a *= 0.5; // 알파값 낮춤

                // 블룸 효과를 위한 Emission 설정
                half3 emission = col.rgb * 2.0; // 블룸 강도 조절 (2.0 정도)
                col.rgb += emission;

                return col;
            }
            ENDHLSL
        }
    }
}
