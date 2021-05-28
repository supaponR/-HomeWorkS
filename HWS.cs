using System;

namespace HWS._5
{
    class Program
    {
        //ReadImageDataFromFile
        static double[,] ReadImageDataFromFile(string imageDataFilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
            int imageHeight = lines.Length;
            int imageWidth = lines[0].Split(',').Length;
            double[,] imageDataArray = new double[imageHeight, imageWidth];

            for (int i = 0; i < imageHeight; i++)
            {
                string[] items = lines[i].Split(',');
                for (int j = 0; j < imageWidth; j++)
                {
                    imageDataArray[i, j] = double.Parse(items[j]);
                }
            }
            return imageDataArray;
        }
        //WriteImageDataToFile
        static void WriteImageDataToFile(string imageDataFilePath,
                                         double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }
        //NewMethodeขยายอาร์เรย์
        static double[,] ExpandScaleArray(double[,] ImageLocatArray, int NewScaleCollum, int NewScaleRow , int ImageArrayCollum, int ImageArrayRow,
                                            int convolCollum, int convolRow)
        {
            double[,] ExpandArray = new double[NewScaleCollum, NewScaleRow];
            for (int i = 0; i < NewScaleCollum; i++)
            {
                for (int j = 0; j < NewScaleRow; j++) 
                {
                    ExpandArray[i, j] = ImageLocatArray[(i + (ImageArrayCollum - 1)) % ImageArrayCollum, (j + (ImageArrayRow - 1) )% ImageArrayRow];
                }
            }

            return ExpandArray;

        }
        //NewMethodeConvolutionKernel
        static double[,] Convolution(double[,] ExpandedScaleArray , double[,] conVolLocatArray
            , int ImageArrayCollum, int ImageArrayRow)
        {
            Double[,] ResultImage = new double[ImageArrayCollum, ImageArrayRow];
            for (int i = 0; i < ImageArrayCollum; i++)
            {
                for (int j = 0; j < ImageArrayRow; j++)
                {
                    for (int k = 0; k < conVolLocatArray.GetLength(0); k++)
                    {
                        for (int l = 0; l < conVolLocatArray.GetLength(1); l++)
                        {
                            ResultImage[i, j] += ExpandedScaleArray[i + k, j + l] * conVolLocatArray[k, l];
                        }
                    }
                }
            }
            return ResultImage;
        }

        static void Main(string[] args)
        {
            //รับค่าไฟล์รูปภาพนำเข้า
            Console.Write("Input Location File Address :");
            string ImageImportLocat = Console.ReadLine();
            
            ///ข้อมูลConvolution Kernel3*3
            Console.Write("Input Location file Convolution Kernel : ");
            string Convolocat = Console.ReadLine();

            ///ไฟล์ภาพผลรับ
            Console.Write("Input Location File output :");
            string ResultLocat = Console.ReadLine();

            double[,] ImageLocatArray = ReadImageDataFromFile(ImageImportLocat);
            double[,] conVolLocatArray = ReadImageDataFromFile(Convolocat);

            //ค่าสเกลArrayใหม่ 
            int NewScaleCollum = ImageLocatArray.GetLength(0) + conVolLocatArray.GetLength(0) - 1;  
            int NewScaleRow =ImageLocatArray.GetLength(1) + conVolLocatArray.GetLength(1) - 1; 

            ///ต่อเติมตัวArray
            double[,] ExpendedScaleArray = ExpandScaleArray(ImageLocatArray, NewScaleCollum, NewScaleRow, ImageLocatArray.GetLength(0) 
                                                            , ImageLocatArray.GetLength(1),  conVolLocatArray.GetLength(0), conVolLocatArray.GetLength(1));
            ///รูปที่ได้จาก Convolution เสร็จแล้ว
            double[,] ResultImage = Convolution(ExpendedScaleArray, conVolLocatArray, ImageLocatArray.GetLength(0), ImageLocatArray.GetLength(1));

            //RESULTIMAGE 
            WriteImageDataToFile(ResultLocat, ResultImage);   
        }
    }
}
