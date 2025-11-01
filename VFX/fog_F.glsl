#version 330
out vec4 FragColor;

float near = 0.1; 
float far  = 17.0; 
  
float LinearizeDepth(float depth) 
{
    float z = depth * 2.0 - 1.0; // NDC
    return (2.0 * near * far) / (far + near - z * (far - near));	
}

void main()
{             
    float depth = LinearizeDepth(gl_FragCoord.z) / far;
    float iColor = 1 - depth; // inverted color
    float darknessFactor = 0.5;
    vec4 f = vec4(vec3(iColor * darknessFactor),1.0); // final
    FragColor = f;
}
