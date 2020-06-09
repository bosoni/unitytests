Shader "Example/Diffuse Texture" {
	Properties {
		_Splat0("Layer 1", 2D) = "white" {}
		_Splat1("Layer 2", 2D) = "white" {}
		_Splat2("Layer 3", 2D) = "white" {}
		_Splat3("Layer 4", 2D) = "white" {}
		_Control("Control (RGBA)", 2D) = "white" {}
	}

	SubShader {
		Tags { "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf Lambert
		#pragma exclude_renderers xbox360 ps3
		#pragma target 4.0
		struct Input {
			float2 uv_Splat0;
			float2 uv_Splat1;
			float2 uv_Splat2;
			float2 uv_Splat3;
			float2 uv_Control;
		};

		sampler2D _Control, _Splat0, _Splat1, _Splat2, _Splat3;
		void surf(Input IN, inout SurfaceOutput o)
		{
			fixed4 splat_control = tex2D(_Control, IN.uv_Control).rgba;
			fixed3 lay1 = tex2D(_Splat0, IN.uv_Splat0) * splat_control.r;
			fixed3 lay2 = tex2D(_Splat1, IN.uv_Splat1) * splat_control.g;
			fixed3 lay3 = tex2D(_Splat2, IN.uv_Splat2) * splat_control.b;
			//fixed3 lay4 = tex2D(_Splat3, IN.uv_Control) * splat_control.a;

			//o.Albedo.rgb = lay1 + lay2 + lay3 + lay4;
			o.Albedo.rgb = lay1 + lay2 + lay3;

		}
		ENDCG
	}
	Fallback "Diffuse"
}
