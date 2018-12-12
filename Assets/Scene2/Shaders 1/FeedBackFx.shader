Shader "Custom/FeedBackFx" {
    Properties {
        _MainTex("Texture", 2D) = "white"{}
        _Color ("Color", Color) = (1,1,1,1)
        _Buffer("BufTexture", 2D) = "white"{}
        _N("N", Float) = 20.0
        _TimeSpeed("TimeSpeed", Float) = 0.05
        _dx("dx", Float) = 0.01
        _dy("dy", Float) = 0.01
         
    }
    SubShader
    {

        Cull Off
        ZTest Always
        Zwrite Off

        Tags{ "RenderType" = "opawue" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "SimplexNoise2D.cginc"

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
            sampler2D _Buffer;
            float4 _MainTex_ST;
            float _N;
            float _TimeSpeed; 
            float _dx, _dy;
            
            v2f vert(appdata v)
            {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = float2(i.uv);
                fixed4 col = tex2D(_MainTex,float2(uv));

                for(int i = 0; i < _N; i++){
                    uv.x += simplexNoise(float2(uv.y * 10.0, _Time.y * _TimeSpeed)) * 0.001 * _dx;
                    uv.y += simplexNoise(float2(uv.x * 10.0, _Time.y * _TimeSpeed)) * 0.001 * _dy;
                    //col += tex2D(_Buffer, uv) / _OffSetMag;
                    col += tex2D(_Buffer, uv) / _N;
                }
                col *= .7;
                return col;
            }
            ENDCG
        }
    }
        
}
