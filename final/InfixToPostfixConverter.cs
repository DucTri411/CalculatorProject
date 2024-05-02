using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public static class InfixToPostfixConverter
    {
        public static int ToanTu(char a)
        {
            switch (a)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '(':
                case ')':
                    return 0;
            }
            return -1;
        }
        public static string ConvertInfixToPostfix(string infix)
        {
            string postfix = "";
            LinkedStack<char> stack = new LinkedStack<char>();
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];

                if (char.IsDigit(ch))
                {
                    postfix += ch;
                }
                else if (ToanTu(ch) < 0)
                {
                    return "Phương trình không hợp lệ!";
                }
                else if (ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == ')')
                {
                    while (stack.IsEmpty() && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    while (stack.IsEmpty() && ToanTu(ch) <= ToanTu(stack.Peek()))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(ch);
                }

            }
            while (stack.IsEmpty())
            {
                postfix += stack.Pop();
            }

            return postfix;
        }
    }
}
