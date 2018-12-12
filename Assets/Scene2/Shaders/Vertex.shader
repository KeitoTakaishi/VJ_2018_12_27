Shader "Custom/Vertex" {
	Properties {
        [HDR]
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
        _Amp ("Amplitude", Range(0.0, 10.0))  = 10.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
        Pass{
		CGPROGRAM
		#pragma target 3.0
        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
        float _Amp;

        struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };


            float rand(float2 co){
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert (appdata_base v)
            {
                v2f o;
                float3 p;
                //float r = rand(v.vertex.xz);
                p = v.vertex.xyz + v.normal * _Amp * sin(_Time.x*100.0+v.vertex.x*100.0+v.vertex.y+v.vertex.z);
                o.pos = UnityObjectToClipPos(p);
                o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target { 
                _Color.w = 0.1;
                return _Color; 
            }
            ENDCG
        }
     }
}
