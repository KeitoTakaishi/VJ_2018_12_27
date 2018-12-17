Shader "Custom/Instance" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		[HDR]
		_Color("color", color) = (1.0, 1.0, 1.0, 1.0)
	}

    CGINCLUDE
        #include "UnityCG.cginc"
        #include "UnityLightingCommon.cginc"
        #include "AutoLight.cginc"

        struct Params
        {
            float3 emitPos;
            float3 position;
            float3 life;
            float3 size;
            float4 color;
            float4 StartColor;
            float4 EndColor;
        };

        StructuredBuffer<Params> buf;
        sampler _MainTex;
        float4x4 modelMatrix;
        float timer;
        
        struct v2f
        {
            float4 pos : SV_POSITION;
            float2 uv_MainTex : TEXCOORD0;
            float3 ambient : TEXCOORD1;
            float3 diffuse : TEXCOORD2;
            float3 color : TEXCOORD3;
            SHADOW_COORDS(4)
        };



        v2f vert(appdata_full v, uint id : SV_InstanceID)
        {
            Params p = buf[id];
             
            //float3 localPosition = v.vertex.xyz * (modf(timer, p.lifeTime))/100.0 + p.position;
            float3 localPosition = v.vertex.xyz * p.size.x + p.position;
           //float3 localPosition = simplexNoise(v.vertex.xyz);



            float3 worldPosition = mul(unity_ObjectToWorld, float4(localPosition, 1.0));
            
            v2f o;
            o.pos = mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
            o.color = p.color.rgb;
            return o;
        }
        
        fixed4 _Color;
        fixed4 frag(v2f i) : SV_Target
        {
        
            fixed4 output = _Color * fixed4(i.color, 0.1);
            return output;
         
        }
    ENDCG
	SubShader 
	{
		Tags { "Queue" = "Transparent" }
        
        Pass
        {
		CGPROGRAM
		#pragma vertex vert 
		#pragma fragment frag
		#pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
		#pragma target 5.0
		ENDCG
		}	
	}
}
