Shader "Custom/test" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
        Pass{

            CGPROGRAM
		    #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
		    #pragma target 3.0

    		sampler2D _MainTex;

    		struct Input {
	    		float2 uv_MainTex;
		    };

    		half _Glossiness;
    		half _Metallic;
    		fixed4 _Color;

           struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
           };

            v2f vert(appdata_base v){
                v2f o;
                float3 p;
                p = v.vertex.xyz;
                //p.x = 10.0 - modf(p.x, 20.0);

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
	FallBack "Diffuse"
}
