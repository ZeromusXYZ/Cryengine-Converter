﻿namespace CgfConverter.CryEngineCore
{
    public abstract class ChunkMesh : Chunk
    {
        // public UInt32 Version;  // 623 Far Cry, 744 Far Cry, Aion, 800 Crysis
        // public bool HasVertexWeights; // for 744
        // public bool HasVertexColors; // 744
        // public bool InWorldSpace; // 623
        // public byte Reserved1;  // padding byte, 744
        // public byte Reserved2;  // padding byte, 744
        public int Flags1 { get; set; }  // 800  Offset of this chunk. 
        public int Flags2 { get; set; }  // 801 and 802
        // public UInt32 ID;  // 800  Chunk ID
        public int NumVertices { get; set; } // 
        public int NumIndices { get; set; }  // Number of indices (each triangle has 3 indices, so this is the number of triangles times 3).
        // public UInt32 NumUVs; // 744
        // public UInt32 NumFaces; // 744
        // Pointers to various Chunk types
        //public ChunkMtlName Material; // 623, Material Chunk, never encountered?
        public uint NumVertSubsets { get; set; } // 801, Number of vert subsets
        public int VertsAnimID { get; set; }
        public int MeshSubsets { get; set; } // 800  Reference of the mesh subsets
        // public ChunkVertAnim VertAnims; // 744.  not implemented
        // public Vertex[] Vertices; // 744.  not implemented
        // public Face[,] Faces; // 744.  Not implemented
        // public UV[] UVs; // 744 Not implemented
        // public UVFace[] UVFaces; // 744 not implemented
        // public VertexWeight[] VertexWeights; // 744 not implemented
        // public IRGB[] VertexColors; // 744 not implemented
        public int VerticesData { get; set; }
        public int NumBuffs { get; set; }
        public int NormalsData { get; set; }
        public int UVsData { get; set; }
        public int ColorsData { get; set; }
        public int Colors2Data { get; set; }
        public int IndicesData { get; set; }
        public int TangentsData { get; set; }
        public int ShCoeffsData { get; set; }
        public int ShapeDeformationData { get; set; }
        public int BoneMapData { get; set; }
        public int FaceMapData { get; set; }
        public int VertMatsData { get; set; }
        public int MeshPhysicsData { get; set; }
        public int VertsUVsData { get; set; }
        public int[] PhysicsData = new int[4];
        public Vector3 MinBound;
        public Vector3 MaxBound;

        public override string ToString()
        {
            return $@"Chunk Type: {ChunkType}, ID: {ID:X}, Version: {Version}";
        }

        public void WriteChunk()
        {
            Utils.Log(LogLevelEnum.Verbose, "*** START MESH CHUNK ***");
            Utils.Log(LogLevelEnum.Verbose, "    ChunkType:           {0}", ChunkType);
            Utils.Log(LogLevelEnum.Verbose, "    Chunk ID:            {0:X}", ID);
            Utils.Log(LogLevelEnum.Verbose, "    MeshSubSetID:        {0:X}", MeshSubsets);
            Utils.Log(LogLevelEnum.Verbose, "    Vertex Datastream:   {0:X}", VerticesData);
            Utils.Log(LogLevelEnum.Verbose, "    Normals Datastream:  {0:X}", NormalsData);
            Utils.Log(LogLevelEnum.Verbose, "    UVs Datastream:      {0:X}", UVsData);
            Utils.Log(LogLevelEnum.Verbose, "    Indices Datastream:  {0:X}", IndicesData);
            Utils.Log(LogLevelEnum.Verbose, "    Tangents Datastream: {0:X}", TangentsData);
            Utils.Log(LogLevelEnum.Verbose, "    Mesh Physics Data:   {0:X}", MeshPhysicsData);
            Utils.Log(LogLevelEnum.Verbose, "    VertUVs:             {0:X}", VertsUVsData);
            Utils.Log(LogLevelEnum.Verbose, "    MinBound:            {0:F7}, {1:F7}, {2:F7}", MinBound.x, MinBound.y, MinBound.z);
            Utils.Log(LogLevelEnum.Verbose, "    MaxBound:            {0:F7}, {1:F7}, {2:F7}", MaxBound.x, MaxBound.y, MaxBound.z);
            Utils.Log(LogLevelEnum.Verbose, "*** END MESH CHUNK ***");
        }
    }
}
