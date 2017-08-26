using System;
using System.Collections.Generic;
using System.Text;

namespace nn_math
{
    /*
    // Classes Contained:
    // 	  Matrix
    //    MatrixException
    //    MatrixTestClass
    */

    /// <remarks>
    /// Class name: Matrix
    ///
    /// Constructors:
    /// 	( int[,] ):	takes 2D integer array, convert them to double	
    /// 	( double[,] ):	takes 2D double array
    /// 	( int Rows, int Cols ): initializes the dimensions, indexers may be used 
    /// 							to set individual elements' values
    ///     ( Matrix matrix ): Copy-Constructor
    /// 
    /// Properties:
    /// 	Rows: read only property to get the no. of rows in the current matrix
    /// 	Cols: read only property to get the no. of columns in the current matrix
    /// 
    /// Indexers:
    /// 	[i,j] = used to set/get elements in the form of double
    /// 
    /// Public Methods (Description is given with respective methods' definitions)
    /// 	string ConvertToString(Matrix)
    /// 	Matrix Minor(Matrix, Row,Col)
    /// 	double Determinent(Matrix)
    /// 	MultiplyRow( Row, integer )
    /// 	MultiplyRow( Row, double )
    /// 	AddRow( TargetRow, SecondRow, Multiple)
    /// 	InterchangeRow( Row1, Row2)
    /// 	Matrix Concatenate(Matrix1, Matrix2)
    /// 	Matrix EchelonForm(Matrix)
    /// 	Matrix ReducedEchelonForm(Matrix)
    /// 	Matrix Inverse(Matrix)
    /// 	Matrix Adjoint(Matrix)
    /// 	Matrix Transpose(Matrix)
    /// 	Matrix Duplicate()
    /// 	Matrix ScalarMatrix( Rows, Cols, K )
    /// 	Matrix IdentityMatrix( Rows, Cols )
    /// 	Matrix UnitMatrix(Rows, Cols)
    /// 	Matrix NullMatrix(Rows, Cols)
    ///     Matrix FillMatrix(double)
    /// 
    /// Private Methods
    /// 	double GetElement(int iRow, int iCol)
    /// 	SetElement(int iRow, int iCol, double value)
    /// 	Negate(Matrix)
    /// 	Add(Matrix1, Matrix2)
    /// 	Multiply(Matrix1, Matrix2)
    /// 	Multiply(Matrix1, double)
    /// 	Multiply(Matrix1, integer)
    /// 
    /// Operators Overloaded Overloaded
    /// 	Unary: - (negate matrix)
    /// 	Binary: 
    /// 		+,- for two matrices
    /// 		* for two matrices or one matrix with integer or double
    /// 		/ for matrix with integer or double
    /// </remarks>
    /// <summary>
    /// Stellt Methoden zum Erstellen und Bearbeiten von Matrizen bereit
    /// </summary>
    [Serializable()]
    public class Matrix
    {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        private int m_iRows;
        private int m_iCols;
        private double[,] m_iElement;

