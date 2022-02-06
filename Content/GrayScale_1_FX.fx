#if OPENGL
    #define VS_SHADERMODEL vs_3_0
    #define PS_SHADERMODEL ps_3_0
#else
    #define VS_SHADERMODEL vs_4_0_level_9_1
    #define PS_SHADERMODEL ps_4_0_level_9_1
#endif


struct VertexShaderOutput
{
    float4 Color : COLOR0;
    float2 texCord : TEXCOORD0;
}

sampler2D texSampler;

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float4 col = tex2D(texSampler, input.texCord);
    float avCol = (col.r + col.g, col.b) / 3;
    float4 mulCol = input.Color.rgb * avCol;
    return float4(mulCol, col.a);
}

technique BasicColorDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};