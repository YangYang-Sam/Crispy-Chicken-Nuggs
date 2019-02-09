Shader "Hidden/Additive"
{
    Properties
    {
		_MainTex ("Main", 2D) = "black" {}
		_TargetTex ("Target", 2D) = "black" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
            };

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _TargetTex;
			float4 _TargetTex_ST;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
				float4 col = tex2D(_TargetTex, i.uv);
				col += tex2D(_MainTex, i.uv);

                return col;
            }
            ENDCG
        }
    }
}