        /// <summary>
        /// Constructors
        /// </summary>
        public Matrix(int[,] elements)
        {
            m_iRows = elements.GetLength(0);
            m_iCols = elements.GetLength(1);
            m_iElement = new double[m_iRows, m_iCols];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    this[i, j] = elements[i, j];
                }
            }
        }

        public Matrix(double[,] elements)
        {
            m_iRows = elements.GetLength(0);
            m_iCols = elements.GetLength(1);
            m_iElement = new double[m_iRows, m_iCols];
            for (int i = 0; i < elements.GetLength(0); i++)
            {
                for (int j = 0; j < elements.GetLength(1); j++)
                {
                    this[i, j] = elements[i, j];
                }
            }
        }

        public Matrix(int iRows, int iCols)
        {
            m_iRows = iRows;
            m_iCols = iCols;
            m_iElement = new double[iRows, iCols];
        }

        public Matrix(Matrix matrix)
        {
            m_iRows = matrix.Rows;
            m_iCols = matrix.Cols;
            m_iElement = new double[matrix.Rows, matrix.Cols];
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    this[i, j] = matrix[i, j];
        }

        /// <summary>
        /// Properites
        /// </summary>
        public int Rows
        {
            get { return m_iRows; }
        }

        public int Cols
        {
            get { return m_iCols; }
        }

        /// <summary>
        /// Indexer
        /// </summary>
        public double this[int iRow, int iCol]		// matrix's index starts at 0,0
        {
            get { return GetElement(iRow, iCol); }
            set { SetElement(iRow, iCol, value); }
        }

        /// <summary>
        /// Internal functions for getting/setting values
        /// </summary>
        private double GetElement(int iRow, int iCol)
        {
            if (iRow < 0 || iRow > Rows - 1 || iCol < 0 || iCol > Cols - 1)
                throw new MatrixException("Invalid index specified");
            return m_iElement[iRow, iCol];
        }

        private void SetElement(int iRow, int iCol, double value)
        {
            if (iRow < 0 || iRow > Rows - 1 || iCol < 0 || iCol > Cols - 1)
                throw new MatrixException("Invalid index specified");
            m_iElement[iRow, iCol] = value;
        }

        /// <summary>
        /// The function returns the current Matrix object as a string
        /// </summary>
        public string ConvertToString()
        {
            return (Matrix.ConvertToString(this));
        }

        /// <summary>
        /// The function takes a Matrix object and returns it as a string
        /// </summary>
        public static string ConvertToString(Matrix matrix)
        {
            string str = "";
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                    str += Convert.ToString(matrix[i, j]) + "\t";
                str += "\n";
            }
            return str;
        }

        /// <summary>
        /// The function return the Minor of element[Row,Col] of a Matrix object 
        /// </summary>
        public static Matrix Minor(Matrix matrix, int iRow, int iCol)
        {
            Matrix minor = new Matrix(matrix.Rows - 1, matrix.Cols - 1);
            int m = 0, n = 0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                if (i == iRow)
                    continue;
                n = 0;
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (j == iCol)
                        continue;
                    minor[m, n] = matrix[i, j];
                    n++;
                }
                m++;
            }
            return minor;
        }

        /// <summary>
        /// The function returns the determinent of a Matrix object as double
        /// </summary>
        public static double Determinent(Matrix matrix)
        {
            double det = 0;
            if (matrix.Rows != matrix.Cols)
                throw new MatrixException("Determinent of a non-square matrix doesn't exist");
            if (matrix.Rows == 1)
                return matrix[0, 0];
            for (int j = 0; j < matrix.Cols; j++)
                det += (matrix[0, j] * Determinent(Matrix.Minor(matrix, 0, j)) * (int)System.Math.Pow(-1, 0 + j));
            return det;
        }

        /// <summary>
        /// The function returns the determinent of the current Matrix object as double
        /// </summary>
        public double Determinent()
        {
            return Determinent(this);
        }

        /// <summary>
        /// The function multiplies the given row of the current matrix object by a double 
        /// </summary>
        public void MultiplyRow(int iRow, double frac)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                this[iRow, j] *= frac;
            }
        }

        /// <summary>
        /// The function multiplies the given row of the current matrix object by an integer
        /// </summary>
        public void MultiplyRow(int iRow, int iNo)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                this[iRow, j] *= iNo;
            }
        }

        /// <summary>
        /// The function adds two rows for current matrix object
        /// It performs the following calculation:
        /// iTargetRow = iTargetRow + iMultiple*iSecondRow
        /// </summary>
        public void AddRow(int iTargetRow, int iSecondRow, double iMultiple)
        {
            for (int j = 0; j < this.Cols; j++)
                this[iTargetRow, j] += (this[iSecondRow, j] * iMultiple);
        }

        /// <summary>
        /// The function interchanges two rows of the current matrix object
        /// </summary>
        public void InterchangeRow(int iRow1, int iRow2)
        {
            for (int j = 0; j < this.Cols; j++)
            {
                double temp = this[iRow1, j];
                this[iRow1, j] = this[iRow2, j];
                this[iRow2, j] = temp;
            }
        }

        /// <summary>
        /// The function fill the current Matrix with a double
        /// </summary>
        public void FillMatrix(double value)
        {
            for (int i = 0; i < this.Rows; i++)
                for (int j = 0; j < this.Cols; j++)
                    this[i, j] = value;
        }

        /// <summary>
        /// The function returns a Row - Matrix of dimension ( 1 x Col )
        /// </summary>
        public Matrix GetRow(int iRow)
        {
            Matrix matrix = new Matrix(1, Cols);
            for (int i = 0; i < Cols; i++)
                matrix[0, i] = this[iRow, i];
            return matrix;
        }

        /// <summary>
        /// The function returns a Col - Matrix of dimension ( Row x 1 )
        /// </summary>
        public Matrix GetCol(int iCol)
        {
            Matrix matrix = new Matrix(Rows, 1);
            for (int i = 0; i < Rows; i++)
                matrix[i, 0] = this[i, iCol];
            return matrix;
        }

        /// <summary>
        /// The function concatenates the two given matrices column-wise
        /// </summary>
        public static Matrix Concatenate(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows)
                throw new MatrixException("Concatenation not possible");
            Matrix matrix = new Matrix(matrix1.Rows, matrix1.Cols + matrix2.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (j < matrix1.Cols)
                        matrix[i, j] = matrix1[i, j];
                    else
                        matrix[i, j] = matrix2[i, j - matrix1.Cols];
                }
            return matrix;
        }

        /// <summary>
        /// The function returns the Echelon form of a given matrix
        /// </summary>
        public static Matrix EchelonForm(Matrix matrix)
        {
            try
            {
                Matrix EchelonMatrix = matrix.Duplicate();
                for (int i = 0; i < matrix.Rows; i++)
                {
                    if (EchelonMatrix[i, i] == 0)	// if diagonal entry is zero, 
                        for (int j = i + 1; j < EchelonMatrix.Rows; j++)
                            if (EchelonMatrix[j, i] != 0)	 //check if some below entry is non-zero
                                EchelonMatrix.InterchangeRow(i, j);	// then interchange the two rows
                    if (EchelonMatrix[i, i] == 0)	// if not found any non-zero diagonal entry
                        continue;	// increment i;
                    if (EchelonMatrix[i, i] != 1)	// if diagonal entry is not 1 , 	
                        for (int j = i + 1; j < EchelonMatrix.Rows; j++)
                            if (EchelonMatrix[j, i] == 1)	 //check if some below entry is 1
                                EchelonMatrix.InterchangeRow(i, j);	// then interchange the two rows
                    EchelonMatrix.MultiplyRow(i, (1 / EchelonMatrix[i, i]));
                    for (int j = i + 1; j < EchelonMatrix.Rows; j++)
                        EchelonMatrix.AddRow(j, i, -EchelonMatrix[j, i]);
                }
                return EchelonMatrix;
            }
            catch (Exception)
            {
                throw new MatrixException("Matrix can not be reduced to Echelon form");
            }
        }

        /// <summary>
        /// The function returns the Echelon form of the current matrix
        /// </summary>
        public Matrix EchelonForm()
        {
            return EchelonForm(this);
        }

        /// <summary>
        /// The function returns the reduced echelon form of a given matrix
        /// </summary>
        public static Matrix ReducedEchelonForm(Matrix matrix)
        {
            try
            {
                Matrix ReducedEchelonMatrix = matrix.Duplicate();
                for (int i = 0; i < matrix.Rows; i++)
                {
                    if (ReducedEchelonMatrix[i, i] == 0)	// if diagonal entry is zero, 
                        for (int j = i + 1; j < ReducedEchelonMatrix.Rows; j++)
                            if (ReducedEchelonMatrix[j, i] != 0)	 //check if some below entry is non-zero
                                ReducedEchelonMatrix.InterchangeRow(i, j);	// then interchange the two rows
                    if (ReducedEchelonMatrix[i, i] == 0)	// if not found any non-zero diagonal entry
                        continue;	// increment i;
                    if (ReducedEchelonMatrix[i, i] != 1)	// if diagonal entry is not 1 , 	
                        for (int j = i + 1; j < ReducedEchelonMatrix.Rows; j++)
                            if (ReducedEchelonMatrix[j, i] == 1)	 //check if some below entry is 1
                                ReducedEchelonMatrix.InterchangeRow(i, j);	// then interchange the two rows
                    ReducedEchelonMatrix.MultiplyRow(i, (1 / ReducedEchelonMatrix[i, i]));
                    for (int j = i + 1; j < ReducedEchelonMatrix.Rows; j++)
                        ReducedEchelonMatrix.AddRow(j, i, -ReducedEchelonMatrix[j, i]);
                    for (int j = i - 1; j >= 0; j--)
                        ReducedEchelonMatrix.AddRow(j, i, -ReducedEchelonMatrix[j, i]);
                }
                return ReducedEchelonMatrix;
            }
            catch (Exception)
            {
                throw new MatrixException("Matrix can not be reduced to Echelon form");
            }
        }

        /// <summary>
        /// The function returns the reduced echelon form of the current matrix
        /// </summary>
        public Matrix ReducedEchelonForm()
        {
            return ReducedEchelonForm(this);
        }

        /// <summary>
        /// The function returns the inverse of a given matrix
        /// </summary>
        public static Matrix Inverse(Matrix matrix)
        {
            if (Determinent(matrix) == 0)
                throw new MatrixException("Inverse of a singular matrix is not possible");
            return (Adjoint(matrix) / Determinent(matrix));
        }

        /// <summary>
        /// The function returns the inverse of the current matrix
        /// </summary>
        public Matrix Inverse()
        {
            return Inverse(this);
        }

        /// <summary>
        /// The function returns the adjoint of a given matrix
        /// </summary>
        public static Matrix Adjoint(Matrix matrix)
        {
            if (matrix.Rows != matrix.Cols)
                throw new MatrixException("Adjoint of a non-square matrix does not exists");
            Matrix AdjointMatrix = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    AdjointMatrix[i, j] = Math.Pow(-1, i + j) * Determinent(Minor(matrix, i, j));
            AdjointMatrix = Transpose(AdjointMatrix);
            return AdjointMatrix;
        }

        /// <summary>
        /// The function returns the adjoint of the current matrix
        /// </summary>
        public Matrix Adjoint()
        {
            return Adjoint(this);
        }

        /// <summary>
        /// The function returns the transpose of a given matrix
        /// </summary>
        public static Matrix Transpose(Matrix matrix)
        {
            Matrix TransposeMatrix = new Matrix(matrix.Cols, matrix.Rows);
            for (int i = 0; i < TransposeMatrix.Rows; i++)
                for (int j = 0; j < TransposeMatrix.Cols; j++)
                    TransposeMatrix[i, j] = matrix[j, i];
            return TransposeMatrix;
        }

        /// <summary>
        /// The function returns the transpose of the current matrix
        /// </summary>
        public Matrix Transpose()
        {
            return Transpose(this);
        }

        /// <summary>
        /// The function duplicates the current Matrix object
        /// </summary>
        public Matrix Duplicate()
        {
            Matrix matrix = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    matrix[i, j] = this[i, j];
            return matrix;
        }

        /// <summary>
        /// The function converts the current MatrixRow to a RowVector
        /// </summary>
        public Vector ConvertRowToVector(int iRow)
        {
            Vector vector = new Vector(Cols);
            for (int i = 0; i < Cols; i++)
                vector[i] = this[iRow, i];
            vector.ColumnVector = false;
            return vector;
        }

        /// <summary>
        /// The function converts the current MatrixCol to a ColVector
        /// </summary>
        public Vector ConvertColToVector(int iCol)
        {
            Vector vector = new Vector(Rows);
            for (int i = 0; i < Rows; i++)
                vector[i] = this[i, iCol];
            return vector;
        }

        /// <summary>
        /// The function returns a Scalar Matrix of dimension ( Row x Col ) and scalar K
        /// </summary>
        public static Matrix ScalarMatrix(int iRows, int iCols, int K)
        {
            double zero = 0;
            double scalar = K;
            Matrix matrix = new Matrix(iRows, iCols);
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iCols; j++)
                {
                    if (i == j)
                        matrix[i, j] = scalar;
                    else
                        matrix[i, j] = zero;
                }
            return matrix;
        }

        /// <summary>
        /// The function returns an identity matrix of dimensions ( Row x Col )
        /// </summary>
        public static Matrix IdentityMatrix(int iRows, int iCols)
        {
            return ScalarMatrix(iRows, iCols, 1);
        }

        /// <summary>
        /// The function returns a Unit Matrix of dimension ( Row x Col )
        /// </summary>
        public static Matrix UnitMatrix(int iRows, int iCols)
        {
            double temp = 1;
            Matrix matrix = new Matrix(iRows, iCols);
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iCols; j++)
                    matrix[i, j] = temp;
            return matrix;
        }

        /// <summary>
        /// The function returns a Null Matrix of dimension ( Row x Col )
        /// </summary>
        public static Matrix NullMatrix(int iRows, int iCols)
        {
            double temp = 0;
            Matrix matrix = new Matrix(iRows, iCols);
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iCols; j++)
                    matrix[i, j] = temp;
            return matrix;
        }

        /// <summary>
        /// Operators for the Matrix object
        /// includes -(unary), and binary opertors such as +,-,*,/
        /// </summary>
        public static Matrix operator -(Matrix matrix)
        { return Matrix.Negate(matrix); }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        { return Matrix.Add(matrix1, matrix2); }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        { return Matrix.Add(matrix1, -matrix2); }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        { return Matrix.Multiply(matrix1, matrix2); }

        public static Matrix operator *(Matrix matrix1, int iNo)
        { return Matrix.Multiply(matrix1, iNo); }

        public static Matrix operator *(Matrix matrix1, double dbl)
        { return Matrix.Multiply(matrix1, dbl); }

        public static Matrix operator *(int iNo, Matrix matrix1)
        { return Matrix.Multiply(matrix1, iNo); }

        public static Matrix operator *(double dbl, Matrix matrix1)
        { return Matrix.Multiply(matrix1, dbl); }

        public static Matrix operator *(Matrix matrix1, Vector vector1)
        { return Matrix.Multiply(matrix1, vector1); }

        public static Matrix operator *(Vector vector1, Matrix matrix1)
        { return Matrix.Multiply(vector1, matrix1); }

        public static Matrix operator /(Matrix matrix1, int iNo)
        { return Matrix.Multiply(matrix1, iNo); }

        public static Matrix operator /(Matrix matrix1, double dbl)
        { return Matrix.Multiply(matrix1, (1 / dbl)); }

        /// <summary>
        /// Internal Fucntions for the above operators
        /// </summary>
        private static Matrix Negate(Matrix matrix)
        {
            return Matrix.Multiply(matrix, -1);
        }

        private static Matrix Add(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
                throw new MatrixException("Operation not possible");
            Matrix result = new Matrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
            return result;
        }

        private static Matrix Multiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Cols != matrix2.Rows)
                throw new MatrixException("Operation not possible");
            Matrix result = Matrix.NullMatrix(matrix1.Rows, matrix2.Cols);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Cols; j++)
                    for (int k = 0; k < matrix1.Cols; k++)
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
            return result;
        }

        private static Matrix Multiply(Matrix matrix, int iNo)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    result[i, j] = matrix[i, j] * iNo;
            return result;
        }

        private static Matrix Multiply(Matrix matrix, double frac)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Cols);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    result[i, j] = matrix[i, j] * frac;
            return result;
        }

        private static Matrix Multiply(Matrix matrix, Vector vector)
        {
            if (!vector.ColumnVector || matrix.Cols != vector.Dimension)
                throw new VectorException("Operation not possible");
            Matrix result = Matrix.NullMatrix(matrix.Rows, 1);
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Cols; j++)
                    result[i, 0] += matrix[i, j] * vector[j];
            return result;
        }

        private static Matrix Multiply(Vector vector, Matrix matrix)
        {
            if (vector.ColumnVector || vector.Dimension != matrix.Rows)
                throw new VectorException("Operation not possible");
            Matrix result = Matrix.NullMatrix(1, matrix.Cols);
            for (int j = 0; j < matrix.Cols; j++)
                for (int i = 0; i < matrix.Rows; i++)
                    result[0, j] += matrix[i, j] * vector[i];
            return result;
        }

    }	//end class Matrix

    /// <summary>
    /// Exception class for Matrix class, derived from System.Exception
    /// </summary>
    public class MatrixException : Exception
    {
        public MatrixException()
            : base()
        { }

        public MatrixException(string Message)
            : base(Message)
        { }

        public MatrixException(string Message, Exception InnerException)
            : base(Message, InnerException)
        { }
    }	// end class MatrixException

    /*
    public class MatrixTestClass
    {
        private Vector myVector1;
        private Matrix myMatrix1;
        private Matrix myMatrix2;
        private Matrix myMatrix3;
        private Matrix myMatrixVect;

        public MatrixTestClass()
        {
            System.Random rnd = new System.Random();
            int k = 1;

            this.myVector1 = new Vector(3);

            for (int i = 0; i < this.myVector1.Dimension; i++)
            {
                this.myVector1[i] = (rnd.Next() % 10) - 5;
            }
            this.myMatrixVect = new Matrix(3, 3);
            for (int i = 0; i < this.myMatrixVect.Rows; i++)
            {
                for (int j = 0; j < this.myMatrixVect.Cols; j++)
                {
                    this.myMatrixVect[i, j] = (rnd.Next() % 10) - 5;
                }
            }

            this.myMatrix1 = new Matrix(4, 4);
            this.myMatrix2 = new Matrix(4, 2);
            for (int i = 0; i < this.myMatrix1.Rows; i++)
            {
                for (int j = 0; j < this.myMatrix1.Cols; j++)
                {
                    this.myMatrix1[i, j] = (rnd.Next() % 10) - 5;
                    //this.myMatrix1[i, j] = k;
                    //k++;
                }
            }
            k = 1;
            for (int i = 0; i < this.myMatrix2.Rows; i++)
            {
                for (int j = 0; j < this.myMatrix2.Cols; j++)
                {
                    this.myMatrix2[i, j] = k;
                    k++;
                }
            }
            Console.WriteLine("Matrix1:");
            Console.WriteLine((this.myMatrix1).ConvertToString());
            Console.WriteLine("Matrix2:");
            Console.WriteLine((this.myMatrix2).ConvertToString());

            Console.WriteLine("Matrix1 duplizieren:");
            this.myMatrix3 = new Matrix(2, 2);
            this.myMatrix3 = this.myMatrix1.Duplicate();
            Console.WriteLine("Element 0,0 der neuen Matrix wert 500 zuweisen:");
            this.myMatrix3[0, 0] = 500;
            Console.WriteLine("Matrix1:");
            Console.WriteLine((this.myMatrix1).ConvertToString());
            Console.WriteLine("Matrix3:");
            Console.WriteLine((this.myMatrix3).ConvertToString());
            Console.WriteLine("Matrix1 invertieren:");
            Console.WriteLine((this.myMatrix1.Inverse()).ConvertToString());
            Console.WriteLine("1. Element der invertierten Matrix1 auslesen:");
            Console.WriteLine((this.myMatrix1.Inverse())[0, 0]);
            Console.WriteLine("Matrix1 Transponieren:");
            Console.WriteLine((this.myMatrix2.Transpose()).ConvertToString());
            Console.WriteLine("Matrix1 und 2 multiplizieren:");
            Console.WriteLine((this.myMatrix1 * this.myMatrix2).ConvertToString());
            Console.WriteLine("Reduzierteform der Matrix1:");
            Console.WriteLine((this.myMatrix1.EchelonForm()).ConvertToString());
            Console.WriteLine("Determinante Matrix1 :");
            Console.WriteLine(this.myMatrix1.Determinent());
            Console.WriteLine("Matrix1 :");
            Console.WriteLine(this.myMatrix1.ConvertToString());
            Matrix Matrix4 = new Matrix(myMatrix1);
            Console.WriteLine("Matrix4 mittels CopyConstructor :");
            Console.WriteLine(Matrix4.ConvertToString());
            Console.WriteLine("MatrixVect :");
            Console.WriteLine(this.myMatrixVect.ConvertToString());
            Console.WriteLine("myVector1 :");
            Console.WriteLine(this.myVector1.ConvertToString());
            Console.WriteLine("myMatrixVect * myVector1 :");
            Console.WriteLine(((Matrix)(myMatrixVect*myVector1)).ConvertToString());
            Console.WriteLine("myVector1^T * myMatrixVect :");
            Console.WriteLine(((Matrix)(myVector1.Transpose() * myMatrixVect)).ConvertToString());
            Console.WriteLine("myMatrixVect[1,*] :");
            Console.WriteLine(myMatrixVect.ConvertRowToVector(0).ConvertToString());
            Console.WriteLine("myMatrixVect[*,1] :");
            Console.WriteLine(myMatrixVect.ConvertColToVector(0).ConvertToString());
        }
    }//MatrixTestClass Ende*/
}