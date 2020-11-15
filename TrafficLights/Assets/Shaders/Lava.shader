Shader "Custom/Lava"
{
    Properties
    {
        [PerRendererData] [HDR] _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
        _ExtrudePower ("Extrude Power", Range(0, 1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        //Cull Off
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float height;
        };

        #define PI 3.1415926535897932384626433832795
        
        half _Glossiness;
        half _Metallic;
        //fixed4 _Color;

        fixed _ExtrudePower;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
        UNITY_INSTANCING_BUFFER_END(Props)


        void vert (inout appdata_full v, out Input o) {

            UNITY_INITIALIZE_OUTPUT(Input,o)
            
            fixed edgeX = pow(pow(v.texcoord.x - 0.5, 2) * 4, 3);
            fixed edgeY = pow(pow(v.texcoord.y - 0.5, 2) * 4, 3);
            fixed edge = min(edgeX + edgeY, 1);
            
            fixed x = lerp(v.texcoord.x, 1, edge);
            fixed y = lerp(v.texcoord.y, 1, edge);

            fixed v1 = sin((x + _Time.y * 0.2) * 2 * PI * 5);
            fixed v2 = sin(20 * (x * sin(_Time.y * 0.5)
                                + y * cos(_Time.y * 0.3))
                            + _Time.y);

            fixed cx = x + .2 * sin(_Time.y * 0.2);
            fixed cy = y + .3 * cos(_Time.y * 0.3);
            fixed v3 = sin(sqrt(150 * (pow(cx, 2) + pow(cy, 2)) + 1) * 2 + _Time.y * 2);

            fixed key = v1 + v2 + v3;

            o.height = key / 3 * (1 - pow(edge, 0.5));
            
            v.vertex.xyz += v.normal * max(0, o.height) * _ExtrudePower;
        }
        
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = _Color;
            
            o.Albedo = 0;
            o.Emission = lerp(0, c.rgb, pow(max(0, IN.height), .5));
            // Metallic and smoothness come from slider variables
            o.Metallic = 0;
            o.Smoothness = 0;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
