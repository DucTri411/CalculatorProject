using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public static class PostFixEvaluator
    {
        public static double CalculatorPostFix(string postfix)
        {
            LinkedStack<double> stack = new LinkedStack<double>();
            foreach (char ch in postfix)
            {
                if (char.IsDigit(ch))
                {
                    stack.Push(ch - '0');
                }
                else if (IsOperator(ch))
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double c = 0;
                    switch (ch)
                    {
                        case '+': c = a + b; break;
                        case '-': c = a - b; break;
                        case '*': c = a * b; break;
                        case '/':
                            if (b != 0)
                            {
                                c = a / b;
                            }
                            else
                            {
                                MessageBox.Show("Không thể chia cho số 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                    stack.Push(c);
                }
            }
            return 0;
        }
        public static bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == '(' || ch == ')';
        }
    }
}
