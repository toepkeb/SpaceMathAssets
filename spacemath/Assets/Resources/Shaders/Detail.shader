Shader "Custom Shaders/Detail" {
	Properties {
	  _Color ("MainColor", color) = (1, 1, 1, 1)
	  _Light ("Brightness", Range (1, 10)) = 2
      _MainTex ("Texture", 2D) = "white" {}
      //_BumpMap ("Bumpmap", 2D) = "bump" {}
      _Detail ("Detail", 2D) = "gray" {}
	  _Texture2D ("OverlayTex", 2D) = "white" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" "LightMode" = "Always"}
	  //ZWrite Off
	  Cull Off
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
          //float2 uv_BumpMap;
          float2 uv_Detail;
		  float2 uv_Texture2D;
		  float uv_Light;
      };
      sampler2D _MainTex;
      sampler2D _Detail;
	  sampler2D _Texture2D;
	  float _Light;
	  fixed4 _Color;
	  //sampler2D _BumpMap;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * _Light;
		  o.Albedo *= tex2D (_Texture2D, IN.uv_Texture2D).rgb * _Color * _Light;
          o.Albedo *= tex2D (_Detail, IN.uv_Detail).rgb * 2;
          //o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }