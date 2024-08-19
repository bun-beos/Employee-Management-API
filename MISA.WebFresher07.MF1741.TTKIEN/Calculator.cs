namespace MISA.WebFresher07.MF1741.TTKIEN
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tổng hai số nguyên</returns>
        /// Created by: ttkien (12/09/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Hàm cộng các số được truyền vào từ 1 chuỗi
        /// </summary>
        /// <param name="s">Chuỗi truyền vào</param>
        /// <exception cref="NotImplementedException"></exception>
        public int Add(string s)
        {
            if (s == "") return 0;
            int sum = 0, checkNavigativeInt = 0;
            string exceptionOperand = "Không chấp nhận toán hạng âm:";
            string[] s1 = s.Split(',');
            foreach (string s2 in s1)
            {
                string s3 = s2.Trim();
                try
                {
                    int operand = Int32.Parse(s3);
                    if (operand >= 0)
                    {
                        sum += operand;
                    }
                    else
                    {
                        checkNavigativeInt = 1;
                        exceptionOperand += $" {operand},";
                    } 
                        
                }
                catch (Exception)
                {
                    throw new Exception("Đầu vào không đúng định dạng.");
                }
            }
            if (checkNavigativeInt == 0)
            {
                return sum;
            }
            else
            {
                exceptionOperand = exceptionOperand.Remove(exceptionOperand.Length - 1, 1);
                throw new Exception(exceptionOperand);
            }
        }

        /// <summary>
        /// Hàm trừ hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu hai số nguyên</returns>
        /// Created by: ttkien (12/09/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm nhân hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tích hai số nguyên</returns>
        /// Created by: ttkien (12/09/2023)
        public long Mul(int x, int y)
        {
            return x * (long)y;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Hàm chia hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Thương hai số nguyên</returns>
        /// Created by: ttkien (12/09/2023)
        public double Div(int x, int y)
        {

            if (y == 0)
            {
                throw new Exception("Không chia được cho 0");
            }
            return x / (double)y;
        }
    }
}
