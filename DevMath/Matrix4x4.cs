using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4(float[][] m)
        {
            float[] x = { m[0][0], m[0][1], m[0][2], m[0][3] };
            float[] y = { m[1][0], m[1][1], m[1][2], m[1][3] };
            float[] z = { m[2][0], m[2][1], m[2][2], m[2][3] };
            float[] w = { m[3][0], m[3][1], m[3][2], m[3][3] };

            m = new float[][] { x, y, z, w };
        }

        public static Matrix4x4 Identity
        {
            get
            {
                float[] x = { 1,0,0,0 };
                float[] y = { 0,1,0,0 };
                float[] z = { 0,0,1,0 };
                float[] w = { 0,0,0,1 };

                float[][] m = { x, y, z, w };

                return new Matrix4x4(m);
            }
        }

        public float Determinant
        {
            get
            {
                float[][] m00 = new float[3][] { new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m10 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m20 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m30 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] } };

                float d1 = smallD(m00);
                float d2 = smallD(m10);
                float d3 = smallD(m20);
                float d4 = smallD(m30);

                return m[0][0] * d1 - m[1][0] * d2 + m[2][0] * d3 - m[3][0] * d4;
            }
        }

        //Takes a Matrix3x3 in the form of a nested float array and returns the determinant of it as a float
        public static float smallD(float[][] m)
        {

            float a1 = m[0][0];
            float a2 = m[1][1] * m[2][2] - m[2][1] * m[1][2];

            float b1 = m[0][1];
            float b2 = m[1][0] * m[2][2] * m[1][2] * m[2][0];

            float c1 = m[0][2];
            float c2 = m[1][0] * m[2][1] - m[2][0] * m[1][1];

            return a1*a2 - b1*b2 + c1*c2;
        }

        public Matrix4x4 Inverse
        {
            get
            {
                float[][] m00 = new float[3][] { new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m01 = new float[3][] { new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[2][0], m[2][2], m[2][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] m02 = new float[3][] { new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[2][0], m[2][1], m[2][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] m03 = new float[3][] { new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[2][0], m[2][1], m[2][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };
                float[][] m10 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m11 = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[2][0], m[2][2], m[2][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] m12 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[2][0], m[2][1], m[2][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] m13 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[2][0], m[2][1], m[2][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };
                float[][] m20 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m21 = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] m22 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] m23 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };
                float[][] m30 = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] } };
                float[][] m31 = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[2][0], m[2][2], m[2][3] } };
                float[][] m32 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[2][0], m[2][1], m[2][3] } };
                float[][] m33 = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[2][0], m[2][1], m[2][2] } };

                float a11 = smallD(m00) * (1 / Determinant);
                float a12 = -smallD(m10) * (1 / Determinant);
                float a13 = smallD(m20) * (1 / Determinant);
                float a14 = -smallD(m30) * (1 / Determinant);

                float a21 = -smallD(m01) * (1 / Determinant);
                float a22 = smallD(m11) * (1 / Determinant);
                float a23 = -smallD(m21) * (1 / Determinant);
                float a24 = smallD(m31) * (1 / Determinant);

                float a31 = smallD(m02) * (1 / Determinant);
                float a32 = -smallD(m12) * (1 / Determinant);
                float a33 = smallD(m22) * (1 / Determinant);
                float a34 = -smallD(m32) * (1 / Determinant);

                float a41 = -smallD(m03) * (1 / Determinant);
                float a42 = smallD(m13) * (1 / Determinant);
                float a43 = -smallD(m23) * (1 / Determinant);
                float a44 = smallD(m33) * (1 / Determinant);

                float[] x = { a11, a12, a13, a14 };
                float[] y = { a21, a22, a23, a24 };
                float[] z = { a31, a32, a33, a34 };
                float[] w = { a41, a42, a43, a44 };

                m = new float[][] { x, y, z, w };

                return new Matrix4x4(m);
            }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            var m = Identity;                                   // 1   0   0   x
            m.m[0][3] = translation.x;                          // 0   1   0   y
            m.m[1][3] = translation.y;                          // 0   0   1   z
            m.m[2][3] = translation.z;                          // 0   0   0   1
            return m;
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen
            var rad = rotation * (float)Math.PI / 180;
            return RotateZ(rad.z) * RotateX(rad.x) * RotateY(rad.y);
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            Matrix4x4 m = Identity;                              //  1   0   0   0 
            m.m[1][1] = m.m[2][2] = (float)Math.Cos(rotation);   //  0  cos -sin 0
            m.m[2][1] = (float)Math.Sin(rotation);               //  0  sin  cos 0
            m.m[1][2] = -m.m[2][1];                              //  0   0   0   1
            return m;
        }

        public static Matrix4x4 RotateY(float rotation)
        {
            Matrix4x4 m = Identity;                             // cos  0  sin  0
            m.m[0][0] = m.m[2][2] = (float)Math.Cos(rotation);  //  0   1   0   0
            m.m[0][2] = (float)Math.Sin(rotation);              //-sin  0  cos  0
            m.m[2][0] = -m.m[0][2];                             //  0   0   0   1
            return m;
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            Matrix4x4 m = Identity;                             // cos -sin 0   0
            m.m[0][0] = m.m[1][1] = (float)Math.Cos(rotation);  // sin  cos 0   0
            m.m[1][0] = (float)Math.Sin(rotation);              //  0   0   1   0
            m.m[0][1] = -m.m[1][0];                             //  0   0   0   1
            return m;
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            var m = Identity;                                   //  sx   0   0   0
            m.m[0][0] = scale.x;                                //   0  sy   0   0
            m.m[1][1] = scale.y;                                //   0   0  sz   0
            m.m[2][2] = scale.z;                                //   0   0   0   1
            return m;
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            Vector4 lhs_r1 = new Vector4(lhs.m[0][0], lhs.m[0][1], lhs.m[0][2], lhs.m[0][3]);
            Vector4 lhs_r2 = new Vector4(lhs.m[1][0], lhs.m[1][1], lhs.m[1][2], lhs.m[1][3]);
            Vector4 lhs_r3 = new Vector4(lhs.m[2][0], lhs.m[2][1], lhs.m[2][2], lhs.m[2][3]);
            Vector4 lhs_r4 = new Vector4(lhs.m[3][0], lhs.m[3][1], lhs.m[3][2], lhs.m[3][3]);

            Vector4 rhs_c1 = new Vector4(rhs.m[0][0], rhs.m[1][0], rhs.m[2][0], rhs.m[3][0]);
            Vector4 rhs_c2 = new Vector4(rhs.m[0][1], rhs.m[1][1], rhs.m[2][1], rhs.m[3][1]);
            Vector4 rhs_c3 = new Vector4(rhs.m[0][2], rhs.m[1][2], rhs.m[2][2], rhs.m[3][2]);
            Vector4 rhs_c4 = new Vector4(rhs.m[0][3], rhs.m[1][3], rhs.m[2][3], rhs.m[3][3]); 

            float x1 = Vector4.Dot(lhs_r1, rhs_c1);
            float x2 = Vector4.Dot(lhs_r1, rhs_c2);
            float x3 = Vector4.Dot(lhs_r1, rhs_c3);
            float x4 = Vector4.Dot(lhs_r1, rhs_c4);

            float y1 = Vector4.Dot(lhs_r2, rhs_c1);
            float y2 = Vector4.Dot(lhs_r2, rhs_c2);
            float y3 = Vector4.Dot(lhs_r2, rhs_c3);
            float y4 = Vector4.Dot(lhs_r2, rhs_c4);

            float z1 = Vector4.Dot(lhs_r3, rhs_c1);
            float z2 = Vector4.Dot(lhs_r3, rhs_c2);
            float z3 = Vector4.Dot(lhs_r3, rhs_c3);
            float z4 = Vector4.Dot(lhs_r3, rhs_c4);

            float w1 = Vector4.Dot(lhs_r4, rhs_c1);
            float w2 = Vector4.Dot(lhs_r4, rhs_c2);
            float w3 = Vector4.Dot(lhs_r4, rhs_c3);
            float w4 = Vector4.Dot(lhs_r4, rhs_c4);

            float[] x = { x1, x2, x3, x4 };
            float[] y = { y1, y2, y3, y4 };
            float[] z = { z1, z2, z3, z4 };
            float[] w = { w1, w2, w3, w4 };

            float[][] m = { x, y, z, w };

            return new Matrix4x4(m);
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            Vector4 lhs_r1 = new Vector4(lhs.m[0][0], lhs.m[0][1], lhs.m[0][2], lhs.m[0][3]);
            Vector4 lhs_r2 = new Vector4(lhs.m[1][0], lhs.m[1][1], lhs.m[1][2], lhs.m[1][3]);
            Vector4 lhs_r3 = new Vector4(lhs.m[2][0], lhs.m[2][1], lhs.m[2][2], lhs.m[2][3]);
            Vector4 lhs_r4 = new Vector4(lhs.m[3][0], lhs.m[3][1], lhs.m[3][2], lhs.m[3][3]);

            float x = Vector4.Dot(lhs_r1, rhs);
            float y = Vector4.Dot(lhs_r2, rhs);
            float z = Vector4.Dot(lhs_r3, rhs);
            float w = Vector4.Dot(lhs_r4, rhs);

            return new Vector4(x,y,z,w);
        }
    }
}
