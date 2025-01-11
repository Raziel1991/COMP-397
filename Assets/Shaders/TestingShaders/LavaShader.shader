Shader "Custom/LavaShader"
{
    Properties
    {
        _MainTex ("Base Texture (Albedo)", 2D) = "white" {}
        _DistortionTex ("Distortion Texture", 2D) = "white" {}
        _EmissionColor ("Emission Color", Color) = (1, 0.5, 0.0, 1)
        _ScrollSpeed ("Scroll Speed", Float) = 0.5
        _DistortionStrength ("Distortion Strength", Float) = 0.2
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uvDistortion : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _DistortionTex;
            float4 _MainTex_ST;
            float4 _EmissionColor;
            float _ScrollSpeed;
            float _DistortionStrength;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                // Add scrolling effect to the distortion texture
                o.uvDistortion = v.uv + float2(_Time.y * _ScrollSpeed, _Time.y * _ScrollSpeed * 0.5);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Base lava texture
                fixed4 baseColor = tex2D(_MainTex, i.uv);

                // Distortion texture adds flow effect
                fixed4 distortion = tex2D(_DistortionTex, i.uvDistortion);
                float2 distortedUV = i.uv + (distortion.rg - 0.5) * _DistortionStrength;

                // Apply distortion to base texture
                fixed4 lavaColor = tex2D(_MainTex, distortedUV);

                // Add emissive glow
                fixed4 emission = _EmissionColor * (lavaColor.r + lavaColor.g);

                // Final output with transparency
                return lavaColor + emission;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
