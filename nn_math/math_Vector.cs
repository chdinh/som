using System;
using System.Collections.Generic;
using System.Text;

namespace nn_math
{
    /*
    /// Classes Contained:
    /// 	Vector
    /// 	VectorException
    ///     VectorTestClass
    */
    
    ///<remarks>
    /// Class name: Vector
    ///	Developed by: Christoph Dinh
    /// Email: christoph.dinh@live.de
    /// Constructors:
    /// 	( int[] ):	takes 2D integer array, convert them to double	
    /// 	( double[] ):	takes 2D double array
    /// 	( int Rows, int Cols ):	initializes the dimensions, indexers may be used 
    /// 							to set individual elements' values
    ///     ( Vector vector ): Copy Constructor
    /// 
    /// Properties:
    /// 
    /// Indexers:
    /// 	[i] = used to set/get elements in the form of double
    /// 
    /// Public Methods (Description is given with respective methods' definitions)
    /// 
    /// Private Methods
    /// 
    /// Operators Overloaded Overloaded
    /// 	Unary: -
    /// 	Binary: 
    /// 		+,- 
    /// 		* 
    /// 		/ 
    /// </remarks>
    /// <summary>
    /// Stellt Methoden zum Erstellen und Bearbeiten von Vektoren bereit
    ///</summary>
    [Serializable()]
    public class Vector
    {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        private int v_iDimension;
        private bool v_isColumnVector;
        private double[] v_iElement;

        /// <summary>
        /// Constructors
        /// </summary>
        public Vector(int[] elements)
        {
            v_iDimension = elements.GetLength(0);
            v_isColumnVector = true;
            v_iElement = new double[this.v_iDimension];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                 this[i] = elements[i];
            }
        }

