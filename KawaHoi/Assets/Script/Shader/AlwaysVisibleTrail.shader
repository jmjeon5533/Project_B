Shader "Custom/AlwaysVisibleTrail"
{
    Properties
    {
        _Color ("Color", Color) = (1, 0, 0, 0.5)  // �⺻ ���İ� 0.5 (������)
        _Emission ("Emission", Color) = (1, 0, 0, 1) // ��� ȿ�� ����
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha  // ������ ����
            ZWrite Off  // ���� ���ۿ� ������� ���� (������Ʈ �ڿ����� ���̰�)
            ZTest Always // �׻� �׷���

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
                // ���İ� ���� (������)
                half4 col = i.color;
                col.a *= 0.5; // ���İ� ����

                // ��� ȿ���� ���� Emission ����
                half3 emission = col.rgb * 2.0; // ��� ���� ���� (2.0 ����)
                col.rgb += emission;

                return col;
            }
            ENDHLSL
        }
    }
}
