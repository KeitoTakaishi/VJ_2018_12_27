Shader "Custom/HDRmaterial" {
    Properties {
        _MainTex ("Font Texture", 2D) = "white" {}
        [HDR]
        _Color ("Text Color", Color) = (1,1,1,1)
  }

  SubShader {

  Tags {
    //"Queue"="Transparent"
    "IgnoreProjector"="True"
    //"RenderType"="Transparent"
    "PreviewType"="Plane"
  }
  Lighting Off
  Cull Off 
  ZTest Always
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha

  Pass {
    CGPROGRAM
    #pragma vertex vert
    #pragma fragment frag

    #include "UnityCG.cginc"

  struct appdata_t {
    float4 vertex : POSITION;
    fixed4 color : COLOR;
    float2 texcoord : TEXCOORD0;
  };

  struct v2f {
    float4 vertex : SV_POSITION;
    fixed4 color : COLOR;
    float2 texcoord : TEXCOORD0;
  };

  sampler2D _MainTex;
  uniform float4 _MainTex_ST;
  uniform fixed4 _Color;

  v2f vert (appdata_t v)
  {
    v2f o;
    fixed4 p = v.vertex;
    //p.z = 0.5*sin(_Time.z*1.0 + p.y*10000.0);
    o.vertex = UnityObjectToClipPos(p);
    o.color = v.color * _Color;
    o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
    return o;
  }

    fixed4 frag (v2f i) : SV_Target
  {
    fixed4 col = fixed4(1.0, 0.0, 1.0, 1.0);
    fixed2 uv = i.texcoord;
    //uv.x += 0.1*sin(_Time.z/ 4.0);
    //uv.y += 0.1*sin(_Time.z/4.0);
    col = tex2D(_MainTex, uv) * _Color;
    
    return col;
  }
  ENDCG
  }
  }
	FallBack "Diffuse"
}