        public Vector(double[] elements)
        {
            v_iDimension = elements.GetLength(0);
            v_isColumnVector = true;
            v_iElement = new double[v_iDimension];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                this[i] = elements[i];
            }
        }

        public Vector(int iDemension)
        {
            v_iDimension = iDemension;
            v_isColumnVector = true;
            v_iElement = new double[iDemension];
        }

        public Vector(Vector vector)
        {
            v_iDimension = vector.Dimension;
            v_isColumnVector = vector.ColumnVector;
            v_iElement = new double[vector.Dimension];
            vector.v_iElement.CopyTo(v_iElement, 0);
        }


        /// <summary>
        /// Properites
        /// </summary>
        public int Dimension
        {
            get { return v_iDimension; }
        }
        
        public bool ColumnVector
        {
            get { return v_isColumnVector; }
            set { v_isColumnVector = value; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public double this[int iElement]		// vector's index starts at 0
        {
            get { return GetElement(iElement); }
            set { SetElement(iElement, value); }
        }

        /// <summary>
        /// Internal functions for getting/setting values
        /// </summary>
        private double GetElement(int iElement)
        {
            if (iElement < 0 || iElement > Dimension - 1)
                throw new VectorException("Invalid index specified");
            return v_iElement[iElement];
        }

        private void SetElement(int iElement, double value)
        {
            if (iElement < 0 || iElement > Dimension - 1)
                throw new VectorException("Invalid index specified");
            v_iElement[iElement] = value;
        }

        /// <summary>
        /// The function returns the current Vector object as a string
        /// </summary>
        public string ConvertToString()
        {
            return (Vector.ConvertToString(this));
        }

        /// <summary>
        /// The function takes a Vector object and returns it as a string
        /// </summary>
        public static string ConvertToString(Vector vector)
        {
            string str = "";
            for (int i = 0; i < vector.Dimension; i++)
            {
                str = String.Concat(str, Convert.ToString(vector[i]), vector.ColumnVector ? "\n" : "\t");
            }
            return str;
        }

        
        /// <summary>
        /// The function returns the current Vector object as an unit vector
        /// </summary>
        public Vector UnitVector()
        {
            return Vector.UnitVector(this);
        }

        /// <summary>
        /// The function takes a Vector object and returns it as an unit vector
        /// </summary>
        public static Vector UnitVector(Vector vector)
        {
            return vector / Vector.AbsVector(vector);
        }
        
        /// <summary>
        /// The function returns the absolute value of the current Vector object
        /// </summary>
        public double AbsVector()
        {
            return (Vector.AbsVector(this));
        }

        /// <summary>
        /// The function returns the absolute value of a Vector object
        /// </summary>
        public static double AbsVector(Vector vector)
        {
            return Math.Sqrt(Convert.ToDouble(vector * vector));
        }

        #region Normen
        /// <summary>
        /// The function returns the AbsSum Norm ||a||1 of the current Vector object
        /// </summary>
        public double AbsSumNorm()
        {
            return Vector.AbsSumNorm(this);
        }

        /// <summary>
        /// The function returns the AbsSum Norm ||a||1 of a Vector object
        /// </summary>
        public static double AbsSumNorm(Vector vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Dimension; i++)
                sum += Math.Abs(vector[i]);
            return sum;
        }

        /// <summary>
        /// The function returns the Euklid Norm ||a||2 of the current Vector object
        /// </summary>
        public double Euklid()
        {
            return Vector.AbsVector(this);
        }

        /// <summary>
        /// The function returns the Euklid Norm ||a||2 of a Vector object
        /// </summary>
        public static double Euklid(Vector vector)
        {
            return Vector.AbsVector(vector);
        }

        /// <summary>
        /// The function returns the Max Norm ||a||oo of the current Vector object
        /// </summary>
        public double MaxNorm()
        {
            return Vector.MaxNorm(this);
        }

        /// <summary>
        /// The function returns the Max Norm ||a||oo of a Vector object
        /// </summary>
        public static double MaxNorm(Vector vector)
        {
            double max = 0;
            for (int i = 0; i < vector.Dimension; i++)
                if (Math.Abs(vector[i]) > max)
                    max = Math.Abs(vector[i]);
            return max;
        }
        //End Norm
        #endregion

        /// <summary>
        /// The function multiplies the current vector object by a double 
        /// </summary>
        public void MultiplyVect(double frac)
        {
            for (int j = 0; j < this.Dimension; j++)
            {
                this[j] *= frac;
            }
        }

        /// <summary>
        /// The function multiplies the current vector object by an integer
        /// </summary>
        public void MultiplyVect(int iNo)
        {
            for (int j = 0; j < this.Dimension; j++)
            {
                this[j] *= iNo;
            }
        }

        /// <summary>
        /// The function fill the current Vector with a double
        /// </summary>
        public void FillVect(double value)
        {
            for (int i = 0; i < this.Dimension; i++)
                this[i] = value;
        }

        /// <summary>
        /// The function concatenates the two given vecors
        /// </summary>
        public static Vector Concatenate(Vector vector1, Vector vector2)
        {
            if (vector1.ColumnVector != vector2.ColumnVector)
                throw new VectorException("Operation not possible - two different vectors (column, row)");
            Vector vector = new Vector(vector1.Dimension + vector2.Dimension);
            for (int i = 0; i < vector.Dimension; i++)
            {
                if (i < vector1.Dimension)
                    vector[i] = vector1[i];
                else
                    vector[i] = vector2[i - vector1.Dimension];
            }
            return vector;
        }

        public static Vector[] Split(Vector vector, int pos)
        {
            Vector[] vectorArray = new Vector[2];
            vectorArray[0] = new Vector(pos);
            vectorArray[0].ColumnVector = vector.ColumnVector;
            vectorArray[1] = new Vector(vector.Dimension - pos);
            vectorArray[1].ColumnVector = vector.ColumnVector;
            try
            {
                for (int i = 0; i < vector.Dimension; i++)
                {
                    if (i < vectorArray[0].Dimension)
                        vectorArray[0][i] = vector[i];
                    else
                        vectorArray[1][i - vectorArray[0].Dimension] = vector[i];
                }
                return vectorArray;
            }
            catch (Exception)
            {
                throw new VectorException("Invalid position specified");
            }
        }

        /// <summary>
        /// The function returns the transpose of a given vector
        /// </summary>
        public static Vector Transpose(Vector vector)
        {
            Vector TransposeVector = new Vector(vector);
            TransposeVector.ColumnVector = !vector.ColumnVector;
            return TransposeVector;
        }

        /// <summary>
        /// The function returns the transpose of the current vector
        /// </summary>
        public Vector Transpose()
        {
            return Transpose(this);
        }

        /// <summary>
        /// The function duplicates the current Matrix object
        /// </summary>
        public Vector Duplicate()
        {
            Vector vector = new Vector(Dimension);
            for (int i = 0; i < Dimension; i++)
                    vector[i] = this[i];
            return vector;
        }

        /// <summary>
        /// The function returns a null column vector of dimension ( dim )
        /// </summary>
        public static Vector NullVector(int dim)
        {
            double temp = 0;
            Vector vector = new Vector(dim);
            for (int i = 0; i < vector.Dimension; i++)
                vector[i] = temp;
            return vector;
        }

        /// <summary>
        /// The function returns the cross product of two vectors of dimension 3
        /// </summary>
        public static Vector Crossproduct(Vector vector1, Vector vector2)
        {
            if (vector1.Dimension != vector2.Dimension || vector1.Dimension != 3)
                throw new VectorException("Operation not possible");
            if (!vector1.ColumnVector || !vector2.ColumnVector)
                throw new VectorException("Operation not possible, vectors must type of column vector");
            Vector result = new Vector(3);
            result[0] = vector1[1] * vector2[2] - vector1[2] * vector2[1];
            result[1] = vector1[2] * vector2[0] - vector1[0] * vector2[2];
            result[2] = vector1[0] * vector2[1] - vector1[1] * vector2[0];
            return result;
        }

        /// <summary>
        /// Operators for the Matrix object
        /// includes -(unary), and binary opertors such as +,-,*,/
        /// </summary>
        public static Vector operator -(Vector vector)
        { return Vector.Negate(vector); }

        public static Vector operator +(Vector vector1, Vector vector2)
        { return Vector.Add(vector1, vector2); }

        public static Vector operator -(Vector vector1, Vector vector2)
        { return Vector.Add(vector1, -vector2); }

        public static Object operator *(Vector vector1, Vector vector2)
        {
            if (vector1.ColumnVector == vector2.ColumnVector || !vector1.ColumnVector && vector2.ColumnVector)
            {
                return Vector.Scalarproduct(vector1, vector2);
            }
            else
            {
                return Vector.productMatrix(vector1, vector2);
            }
        }

        public static Vector operator *(Vector vector1, int iNo)
        { return Vector.Multiply(vector1, iNo); }

        public static Vector operator *(Vector vector1, double dbl)
        { return Vector.Multiply(vector1, dbl); }

        public static Vector operator *(int iNo, Vector vector1)
        { return Vector.Multiply(vector1, iNo); }

        public static Vector operator *(double dbl, Vector vector1)
        { return Vector.Multiply(vector1, dbl); }

        public static Vector operator /(Vector vector1, int iNo)
        { return Vector.Multiply(vector1, iNo); }

        public static Vector operator /(Vector vector1, double dbl)
        { return Vector.Multiply(vector1, (1 / dbl)); }

        /// <summary>
        /// Internal Fucntions for the above operators
        /// </summary>
        private static Vector Negate(Vector vector)
        {
            return Vector.Multiply(vector, -1);
        }

        private static Vector Add(Vector vector1, Vector vector2)
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new VectorException("Operation not possible");
            Vector result = new Vector(vector1.Dimension);
            for (int i = 0; i < result.Dimension; i++)
                result[i] = vector1[i] + vector2[i];
            return result;
        }

        private static double Scalarproduct(Vector vector1, Vector vector2)
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new VectorException("Operation not possible");
            double result = 0;
            for (int i = 0; i < vector1.Dimension; i++)
                     result += vector1[i] * vector2[i];
            return result;
        }

        private static Matrix productMatrix(Vector vector1, Vector vector2)
        {
            Matrix result = new Matrix(vector1.Dimension, vector2.Dimension);
            for (int i = 0; i < vector1.Dimension; i++)
                for (int j = 0; j < vector2.Dimension; j++)
                result[i,j] = vector1[i] * vector2[j];
            return result;
        }

        private static Vector Multiply(Vector vector, int iNo)
        {
            Vector result = new Vector(vector.Dimension);
            for (int i = 0; i < vector.Dimension; i++)
                result[i] = vector[i] * iNo;
            return result;
        }

        private static Vector Multiply(Vector vector, double frac)
        {
            Vector result = new Vector(vector.Dimension);
            for (int i = 0; i < vector.Dimension; i++)
                result[i] = vector[i] * frac;
            return result;
        }//*/
    }	//end class Vector

    /// <summary>
    /// Exception class for Matrix class, derived from System.Exception
    /// </summary>
    public class VectorException : Exception
    {
        public VectorException()
            : base()
        { }

        public VectorException(string Message)
            : base(Message)
        { }

        public VectorException(string Message, Exception InnerException)
            : base(Message, InnerException)
        { }
    }	// end class MatrixException

    
    public class VectorTestClass
    {
        private Vector myVector1;
        private Vector myVector2;
        private Vector myVector3;

        public VectorTestClass()
        {
            this.myVector1 = new Vector(3);
            this.myVector2 = new Vector(3);
            System.Random rnd = new System.Random();
            int k = 1;
            for (int i = 0; i < this.myVector1.Dimension; i++)
            {
                this.myVector1[i] = (rnd.Next() % 10) - 5;
                //this.myMatrix1[i, j] = k;
                //k++;
            }
            k = 1;
            for (int i = 0; i < this.myVector2.Dimension; i++)
            {

                this.myVector2[i] = k;
                k++;
            }
            Console.WriteLine("Vector1:");
            Console.WriteLine(myVector1.ConvertToString());
            Console.WriteLine("Vector2:");
            Console.WriteLine(myVector2.ConvertToString());
            Console.WriteLine("Vector1 duplizieren:");
            myVector3 = new Vector(myVector1);
            Console.WriteLine("Element 0,0 der neuen Matrix wert 500 zuweisen:");
            myVector3[0] = 500;
            Console.WriteLine("Vector1:");
            Console.WriteLine(myVector1.ConvertToString());
            Console.WriteLine("Vector3:");
            Console.WriteLine(myVector3.ConvertToString());
            Console.WriteLine("Skalarprodukt von Vektor 1 und 2:");
            Console.WriteLine(((Matrix)(myVector1 * myVector2.Transpose())).ConvertToString());
            Console.WriteLine("Vektorprodukt von Vektor 1 und 2::");
            Console.WriteLine(Vector.Crossproduct(myVector1, myVector2).ConvertToString());
            Console.WriteLine("Transponierter Vector1:");
            Console.WriteLine(myVector1.Transpose().ConvertToString());
            Console.WriteLine("Länge Vector1:");
            Console.WriteLine(myVector1.AbsVector());
            Console.WriteLine("Einheits-Vector1:");
            Console.WriteLine(myVector1.UnitVector().ConvertToString());
            Console.WriteLine("Euklid Vector1:");
            Console.WriteLine(myVector1.Euklid());
            Console.WriteLine("AbsNorm-Vector1:");
            Console.WriteLine(myVector1.AbsSumNorm());
            Console.WriteLine("MaxNorm-Vector1:");
            Console.WriteLine(myVector1.MaxNorm());
        }
    }//VectorTestClass Ende*/
}
