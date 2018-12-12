Shader "Hidden/SlicerFx"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Cull Off
        ZTest Always
        ZWrite Off

        Tags{ "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float rand(float2 co) {
                return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float2 uv = i.uv;
                float threshould = sin(rand(_Time.z / 1.0))*0.3 + 0.3 ;

                if (uv.x > threshould+ (rand(uv.y)*0.2-0.2) ) {
                    col = tex2D(_MainTex, uv);
                }
                else {
                    col = tex2D(_MainTex, float2(threshould, uv.y));
                }
                return col;
            }
        ENDCG
        }
    }
}